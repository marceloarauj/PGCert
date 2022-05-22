
using api.Models.Validations;

namespace api.Models.ViewModel
{
    public class AnticipationRequestModel
    {
        [JsonListSize]
        public List<string> TransactionCodes { get; set; }
    }
}
