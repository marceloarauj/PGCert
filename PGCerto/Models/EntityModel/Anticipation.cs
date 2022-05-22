namespace api.Models.EntityModel
{
    public class Anticipation
    {
        public int Id { get; set; }
        public DateTime SolicitationDate { get; set; }
        public DateTime? StartAnalysisDate { get; set; }
        public DateTime? FinishedAnalysisDate { get; set; }
        public AnticipationStatus? Status { get; set; }
        public decimal RequestedValue { get; set; }
        public decimal AntecipatedValue { get; set; }
        public List<AnticipationTransaction> AnticipationTransactions { get; set; }
    }

    public enum AnticipationStatus
    {
        Approved = 1,
        PartiallyApproved = 2,
        Reproved = 3
    }
}
