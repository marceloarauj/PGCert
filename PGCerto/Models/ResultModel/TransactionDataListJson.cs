using api.Models.EntityModel;
using Microsoft.AspNetCore.Mvc;

namespace api.Models.ResultModel
{
    public class TransactionDataListJson : IActionResult
    {
        public TransactionDataListJson(IQueryable<Transaction> transactions)
        {
            Transactions = transactions.Select(transaction => new TransactionDataJson(transaction)).ToList();
        }

        public List<TransactionDataJson> Transactions { get; set; }

        public Task ExecuteResultAsync(ActionContext context)
        {
            return new OkObjectResult(this).ExecuteResultAsync(context);
        }
    }
}
