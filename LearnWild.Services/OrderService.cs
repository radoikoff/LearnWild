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

        public async Task<bool> IsActiveOrderContainsCourseAsync(string courseId, string userId)
        {
            return await _dbContext.Orders.AnyAsync(o => o.UserId == Guid.Parse(userId) &&
                                                         o.Status == OrderStatus.Open &&
                                                         o.Registrations.Any(r => r.CourseId == Guid.Parse(courseId)));
        }

        public async Task<bool> IsOrderContainsCourseAsync(string courseId, string userId)
        {
            return await _dbContext.Orders.AnyAsync(o => o.UserId == Guid.Parse(userId) &&
                                                         o.Registrations.Any(r => r.CourseId == Guid.Parse(courseId)));
        }

        public async Task AddCourseToActiveOrderAsync(string courseId, string userId)
        {
            var order = await _dbContext.Orders
                            .Include(o => o.Registrations)
                            .ThenInclude(r => r.Course)
                            .FirstOrDefaultAsync(o => o.UserId == Guid.Parse(userId) && o.Status == OrderStatus.Open);

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

            if (!order.Registrations.Any(r => r.CourseId == Guid.Parse(courseId)))
            {
                var courseToAdd = await _dbContext.Courses.FirstAsync(c => c.Id == Guid.Parse(courseId));

                var registration = new CourseRegistration()
                {
                    Course = courseToAdd,
                    StudentId = Guid.Parse(userId),
                    AppliedOn = DateTime.UtcNow,
                    Status = RegisterStatus.PaymentPending
                };

                order.Registrations.Add(registration);

                decimal subtotal = order.Registrations.Sum(c => c.Course.Price ?? 0);
                decimal discount = 0;

                if (order.Registrations.Count() > 1)
                {
                    discount = subtotal * 0.10m;
                }

                order.SubtotalPrice = subtotal;
                order.Discount = discount;
                order.TotalPrice = subtotal - discount;
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
                                            Id = r.CourseId.ToString(),
                                            Title = r.Course.Title,
                                            Credits = r.Course.MaxCredits,
                                            Price = r.Course.Price ?? 0
                                        })
                                        .ToArray(),
                                        Subtotal = o.SubtotalPrice,
                                        Discount = o.Discount,
                                        Total = o.TotalPrice
                                    })
                                    .FirstOrDefaultAsync();

            //if (order == null)
            //{
            //    return new OrderViewModel();
            //}

            //decimal subtotal = order.Courses.Sum(c => c.Price);
            //decimal discount = 0;

            //if (order.Courses.Count() > 1)
            //{
            //    discount = subtotal * 0.10m;
            //}


            //order.Subtotal = subtotal;
            //order.Discount = discount;
            //order.Total = subtotal - discount;

            return order ?? new OrderViewModel();
        }

        public async Task CheckoutAsync(string orderId)
        {
            var order = await _dbContext.Orders
                                        .Where(o => o.Status == OrderStatus.Open)
                                        .Include(o => o.Registrations)
                                        .FirstAsync(o => o.Id == Guid.Parse(orderId));

            order.Status = OrderStatus.Completed;
            order.PricePaid = order.TotalPrice;
            order.CompletedOn = DateTime.UtcNow;

            foreach (var registration in order.Registrations)
            {
                registration.Status = RegisterStatus.Completed;
                registration.CompletedOn = DateTime.UtcNow;
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> IsActiveOrderExistsAsync(string orderId, string userId)
        {
            return await _dbContext.Orders.AnyAsync(o => o.Id == Guid.Parse(orderId) &&
                                                         o.UserId == Guid.Parse(userId) &&
                                                         o.Status == OrderStatus.Open);
        }

        public async Task<bool> IsActiveOrderExistsAsync(string userId)
        {
            return await _dbContext.Orders.AnyAsync(o => o.UserId == Guid.Parse(userId) &&
                                                         o.Status == OrderStatus.Open);
        }

        public async Task RemoveFromActiveOrderAsync(string courseId, string userId)
        {
            var order = await _dbContext.Orders
                                        .Include(o => o.Registrations)
                                        .ThenInclude(r => r.Course)
                                        .FirstOrDefaultAsync(o => o.UserId == Guid.Parse(userId) &&
                                                                  o.Status == OrderStatus.Open);

            if (order == null)
            {
                throw new InvalidOperationException("Such order does not exists");
            }

            var courseToRemove = order.Registrations.First(r => r.CourseId == Guid.Parse(courseId));

            order.Registrations.Remove(courseToRemove);
            _dbContext.CourseRegistrations.Remove(courseToRemove);

            decimal subtotal = order.Registrations.Sum(c => c.Course.Price ?? 0);
            decimal discount = 0;

            if (order.Registrations.Count() > 1)
            {
                discount = subtotal * 0.10m;
            }

            order.SubtotalPrice = subtotal;
            order.Discount = discount;
            order.TotalPrice = subtotal - discount;

            await _dbContext.SaveChangesAsync();
        }
    }
}
