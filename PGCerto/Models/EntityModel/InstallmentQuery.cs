namespace api.Models.EntityModel
{
    public static class InstallmentQuery
    {
        public static IQueryable<Installment> WhereNsu(this IQueryable<Installment> installments, string nsu)
        {
            return installments.Where(installment => installment.Nsu == nsu);
        }

        public static decimal SumAntecipatedValue(this IQueryable<Installment> installments, string nsu)
        {
            return installments
                .Where(installment => installment.Nsu == nsu)
                .Sum(installment => installment.AntecipatedValue ?? 0);
        }
    }
}
