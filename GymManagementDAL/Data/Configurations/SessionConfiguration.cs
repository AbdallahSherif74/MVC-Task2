using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymManagementDAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace GymManagementDAL.Data.Configurations
{
    internal class SessionConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Session> builder)
        {
            builder.ToTable(tb =>
            {
                tb.HasCheckConstraint("CK_Session_SessionCapacityCheck", "Capacity Between 1 and 25");
                tb.HasCheckConstraint("CK_Session_StartBeforeEnd", "EndDate > StartDate");
            });

            builder.HasOne(X=>X.SessionCategory)
                   .WithMany(cat => cat.Sessions)
                   .HasForeignKey(X=>X.CategoryID)
                   .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(X=>X.SessionTrainer)
                .WithMany(tr => tr.Sessions)
                     .HasForeignKey(X=>X.TrainerID)
                     .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
