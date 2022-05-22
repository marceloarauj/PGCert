namespace api.Models.EntityModel
{
    public static class AnticipationQuery
    {
        public static IQueryable<Anticipation> WhereIsPending(this IQueryable<Anticipation> anticipations)
        {
            return anticipations.Where(anticipation => anticipation.StartAnalysisDate == null);
        }

        public static bool ExistsById(this IQueryable<Anticipation> anticipations, int id)
        {
            return anticipations.Any(anticipation => anticipation.Id == id);
        }

        public static bool IsPendingById(this IQueryable<Anticipation> anticipations, int id)
        {
            return anticipations.Any(anticipation => anticipation.StartAnalysisDate == null && anticipation.Id == id);
        }

        public static bool WhereNotExistOrNotIsPending(this IQueryable<Anticipation> anticipations, int id)
        {
            return (!anticipations.ExistsById(id) || !anticipations.IsPendingById(id));
        }
    }
}
