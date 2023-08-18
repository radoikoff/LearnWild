namespace LearnWild.Data.Models
{
    public class StudentResponse
    {
        public Guid Id { get; set; }

        public Guid QuizAttemptId { get; set; }
        public QuizAttempt QuizAttempt { get; set; } = null!;

        public Guid QuestionId { get; set; }
        public Question Question { get; set; } = null!;

        public Guid? ResponseId { get; set; }
        public Response? Response { get; set; }

        public DateTime RespondedOn { get; set; }
    }
}
