using Microsoft.AspNetCore.Mvc;

namespace api.Models.ResultModel
{
    public class TransactionAlreadyExistsJson : IActionResult
    {
        public const string Error = "Code NSU already exists.";
        public Task ExecuteResultAsync(ActionContext context)
        {
            var objectResult = new ObjectResult(Error);
            objectResult.StatusCode = 406;

            return objectResult.ExecuteResultAsync(context);
        }
    }
}
