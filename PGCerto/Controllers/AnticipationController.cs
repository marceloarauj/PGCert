using api.Models.EntityModel;
using api.Models.ResultModel;
using api.Models.ServiceModel;
using api.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AnticipationController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly AnticipationService _anticipationService;

        public AnticipationController(AppDbContext context, AnticipationService anticipation)
        {
            _context = context;
            _anticipationService = anticipation;
        }

        /// <summary>
        /// Visualização de antecipações pendentes
        /// </summary>
        /// <returns></returns>
        [HttpGet("pending")]
        public IActionResult PendingAnalysis()
        {
            var pendingAnticipations = _context.Anticipations.WhereIsPending();
            return new PendingAnticipationJson(pendingAnticipations);
        }


        [HttpGet("transactions")]
        public IActionResult TransactionList()
        {
            var transactions = _context.Transactions.WhereNotStarted();
            return new TransactionDataListJson(transactions);
        }

        [HttpPost("request")]
        public IActionResult AnticipationRequest( [MinLength(1)] List<string> transactionCodes)
        {
            return _anticipationService.CreateAnticipation(transactionCodes);
        }

        [HttpGet("attendance/start/{id}")]
        public IActionResult AttendanceStart(int id)
        {
            return _anticipationService.StartEvaluate(id);
        }

        [HttpPut("attendance/evaluation")]
        public IActionResult AttendanceEvaluation(List<AnticipationEvaluateModel> evaluations)
        {
            if (!evaluations.Any()) return new EmptyAnticipationEvaluateJson();

            return _anticipationService.AttendanceEvaluation(evaluations);
        }

        /// <summary>
        /// List Anticipations by status
        /// </summary>
        /// <param name="status"> Pending = 0, InAnalysis = 1, Finished = 2 </param>
        /// <returns></returns>
        [HttpGet("records/{status}")]
        public IActionResult Records(AnalysisStatusModel status)
        {
            return _anticipationService.Records(status);
        }
    }
}
