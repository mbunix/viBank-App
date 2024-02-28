using Microsoft.EntityFrameworkCore;
using viBank_Api.Models;

namespace viBank_Api
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }
        public DbSet<UserModel> User { get; set; }
    }
}
