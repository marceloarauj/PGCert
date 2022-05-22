using System.ComponentModel.DataAnnotations;

namespace api.Models.Validations
{
    public class JsonInstallmentNumber: RangeAttribute
    {
        private const int Minimum = 1;
        private const int Maximum = 200;

        public JsonInstallmentNumber(): base(Minimum, Maximum)
        {
            ErrorMessage = $"{0}: Between {Minimum} and {Maximum}.";
        }
    }
}
