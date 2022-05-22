using Microsoft.AspNetCore.Mvc;

namespace api.Models.ResultModel
{
    public class TransactionNotFoundJson : IActionResult
    {
        public const string Error = "Transaction(s) Not Found.";
        public TransactionNotFoundJson() { }

        public Task ExecuteResultAsync(ActionContext context)
        {
            var objectResult = new ObjectResult(Error);
            objectResult.StatusCode = StatusCodes.Status406NotAcceptable;

            return objectResult.ExecuteResultAsync(context);
        }
        
    }
}
