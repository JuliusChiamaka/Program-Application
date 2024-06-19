using ProgramApplication.Models;

namespace ProgramApplication.DTOs
{
    public class CustomQuestionDto
    {
        public string QuestionType { get; set; }
        public string QuestionText { get; set; }
        public bool IsInternal { get; set; }
        public bool Hide { get; set; }
        public string Answer { get; set; }
    }
}
