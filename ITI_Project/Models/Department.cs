using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ITI_Project.Models
{
    public class Department
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]//if you want to enter the value of primary key by yourself
        public int DeptId { get; set; }

        [Required]
        [StringLength(15)]
        public string? DeptName { get; set; }

        [Range(100, 3000)]
        public int Capacity { get; set; }

        public bool Status { get; set; } = true;

        //vertual is used to create a relationship between two tables
        public virtual List<Student> Students { get; set; } = new List<Student>();

        public override string ToString()
        {
            return $"DeptId: {DeptId}, DeptName: {DeptName}, Capacity: {Capacity}";
        }
    }
}
