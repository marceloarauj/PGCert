using api.Models.EntityModel;
using Microsoft.AspNetCore.Mvc;

namespace api.Models.ResultModel
{
    public class AnticipationTransactionJson : IActionResult
    {
        public AnticipationTransactionJson(IQueryable<Anticipation> anticipations)
        {
            Anticipations = anticipations.ToList();
        }

        public List<Anticipation> Anticipations { get; set; }

        public Task ExecuteResultAsync(ActionContext context)
        {
            return new JsonResult(this).ExecuteResultAsync(context);
        }
    }
}
