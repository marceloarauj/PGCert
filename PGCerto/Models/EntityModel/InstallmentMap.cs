using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Models.EntityModel
{
    public static class InstallmentMap
    {
        public static void Map(this EntityTypeBuilder<Installment> entity)
        {
            entity.ToTable(nameof(Installment));

            entity.HasKey(installment => installment.Id);
            entity.Property(installment => installment.Id).ValueGeneratedOnAdd();

            entity.Property(installment => installment.BruteValue).HasColumnName("ValorBruto");
            entity.Property(installment => installment.NetValue).HasColumnName("ValorLiquido");
            entity.Property(installment => installment.Receivement).HasColumnName("DataRecebimento");
            entity.Property(installment => installment.InstallmentNumber).HasColumnName("NumeroParcela");
            entity.Property(installment => installment.PassedOn).HasColumnName("DataRepasse");
            entity.Property(installment => installment.AntecipatedValue).HasColumnName("ValorAntecipado");

            entity.HasOne(installment => installment.Transaction)
                  .WithMany(transaction => transaction.Installments)
                  .HasForeignKey(installment => installment.Nsu);
        }
    }
}
