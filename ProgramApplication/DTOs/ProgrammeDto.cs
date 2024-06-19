using System.ComponentModel.DataAnnotations;

namespace ProgramApplication.DTOs
{
    public class ProgrammeDto
    {
        [Required]
        public string ProgramTitle { get; set; }

        [Required]
        public string ProgramDescription { get; set; }
    }
}
