using api.Extensions;
using api.Models.EntityModel;
using api.Models.ResultModel;
using api.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace api.Models.ServiceModel
{
    public class TransactionService
    {
        private readonly AppDbContext _context;
        private readonly InstallmentService _installmentService;

        public TransactionService(AppDbContext context, InstallmentService installmentService)
        {
            _context = context;
            _installmentService = installmentService;
        }

        public IActionResult CreateTransaction(TransactionModel model)
        {
            var transaction = model.Map();

            if (_context.Transactions.NsuExists(transaction.Nsu))
                return new TransactionAlreadyExistsJson();

            bool validCreditCard = CreditCardExtensions.ValidCreditCardFirstNumbers(model.CreditCardNumber);

            transaction.AcquirerConfirmation = validCreditCard ? Status.Approved : Status.Reproved;

            transaction.CreditCardLastNumbers = CreditCardExtensions.LastFourNumbers(model.CreditCardNumber);

            if(transaction.AcquirerConfirmation == Status.Approved)
            {
                transaction.NetValue = transaction.BruteValue - transaction.FixedRate;
                transaction.Approval = transaction.Date;
                
                _installmentService.CreateInstallments(transaction);
            }
            else
            {
                transaction.Disapproval = transaction.Date;
            }

           _context.Transactions.Add(transaction);
           _context.SaveChanges();

            return new OkResult();
        }
    }
}
