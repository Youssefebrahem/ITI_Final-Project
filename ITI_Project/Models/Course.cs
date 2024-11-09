using System.ComponentModel.DataAnnotations;

namespace ITI_Project.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string? Title { get; set; }

        [StringLength(1000)]
        public string? Description { get; set; }

        [Range(1, 15)]
        public int Credits { get; set; }

        public bool Status { get; set; } = true;

        public override string ToString()
        {
            return $"Id: {Id}, Title: {Title}, Description: {Description}, Credits: {Credits}";
        }
    }
}
