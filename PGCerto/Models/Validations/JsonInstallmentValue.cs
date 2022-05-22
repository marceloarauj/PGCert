using System.ComponentModel.DataAnnotations;

namespace api.Models.Validations
{
    public class JsonInstallmentValue: RangeAttribute
    {
        private const double Minimum = 1;
        private const double Maximum = 10000000000000;

        public JsonInstallmentValue() : base(Minimum, Maximum)
        {
            ErrorMessage = $"{0}: Between {Minimum} and {Maximum}.";
        }
    }
}
