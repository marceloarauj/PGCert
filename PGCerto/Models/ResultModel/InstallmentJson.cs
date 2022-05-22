using api.Models.EntityModel;

namespace api.Models.ResultModel
{
    public class InstallmentJson
    {
        public InstallmentJson(Installment installment)
        {
            Id = installment.Id;
            BruteValue = installment.BruteValue;
            NetValue = installment.NetValue;
            InstallmentNumber = installment.InstallmentNumber;
            AntecipatedValue = installment.AntecipatedValue;
            Receivement = installment.Receivement;
            PassedOn = installment.PassedOn;
        }
        public int Id { get; set; }
        public decimal BruteValue { get; set; }
        public decimal NetValue { get; set; }
        public int InstallmentNumber { get; set; }
        public decimal? AntecipatedValue { get; set; }
        public DateTime Receivement { get; set; }
        public DateTime? PassedOn { get; set; }
    }
}
