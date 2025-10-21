using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymManagementDAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace GymManagementDAL.Data.Configurations
{
    internal class HealthRecordConfiguration : IEntityTypeConfiguration<HealthRecord>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<HealthRecord> builder)
        {
            builder.ToTable("Members").HasKey(x=>x.Id);
            builder.HasOne<Member>()
                   .WithOne(m => m.HealthRecord)
                   .HasForeignKey<HealthRecord>(hr => hr.Id)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Ignore(X => X.CreatedAt);
            builder.Ignore(X => X.UpdatedAt);   

        }
    }
}
