namespace api.Models.EntityModel
{
    public static class InstallmentQuery
    {
        public static IQueryable<Installment> WhereNsu(this IQueryable<Installment> installments, string nsu)
        {
            return installments.Where(installment => installment.Nsu == nsu);
        }
    }
}
