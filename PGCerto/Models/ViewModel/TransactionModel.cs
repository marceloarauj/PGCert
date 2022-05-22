
using api.Models.EntityModel;
using api.Models.Validations;

namespace api.Models.ViewModel
{
    public class TransactionModel
    {
        [JsonRequired]
        public string Nsu { get; set; }

        [JsonRequired]
        [JsonInstallmentValue]
        public decimal Value { get; set; }

        [JsonRequired]
        [JsonInstallmentNumber]
        public int InstallmentsNumber { get; set; }

        [JsonRequired]
        [JsonCreditCard]
        public string CreditCardNumber { get; set; }

        public Transaction Map() => new Transaction
        {
            Nsu = Nsu,
            BruteValue = Value,
            NetValue = Value,
            InstallmentsNumber = InstallmentsNumber,
            Date = DateTime.Now,
            FixedRate = 0.9M
        };
    }
}
