namespace ProgramApplication.Models
{
    public class ApplicationForm
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string? Nationality { get; set; }
        public string? CurrentResidence { get; set; }
        public string? IDNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public List<CustomQuestion>? CustomQuestions { get; set; }
        public bool IsInternal { get; set; }
        public bool Hide { get; set; }
    }
}
