using LearnWild.Data;
using LearnWild.Data.Models;
using LearnWild.Services.Interfaces;
using LearnWild.Web.ViewModels.Topic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnWild.Services
{
    public class TopicService : ITopicService
    {
        private readonly ApplicationDbContext _dbContext;

        public TopicService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateTopicAsync(TopicFormModel model)
        {
            var topic = new Topic()
            {
                CourseId = Guid.Parse(model.CourseId),
                Title = model.Title,
                Description = model.Description,
            };

            _dbContext.Topics.Add(topic);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(string courseId, string title)
        {
            return await _dbContext.Topics.AnyAsync(t => t.CourseId == Guid.Parse(courseId) && t.Title == title);
        }

        public async Task<IEnumerable<AllTopicsViewModel>> GetAllTopicsForCourseAsync(string courseId)
        {
            var topics = await _dbContext.Topics
                                         .Where(t => t.CourseId == Guid.Parse(courseId))
                                         .Select(t => new AllTopicsViewModel()
                                         {
                                             Id = t.Id.ToString(),
                                             CourseId = t.CourseId.ToString(),
                                             Title = t.Title,
                                             Description = t.Description,
                                             ResourceCount = t.Resources.Count()
                                         })
                                         .ToArrayAsync();
            return topics;
        }
    }
}
