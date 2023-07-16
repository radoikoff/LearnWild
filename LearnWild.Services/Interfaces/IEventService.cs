using LearnWild.Web.ViewModels.Event;

namespace LearnWild.Services.Interfaces
{
	public interface IEventService
	{
		Task CreateAsync(EventFormModel model, string courseId);
		Task<bool> IsScheduled(DateTime? start, DateTime? end, string courseId, string teacherId);
	}
}
