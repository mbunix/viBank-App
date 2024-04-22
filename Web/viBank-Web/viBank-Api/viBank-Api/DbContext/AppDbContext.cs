using Microsoft.EntityFrameworkCore;
using viBank_Api.Models;

namespace viBank_Api
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }
        public DbSet<UserModel> User { get; set;}
        public DbSet<Account> account {  get; set;}
        public DbSet<Transactions> Transactions { get; set;}
        public DbSet<ATMs> ATMs { get; set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Add your entity configurations here
            modelBuilder.Entity<Transactions>(entity =>
            {
                entity.Property(e => e.ID).ValueGeneratedOnAdd();
                entity.Property(e => e.TransactionDate).HasColumnType("datetime2");
                entity.Property(e => e.Amount).HasColumnType("float");
                entity.Property(e => e.OriginAccountNumber).HasColumnType("nvarchar(max)");
                entity.Property(e => e.DestinationAccountNumber).HasColumnType("nvarchar(max)");
                entity.Property(e => e.transactionType).HasColumnType("int");

                //// Add foreign key relationships for transfer 
                //entity.HasOne(e => e.OriginAccountNumber)
                //    .WithMany()
                //    .HasForeignKey(e => e.AccountID)
                //    .OnDelete(DeleteBehavior.Restrict); 

                //entity.HasOne(e => e.DestinationAccountNumber)
                //    .WithMany()
                //    .HasForeignKey(e => e.AccountID)
                //    .OnDelete(DeleteBehavior.Restrict);
                //// Add foreign key relationship for ATM
                //entity.HasOne(e => e.ATMs)
                //    .WithMany()
                //    .HasForeignKey(e => e.ATMID)
                //    .OnDelete(DeleteBehavior.Restrict);


            });

            
        }
    }
}
