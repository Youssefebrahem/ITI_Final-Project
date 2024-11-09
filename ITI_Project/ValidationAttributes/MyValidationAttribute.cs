using System.ComponentModel.DataAnnotations;
namespace ITI_Project.ValidationAttributes
{
    public class MyValidationAttribute: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                string str = value.ToString();
                if (str.Contains("abc"))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
