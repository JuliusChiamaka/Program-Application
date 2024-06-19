using ProgramApplication.Models;

namespace ProgramApplication
{
    public class CustomQuestionDto
    {
        public string Question { get; set; }
        public QuestionType QuestionType { get; set; }
        public bool Internal { get; set; }
        public bool Hide { get; set; }
    }
}
