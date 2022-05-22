using api.Models.EntityModel;
using Microsoft.AspNetCore.Mvc;

namespace api.Models.ResultModel
{
    public class PendingAnticipationJson : IActionResult
    {
        public PendingAnticipationJson(IQueryable<Anticipation> anticipations)
        {
            Anticipations = anticipations.Select(anticipation => new AnticipationJson(anticipation)).ToList();
        }

        public List<AnticipationJson> Anticipations { get; set; }

        public Task ExecuteResultAsync(ActionContext context)
        {
            return new JsonResult(this).ExecuteResultAsync(context);
        }
    }

}
