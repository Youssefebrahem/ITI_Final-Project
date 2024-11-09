using ITI_Project.Models;
using System.ComponentModel.DataAnnotations;

namespace ITI_Project.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(30, MinimumLength =3)]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        //public Account Account { get; set; }
    }
}
