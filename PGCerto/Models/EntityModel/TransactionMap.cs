using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Models.EntityModel
{
    public static class TransactionMap
    {
        public static void Map(this EntityTypeBuilder<Transaction> entity)
        {
            entity.ToTable(nameof(Transaction));

            entity.HasKey(transaction => transaction.Nsu);
            entity.Property(transaction => transaction.Nsu).ValueGeneratedNever();

            entity.Property(transaction => transaction.Date).HasColumnName("DataTransacao");
            entity.Property(transaction => transaction.Approval).HasColumnName("DataAprovacao");
            entity.Property(transaction => transaction.Disapproval).HasColumnName("DataReprovacao");
            entity.Property(transaction => transaction.Anticipation).HasColumnName("Antecipado");
            entity.Property(transaction => transaction.AcquirerConfirmation).HasColumnName("ConfirmacaoAdquirinte");
            entity.Property(transaction => transaction.BruteValue).HasColumnName("ValorBruto");
            entity.Property(transaction => transaction.NetValue).HasColumnName("ValorLiquido");
            entity.Property(transaction => transaction.FixedRate).HasColumnName("TaxaFixa");
            entity.Property(transaction => transaction.InstallmentsNumber).HasColumnName("NumeroParcelas");
            entity.Property(transaction => transaction.CreditCardLastNumbers).HasColumnName("UltimosDigitosCartao");


            entity.HasMany(transaction => transaction.Installments)
                  .WithOne(installment => installment.Transaction)
                  .HasForeignKey(installment => installment.Nsu);
        }
    }
}
