using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Models.EntityModel
{
    public static class AnticipationMap
    {
        public static void Map(this EntityTypeBuilder<Anticipation> entity)
        {
            entity.ToTable(nameof(Anticipation));

            entity.HasKey(anticipation => anticipation.Id);
            entity.Property(anticipation => anticipation.Id).ValueGeneratedOnAdd();

            entity.Property(anticipation => anticipation.RequestedValue).HasColumnName("ValorSolicitado");
            entity.Property(anticipation => anticipation.AntecipatedValue).HasColumnName("ValorAntecipado");
            entity.Property(anticipation => anticipation.StartAnalysisDate).HasColumnName("DataInicioAnalise");
            entity.Property(anticipation => anticipation.FinishedAnalysisDate).HasColumnName("DataFimAnalise");
            entity.Property(anticipation => anticipation.SolicitationDate).HasColumnName("DataSolicitacao");

            entity.HasMany(anticipation => anticipation.AnticipationTransactions)
                  .WithOne(transaction => transaction.Anticipation)
                  .HasForeignKey(transaction => transaction.AnticipationId);
        }
    }
}
