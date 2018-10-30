using System.ComponentModel.DataAnnotations;
namespace Exterminator.Models.Attributes
{
    public class Expertize : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var validationValue = value.ToString();
            if(validationValue == "Ghost catcher") return ValidationResult.Success;
            else if (validationValue == "Ghoul strangler") return ValidationResult.Success;
            else if (validationValue == "Monster encager") return ValidationResult.Success;
            else if (validationValue == "Zombie exploder") return ValidationResult.Success;

            var message = FormatErrorMessage("This is not a valid input");
            return new ValidationResult(message);  
        }
    }
}