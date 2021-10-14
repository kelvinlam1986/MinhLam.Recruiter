using MinhLam.Recruiter.Domain;
using System;
using System.Data.Entity.ModelConfiguration;

namespace MinhLam.Recruiter.Infrastructure.DbConfiguration
{
    public class JobCategoryConfiguration : EntityTypeConfiguration<JobCategory>
    {
        public JobCategoryConfiguration()
        {
            this.ToTable("JobCategory");
            this.HasKey<Guid>(x => x.Id);

            this.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(50);

            this.Property(x => x.JobNumber)
               .IsOptional();
        }
    }
}
