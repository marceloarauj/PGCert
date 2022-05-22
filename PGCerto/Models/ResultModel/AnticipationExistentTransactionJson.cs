using Microsoft.AspNetCore.Mvc;

namespace api.Models.ResultModel
{
    public class AnticipationExistentTransactionJson : IActionResult
    {
        public const string Error = "Anticipation of some transaction already exists.";

        public Task ExecuteResultAsync(ActionContext context)
        {
            var objectResult = new ObjectResult(Error);
            objectResult.StatusCode = 406;

            return objectResult.ExecuteResultAsync(context);
        }
    }
}
