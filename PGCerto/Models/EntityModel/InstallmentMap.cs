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

            entity.HasOne(installment => installment.Transaction)
                  .WithMany(transaction => transaction.Installments)
                  .HasForeignKey(installment => installment.NSU);
        }
    }
}
