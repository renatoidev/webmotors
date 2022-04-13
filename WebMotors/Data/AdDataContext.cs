using Microsoft.EntityFrameworkCore;
using WebMotors.Models;

namespace WebMotors.Data
{
    public class AdDataContext : DbContext
    {
        public AdDataContext(DbContextOptions<AdDataContext> options) : base(options) { }
        public DbSet<Ad> Ads { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
