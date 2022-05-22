namespace api.Models.EntityModel
{
    public static class AnticipationTransactionQuery
    {
        public static bool WhereExistsRange(this IQueryable<AnticipationTransaction> anticipationTransactions, List<string> transactions)
        {
            if(anticipationTransactions == null || !anticipationTransactions.Any())
                return false;

            return anticipationTransactions.Any(anticipationTransaction => transactions.Contains(anticipationTransaction.TransactionNsu));
        }

    }
}
