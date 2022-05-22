using api.Models.Validations;

namespace api.Models.ViewModel
{
    public class AttendanceEvaluationModel
    {
        [JsonListSize]
        public List<AnticipationEvaluateModel> Evaluations { get; set; }
    }
}
