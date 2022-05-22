using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace api.Models.Validations
{
    public class JsonCreditCard: ValidationAttribute
    {
        public JsonCreditCard()
        {
            ErrorMessage = "{0}: Invalid.";
        }

        protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
        {
            string pattern = @"^[0-9]{16}$";

            var regex = new Regex(pattern);

            if(regex.IsMatch((string)value)) return ValidationResult.Success;

            return new ValidationResult(ErrorMessage);
        }
    }
}
