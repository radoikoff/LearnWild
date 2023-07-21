using LearnWild.Data;
using LearnWild.Data.Models;
using LearnWild.Data.Models.Enums;
using LearnWild.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var order = await _dbContext.Orders.FirstOrDefaultAsync(o => o.UserId == Guid.Parse(userId) &&
                                                                         o.Status == OrderStatus.Open);
            if (order == null)
            {
                order = new Order()
                {
                    CreatedOn = DateTime.UtcNow,
                    Status = OrderStatus.Open,
                    UserId = Guid.Parse(userId)
                };
            }

            var registration = new CourseRegistration()
            {
                CourseId = Guid.Parse(courseId),
                StudentId = Guid.Parse(userId),
                AppliedOn = DateTime.UtcNow,
                Status = RegisterStatus.PaymentPending,
            };

            order.Registrations.Add(registration);

            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();
        }
    }
}
