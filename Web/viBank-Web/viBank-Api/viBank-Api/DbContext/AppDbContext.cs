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
    }
}
