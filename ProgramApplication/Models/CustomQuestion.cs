namespace ProgramApplication.Models
{
    public class CustomQuestion
    {
        public string Question { get; set; }
        public QuestionType QuestionType { get; set; }
        public bool Internal { get; set; }
        public bool Hide { get; set; }
    }
}
