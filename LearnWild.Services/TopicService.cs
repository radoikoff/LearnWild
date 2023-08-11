using LearnWild.Data;
using LearnWild.Data.Models;
using LearnWild.Services.Interfaces;
using LearnWild.Web.ViewModels.Topic;
using LearnWild.Web.ViewModels.User;
using Microsoft.EntityFrameworkCore;

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

		public async Task DeleteTopicAsync(string topicId)
		{
			var topicToDelete = await _dbContext.Topics.FindAsync(Guid.Parse(topicId));

			if (topicToDelete == null)
			{
				throw new InvalidOperationException("Such topic cannot be found!");
			}

			_dbContext.Topics.Remove(topicToDelete);
			await _dbContext.SaveChangesAsync();
		}

		public async Task EditTopicAsync(TopicFormModel inputModel, string id)
		{
			var topic = await _dbContext.Topics.FindAsync(Guid.Parse(id));

			if (topic == null)
			{
				throw new InvalidOperationException("Such topic cannot be found!");
			}

			topic.Title = inputModel.Title;
			topic.Description = inputModel.Description;

			await _dbContext.SaveChangesAsync();
		}

		public async Task<bool> ExistsAsync(string courseId, string title, string? topicId = null)
		{
			if (topicId == null)
			{
				return await _dbContext.Topics.AnyAsync(t => t.CourseId == Guid.Parse(courseId) && t.Title == title);
			}
			return await _dbContext.Topics.AnyAsync(t => t.CourseId == Guid.Parse(courseId) &&
													t.Title == title &&
													t.Id != Guid.Parse(topicId));
		}

		public async Task<bool> ExistsAsync(string id)
		{
			return await _dbContext.Topics.AnyAsync(t => t.Id == Guid.Parse(id));
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

		public async Task<TopicFormModel?> GetByIdForEditAsync(string id)
		{
			return await _dbContext.Topics.Where(t => t.Id == Guid.Parse(id))
								.Select(t => new TopicFormModel()
								{
									Title = t.Title,
									Description = t.Description,
									CourseId = t.CourseId.ToString(),
								})
								.FirstOrDefaultAsync();
		}

		public async Task<UserSelectViewModel> GetTeacherByTopicIdAsync(string topicId)
		{
			var teacher = await _dbContext.Topics
										  .Where(t => t.Id == Guid.Parse(topicId))
										  .Select(t => new UserSelectViewModel()
										  {
											  Id = t.Course.TeacherId.ToString(),
											  Name = t.Course.Teacher.FirstName + ' ' + t.Course.Teacher.LastName
										  })
										  .FirstAsync();
			return teacher;
		}
	}
}
