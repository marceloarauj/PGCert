using System.ComponentModel.DataAnnotations;

namespace api.Models.EntityModel
{
    public class Transaction
    {
        [Key]
        public string NSU { get; set; }
        public DateTime Date { get; set; }
        public DateTime? Approval { get; set; }
        public DateTime Disapproval { get; set; }
        public bool Anticipation { get; set; }
        //public Status AcquirerConfirmation { get; set; }
        public decimal BruteValue { get; set; }
        public decimal NetValue { get; set; }
        public decimal FixedRate { get; set; }
        public int Installments { get; set; }
        public string CreditCardLastNumbers { get; set; }
    }

    //public enum Status
    //{
    //    Approved, Disapproved
    //}
}
