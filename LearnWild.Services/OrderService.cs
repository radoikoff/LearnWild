using LearnWild.Data;
using LearnWild.Data.Models;
using LearnWild.Data.Models.Enums;
using LearnWild.Services.Interfaces;
using LearnWild.Web.ViewModels.Course;
using LearnWild.Web.ViewModels.Order;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace LearnWild.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> HasOrderAsync(string courseId, string userId)
        {
            return await _dbContext.Orders.AnyAsync(o => o.UserId == Guid.Parse(userId) &&
                                                         o.Registrations.Any(r => r.CourseId == Guid.Parse(courseId)));
        }

        public async Task AddToOrderAsync(string courseId, string userId)
        {
            var order = await _dbContext.Orders
                                        .Include(o=>o.Registrations)
                                        .FirstOrDefaultAsync(o => o.UserId == Guid.Parse(userId) &&
                                                                  o.Status == OrderStatus.Open);
            if (order == null)
            {
                order = new Order()
                {
                    CreatedOn = DateTime.UtcNow,
                    Status = OrderStatus.Open,
                    UserId = Guid.Parse(userId)
                };

                _dbContext.Orders.Add(order);
            }

            if(!order.Registrations.Any(r=>r.CourseId == Guid.Parse(courseId)))
            {
                var registration = new CourseRegistration()
                {
                    CourseId = Guid.Parse(courseId),
                    StudentId = Guid.Parse(userId),
                    AppliedOn = DateTime.UtcNow,
                    Status = RegisterStatus.PaymentPending
                };

                order.Registrations.Add(registration);
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task<OrderViewModel> GetByUserIdAsync(string userId)
        {
            var order = await _dbContext.Orders
                                    .Where(o => o.UserId == Guid.Parse(userId) &&
                                                o.Status == OrderStatus.Open)
                                    .Select(o => new OrderViewModel()
                                    {
                                        Id = o.Id.ToString(),
                                        Courses = o.Registrations.Select(r => new CourseOrderViewModel()
                                        {
                                            Title = r.Course.Title,
                                            Credits = r.Course.MaxCredits,
                                            Price = r.Course.Price ?? 0
                                        })
                                        .ToArray()
                                    })
                                    .FirstOrDefaultAsync();

            if (order == null)
            {
                return new OrderViewModel();
            }

            decimal subtotal = order.Courses.Sum(c => c.Price);
            decimal discount = 0;

            if (order.Courses.Count() > 1)
            {
                discount = subtotal * 0.10m;
            }


            order.Subtotal = subtotal;
            order.Discount = discount;
            order.Total = subtotal - discount;

            return order;
        }
    }
}
