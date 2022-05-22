using Microsoft.AspNetCore.Mvc;

namespace api.Models.ResultModel
{
    public class EmptyAnticipationEvaluateJson : IActionResult
    {
        public const string Error = "List of transactions cannot be empty";
        public Task ExecuteResultAsync(ActionContext context)
        {
            return new BadRequestObjectResult(Error).ExecuteResultAsync(context);
        }
    }
}
