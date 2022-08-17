using EF6.Mappings;
using EF6.Models;
using MySql.Data.EntityFramework;
using System.Data.Entity;

namespace EF6
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class EF6Context : DbContext
    {
        public EF6Context(string connection) : base(connection)
        {

        }

        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserDBMapping());
        }
    }
}
