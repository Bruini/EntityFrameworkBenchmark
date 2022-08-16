using EFCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Mappings
{
    internal class UserDBMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.UserId);
            builder.HasIndex(u => u.Name);

            builder.Property(u => u.UserId)
                .HasColumnName("UserId")
                .IsRequired();

            builder.Property(u => u.Name)
                .HasColumnName("Name")
                .HasColumnType("varchar")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(u => u.Birthday)
                .HasColumnName("Birthday")
                .IsRequired();
        }
    }
}
