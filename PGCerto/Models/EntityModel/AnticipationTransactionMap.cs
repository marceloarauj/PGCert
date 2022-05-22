using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Models.EntityModel
{
    public static class AnticipationTransactionMap
    {
        public static void Map(this EntityTypeBuilder<AnticipationTransaction> entity)
        {
            entity.ToTable(nameof(AnticipationTransaction));

            entity.HasKey(anticipationTransaction => anticipationTransaction.Id);
            entity.Property(anticipationTransaction => anticipationTransaction.Id).ValueGeneratedOnAdd();

            entity.Property(anticipationTransaction => anticipationTransaction.AnticipationId).HasColumnName("AntecipacaoId");
            entity.Property(anticipationTransaction => anticipationTransaction.TransactionNsu).HasColumnName("Nsu");

            entity.HasOne(anticipationTransaction => anticipationTransaction.Anticipation)
                  .WithMany(anticipation => anticipation.AnticipationTransactions);        
        }
    }
}
