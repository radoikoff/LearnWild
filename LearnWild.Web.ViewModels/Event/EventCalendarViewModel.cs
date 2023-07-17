namespace LearnWild.Web.ViewModels.Event
{
    public class EventCalendarViewModel
    {
        public string Title { get; set; } = null!;

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public string? Url { get; set; }

    }
}