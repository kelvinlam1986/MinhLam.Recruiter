using MinhLam.Recruiter.Domain;
using System;
using System.Data.Entity.ModelConfiguration;

namespace MinhLam.Recruiter.Infrastructure.DbConfiguration
{
    public class ExperienceLevelConfiguration : EntityTypeConfiguration<ExperienceLevel>
    {
        public ExperienceLevelConfiguration()
        {
            this.ToTable("ExperienceLevels");
            this.HasKey<Guid>(x => x.Id);

            this.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(50);
        }
    }
}
