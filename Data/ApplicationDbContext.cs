using Microsoft.EntityFrameworkCore;
using Defteria.API.Models;

namespace Defteria.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<TopUp> TopUps => Set<TopUp>();
        public DbSet<QrPayment> QrPayments => Set<QrPayment>();
        public DbSet<Transaction> Transactions => Set<Transaction>();
    }
}
