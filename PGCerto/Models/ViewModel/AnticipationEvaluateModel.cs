using api.Models.EntityModel;
using api.Models.Validations;

namespace api.Models.ViewModel
{
    public class AnticipationEvaluateModel
    {
        [JsonRequired]
        public string Nsu { get; set; }

        [JsonRequired]
        public AnticipationEvaluateStatus Status { get; set; }
    }

    public enum AnticipationEvaluateStatus
    {
        Approved,
        Reproved
    }
}
