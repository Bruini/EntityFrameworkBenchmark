using EFCore.Mappings;
using EFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore
{
    public class EFCoreContext : DbContext
    {
        public EFCoreContext(DbContextOptions<EFCoreContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserDBMapping());
        }
    }
}
