using System.ComponentModel.DataAnnotations;

namespace api.Models.Validations
{
    public class JsonListSize:MinLengthAttribute
    {
        private const int MinValue = 1;

        public JsonListSize() : base(MinValue)
        {
            ErrorMessage = "{0}: Minimun size must be 1.";
        }
    }
}
