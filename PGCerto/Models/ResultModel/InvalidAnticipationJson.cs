using Microsoft.AspNetCore.Mvc;

namespace api.Models.ResultModel
{
    public class InvalidAnticipationJson : IActionResult
    {
        private const string Error = "Invalid anticipation Id.";
        public Task ExecuteResultAsync(ActionContext context)
        {
            var objectResult = new ObjectResult(Error);
            objectResult.StatusCode = StatusCodes.Status406NotAcceptable;

            return objectResult.ExecuteResultAsync(context);
        }
    }
}
