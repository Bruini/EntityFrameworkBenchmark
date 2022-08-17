using EF6.Models;
using System.Data.Entity.ModelConfiguration;

namespace EF6.Mappings
{
    internal class UserDBMapping : EntityTypeConfiguration<User>
    {
        public UserDBMapping()
        {
            this.ToTable("Users");

            this.HasKey(u => u.UserId);
            this.HasIndex(u => u.Name);

            this.Property(u => u.UserId)
                .HasColumnName("UserId")
                .IsRequired();

            this.Property(u => u.Name)
                .HasColumnName("Name")
                .HasColumnType("varchar")
                .HasMaxLength(255)
                .IsRequired();

            this.Property(u => u.Birthday)
                .HasColumnName("Birthday")
                .IsRequired();
        }
    }
}
