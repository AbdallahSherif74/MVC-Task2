using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymManagementDAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManagementDAL.Data.Configurations
{
    internal class GymUserConfiguration<T> : IEntityTypeConfiguration<T> where T : GymUser
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(X=> X.Name)
                .HasColumnType("varchar")
                .HasMaxLength(50);

            builder.Property(X=> X.Email)
                .HasColumnType("varchar")
                .HasMaxLength(100);

            builder.Property(X => X.Phone)
               .HasColumnType("varchar")
               .HasMaxLength(11);

            builder.ToTable(Tb =>
            {
                Tb.HasCheckConstraint("CK_GymUser_ValidEmailCheck", "Email Like '_%@_%._%'");

            });
            builder.ToTable(Tb =>
            {
                Tb.HasCheckConstraint("CK_GymUser_PhoneCheck", "Phone Like '01%' and Phone Not like '%[^0-9]%' ");

            });

            builder.HasIndex(X=> X.Email)
                .IsUnique();
            builder.HasIndex(X => X.Phone)
                .IsUnique();

            builder.OwnsOne(X => X.Address, addressBuilder =>
            {
                addressBuilder.Property(a => a.BuildingNumber)
                    .HasColumnName("BuildingNumber")
                    .HasColumnType("int");
                addressBuilder.Property(a => a.City)
                  .HasColumnName("City")
                    .HasColumnType("varchar")
                    .HasMaxLength(30);
                addressBuilder.Property(a => a.Street)
                    .HasColumnName("Street")
                    .HasColumnType("varchar")
                    .HasMaxLength(100);
            });

        }

      
    }
}
