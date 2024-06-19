namespace ProgramApplication.Models
{
    public class CustomQuestion
    {
        public Guid Id { get; set; }
        public string QuestionType { get; set; }
        public string QuestionText { get; set; }
        public bool IsInternal { get; set; }
        public bool Hide { get; set; }
        public string? Answer { get; set; }
    }
}
