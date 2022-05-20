namespace api.Models.EntityModel
{
    public class Installment
    {
        public int Id { get; set; }
        public string NSU { get; set; }
        public Transaction Transaction { get; set; }
        public decimal BruteValue { get; set; }
        public decimal NetValue { get; set; }
        public int InstallmentNumber { get; set; }
        public decimal? AntecipatedValue { get; set; }
        public DateTime Receivement { get; set; }
        public DateTime? PassedOn { get; set; }
    }

}
