﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymManagementDAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace GymManagementDAL.Data.Configurations
{
    internal class PlanConfiguration : IEntityTypeConfiguration<Plan>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Plan> builder)
        {
            builder.Property(X => X.Name)
               .HasColumnType("varchar")
               .HasMaxLength(50);
            builder.Property(X => X.Description)
              .HasColumnType("varchar")
              .HasMaxLength(200);
            builder.Property(X => X.Price).HasPrecision(10,2);

            builder.ToTable(tb =>
            {
                tb.HasCheckConstraint("CK_Plan_Price_NonNegative", "Price >= 0");
                tb.HasCheckConstraint("CK_Plan_DurationDays_Positive", "DurationDays > 0");
                tb.HasCheckConstraint("CK_Plan_DurationDayse", "DurationDays between 1 and 365");


            });

        }
    }
}
