using api.Models.EntityModel;
using Microsoft.AspNetCore.Mvc;

namespace api.Models.ResultModel
{
    public class TransactionJson : IActionResult
    {
        public TransactionJson(Transaction transaction)
        {
            Date = transaction.Date;
            Approval = transaction.Approval;
            Disapproval = transaction.Disapproval;
            Anticipation = transaction.Anticipation;
            AcquirerConfirmation = transaction.AcquirerConfirmation;
            BruteValue = transaction.BruteValue;
            NetValue = transaction.NetValue;
            FixedRate = transaction.FixedRate;
            InstallmentsNumber = transaction.InstallmentsNumber;
            CreditCardLastNumbers = transaction.CreditCardLastNumbers;
            Installments = transaction.Installments.Select(installment => new InstallmentJson(installment)).ToList();
        }

        public DateTime Date { get; set; }
        public DateTime? Approval { get; set; }
        public DateTime? Disapproval { get; set; }
        public bool? Anticipation { get; set; }
        public Status AcquirerConfirmation { get; set; }
        public decimal BruteValue { get; set; }
        public decimal NetValue { get; set; }
        public decimal FixedRate { get; set; }
        public int InstallmentsNumber { get; set; }
        public string? CreditCardLastNumbers { get; set; }
        public List<InstallmentJson>? Installments { get; set; }

        public Task ExecuteResultAsync(ActionContext context)
        {
            return new JsonResult(this).ExecuteResultAsync(context);
        }
    }
}
