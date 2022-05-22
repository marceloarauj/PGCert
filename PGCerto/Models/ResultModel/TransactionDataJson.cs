using api.Models.EntityModel;
using Microsoft.AspNetCore.Mvc;

namespace api.Models.ResultModel
{
    public class TransactionDataJson : IActionResult
    {
        public TransactionDataJson(Transaction transaction)
        {
            Approval = transaction.Approval;
            NetValue = transaction.NetValue;
            FixedRate = transaction.FixedRate;
            InstallmentsNumber = transaction.InstallmentsNumber;
            Nsu = transaction.Nsu;
        }

        public string Nsu { get; set; }
        public DateTime? Approval { get; set; }
        public decimal NetValue { get; set; }
        public decimal FixedRate { get; set; }
        public int InstallmentsNumber { get; set; }

        public Task ExecuteResultAsync(ActionContext context)
        {
            return new JsonResult(this).ExecuteResultAsync(context);
        }
    }
}
