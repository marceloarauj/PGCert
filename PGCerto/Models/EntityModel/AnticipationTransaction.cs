namespace api.Models.EntityModel
{
    public class AnticipationTransaction
    {
        public int Id { get; set; }
        public Anticipation Anticipation { get; set; }
        public int AnticipationId { get; set; }
        public string TransactionNsu { get; set; }
        public Status? Status { get; set; }
    }
}
