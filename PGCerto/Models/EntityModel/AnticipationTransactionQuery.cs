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

        public static AnticipationStatus? StatusById(this IQueryable<AnticipationTransaction> anticipationTransactions, int id, AnticipationTransaction actual)
        {
            var transactions = anticipationTransactions
                                    .Where(anticipationTransactions => anticipationTransactions.AnticipationId == id);

            var existTransactionNotEvaluated = transactions.Any(transaction => transaction.Status == null && actual.TransactionNsu != transaction.TransactionNsu);

            if (existTransactionNotEvaluated)
                return null;

            var existReprovedTransaction = transactions.Any(transaction => transaction.Status == Status.Reproved);
            var existApprovedTransaction = transactions.Any(transaction => transaction.Status == Status.Approved);

            if (existApprovedTransaction && !existReprovedTransaction) return AnticipationStatus.Approved;
            if (!existApprovedTransaction && existReprovedTransaction) return AnticipationStatus.Reproved;

            return AnticipationStatus.PartiallyApproved;
        }
    }
}
