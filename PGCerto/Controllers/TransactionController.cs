using api.Models.EntityModel;
using api.Models.ResultModel;
using api.Models.ServiceModel;
using api.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly TransactionService _transactionService;
        private readonly AppDbContext _context;

        public TransactionController(TransactionService transactionService, AppDbContext context)
        {
            _transactionService = transactionService;
            _context = context;
        }

        [HttpPost("payment")]
        public IActionResult Payment(TransactionModel model)
        {
            return _transactionService.CreateTransaction(model);
        }

        [HttpGet("search/{nsu}")]
        public IActionResult Search(string nsu)
        {
            var transaction = _context.Transactions.WhereId(nsu);

            if(transaction == null)
                return new TransactionNotFoundJson();

            transaction.Installments = _context.Installments
                                                .WhereNsu(nsu)
                                                .ToList();

            return new TransactionJson(transaction);
        }
    }
}
