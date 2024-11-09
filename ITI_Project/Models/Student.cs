using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ITI_Project.ValidationAttributes;
using Microsoft.AspNetCore.Mvc;

namespace ITI_Project.Models
{
    public class Student
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]//if you want to enter the value of primary key by yourself
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required!")]
        [StringLength(15, MinimumLength = 3)]
        public string? Name { get; set; }

        [Range(10, 30)]
        public int Age { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z0-9_]+@[a-z]+\.[a-zA-Z0-9]{2,4}")]
        [Remote("CheckExistingEmail", "Home", ErrorMessage = "Email already exists!")]
        public string? Email { get; set; }

        [Required, StringLength(15)]
        public string? Password { get; set; }

        [NotMapped]
        [Compare("Password")]
        [MyValidation]
        public string? ConfirmPassword { get; set; }

        public bool Status { get; set; } = true;

        public virtual Department? Department { get; set; }
        [ForeignKey(nameof(Department))] // name of the navigation property
        public int DeptNo { get; set; } //if DepNo is: DeptId, then it will be automatically considered as foreign key

        //vertual is used to create a relationship between two tables
        public override string ToString()
        {
            return $"stdId: {Id}, stdName: {Name}, stdAge: {Age}";
        }
    }
}
