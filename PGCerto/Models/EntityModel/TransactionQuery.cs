namespace api.Models.EntityModel
{
    public static class TransactionQuery
    {
        public static Transaction? WhereId(this IQueryable<Transaction> transactions, string nsu)
        {
            return transactions.Where(transaction => transaction.Nsu == nsu).FirstOrDefault();
        }

        public static bool NsuExists(this IQueryable<Transaction> transactions, string nsu)
        {
            return transactions.Where(transaction => transaction.Nsu == nsu).FirstOrDefault() != null;
        }

        public static IQueryable<Transaction> WhereNotStarted(this IQueryable<Transaction> transactions)
        {
            return transactions.Where(transaction => transaction.Anticipation == null && transaction.AcquirerConfirmation == Status.Approved);
        }

        public static IQueryable<Transaction> WhereInValues(this IQueryable<Transaction> transactions, List<string> transactionCodes)
        {
            return transactions.Where(transaction => transactionCodes.Contains(transaction.Nsu) && transaction.AcquirerConfirmation == Status.Approved);
        }

        public static decimal SumNetValues(this IQueryable<Transaction> transactions)
        {
            return transactions.Sum(transaction => transaction.NetValue);
        }
    }
}
