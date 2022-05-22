using api.Models.EntityModel;

namespace api.Models.ServiceModel
{
    public class InstallmentService
    {
        private readonly AppDbContext _context;

        public InstallmentService(AppDbContext context)
        {
            _context = context;
        }

        public void CreateInstallments(Transaction transaction)
        {
            var installmentNetValue = transaction.NetValue / transaction.InstallmentsNumber;
            var installmentBruteValue = transaction.BruteValue / transaction.InstallmentsNumber;

            for(int i = 1; i <= transaction.InstallmentsNumber; i++)
            {
                var installment = new Installment
                {
                    Transaction = transaction,
                    Nsu = transaction.Nsu,
                    NetValue = installmentNetValue,
                    BruteValue = installmentBruteValue,
                    InstallmentNumber = i,
                    Receivement = transaction.Date.AddDays(30 * i)
                };

                _context.Installments.Add(installment);
            }
        }

        public void UpdateInstallmentAfterAnticipation(string nsu)
        {
            var installments = _context.Installments.Where(installment => installment.Nsu == nsu);

            foreach(var installment in installments)
            {
                installment.AntecipatedValue = installment.NetValue - (installment.NetValue * 0.038M);
                installment.PassedOn = DateTime.Now;
            }

            _context.UpdateRange(installments);
        }
    }
}
