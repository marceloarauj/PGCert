using api.Models.EntityModel;
using api.Models.ResultModel;
using api.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace api.Models.ServiceModel
{
    public class AnticipationService
    {
        private readonly AppDbContext _context;
        private readonly InstallmentService _installmentService;

        public AnticipationService(AppDbContext context, InstallmentService installmentService)
        {
            _context = context;
            _installmentService = installmentService;
        }

        public IActionResult CreateAnticipation(List<string> transactionCodes)
        {
            bool existTransactionInAntecipation = _context.AnticipationTransactions.WhereExistsRange(transactionCodes);

            if (existTransactionInAntecipation) return new AnticipationExistentTransactionJson();

            var transactions = _context.Transactions.WhereInValues(transactionCodes);
            
            if(!transactions.Any()) return new TransactionNotFoundJson();

            var anticipation = new Anticipation
            {
                SolicitationDate = DateTime.Now,
                RequestedValue = transactions.SumNetValues(),
            };

            anticipation.AnticipationTransactions =
                transactionCodes.Select(transactionCode => new AnticipationTransaction { TransactionNsu = transactionCode }).ToList();

            _context.Anticipations.Add(anticipation);

            _context.SaveChanges();

            return new AnticipationJson();
        }

        public IActionResult StartEvaluate(int id)
        {
            bool anticipationIsNotValid = _context.Anticipations.WhereNotExistOrNotIsPending(id);

            if (anticipationIsNotValid) return new InvalidAnticipationJson();

            var anticipation = _context.Anticipations.Where(anticipation => anticipation.Id == id).First();

            anticipation.StartAnalysisDate = DateTime.Now;

            _context.Anticipations.Update(anticipation);

            return new OkResult();
        }

        public IActionResult Records(AnalysisStatusModel status)
        {
            var anticipations = Enumerable.Empty<Anticipation>().AsQueryable();

            if (status == AnalysisStatusModel.Pending)
                anticipations = _context.Anticipations.Where(anticipation => anticipation.StartAnalysisDate == null);

            else if(status == AnalysisStatusModel.InAnalysis)
                anticipations = _context.Anticipations.Where
                    (anticipation => anticipation.StartAnalysisDate != null && anticipation.FinishedAnalysisDate == null);

            else if(status == AnalysisStatusModel.Finished)
                anticipations = _context.Anticipations.Where(anticipation => anticipation.FinishedAnalysisDate != null);

            return new AnticipationTransactionJson(anticipations);
        }

        public IActionResult AttendanceEvaluation(List<AnticipationEvaluateModel> evaluations)
        {
            evaluations.ForEach(evaluation => UpdateAnticipationEvaluationData(evaluation));

            return new OkResult();
        } 

        private void UpdateAnticipationEvaluationData(AnticipationEvaluateModel evaluation)
        {
            var anticipationTransaction = _context.AnticipationTransactions.FirstOrDefault
                                                (anticipation => anticipation.TransactionNsu == evaluation.Nsu);

            if (anticipationTransaction == null || anticipationTransaction.Status != null)
                return;

            var anticipation = _context.Anticipations.Where
                                        (anticipation => anticipation.Id == anticipationTransaction.AnticipationId).First();

            if (anticipation.Status != null)
                return;

            anticipationTransaction.Status = 
                    evaluation.Status == AnticipationEvaluateStatus.Approved ? Status.Approved : Status.Reproved;

            if(anticipationTransaction.Status == Status.Approved)
                _installmentService.UpdateInstallmentAfterAnticipation(anticipationTransaction.TransactionNsu);

            anticipation.AntecipatedValue = _context.Installments.SumAntecipatedValue(anticipationTransaction.TransactionNsu);

            anticipation.Status = _context.AnticipationTransactions.StatusById(anticipation.Id);

            _context.AnticipationTransactions.Update(anticipationTransaction);
            _context.Anticipations.Update(anticipation);
            
            _context.SaveChanges();
        }
    }
}
