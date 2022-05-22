using api.Models.EntityModel;
using Microsoft.AspNetCore.Mvc;

namespace api.Models.ResultModel
{
    public class AnticipationJson : IActionResult
    {
        public AnticipationJson() { }

        public AnticipationJson(Anticipation anticipation)
        {
            Id = anticipation.Id;
            SolicitationDate = anticipation.SolicitationDate;
        }

        public int Id { get; set; }
        public DateTime SolicitationDate { get; set; }

        public Task ExecuteResultAsync(ActionContext context)
        {
            return new OkResult().ExecuteResultAsync(context);
        }
    }
}
