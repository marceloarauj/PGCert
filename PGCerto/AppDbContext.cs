using api.Models.EntityModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) {}

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Installment> Installments { get; set; }
        public DbSet<Anticipation> Anticipations { get; set; }
        public DbSet<AnticipationTransaction> AnticipationTransactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Installment>().Map();
            modelBuilder.Entity<Transaction>().Map();
            modelBuilder.Entity<Anticipation>().Map();
            modelBuilder.Entity<AnticipationTransaction>().Map();
        }
    }
}
