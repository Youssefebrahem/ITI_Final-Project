using ITI_Project.ValidationAttributes;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_Project.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string UserName { get; set; }

        [StringLength(100)]
        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(256)]
        [RegularExpression(@"[a-zA-Z0-9_]+@[a-z]+\.[a-zA-Z0-9]{2,4}")]
        [Remote("CheckExistingEmail", "Home", ErrorMessage = "Email already exists!")]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [Required]
        [StringLength(15)]
        public string Password { get; set; }

        [NotMapped]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public bool Status { get; set; } = true;

    }
}
