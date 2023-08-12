using LearnWild.Web.ViewModels.Resource;

namespace LearnWild.Web.ViewModels.Topic
{
	public class TopicViewModel
	{
        public string Id { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public IEnumerable<ResourceViewModel> Resources { get; set; } = new HashSet<ResourceViewModel>();
    }
}
