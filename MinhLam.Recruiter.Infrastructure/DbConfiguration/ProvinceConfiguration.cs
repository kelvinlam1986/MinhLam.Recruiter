using MinhLam.Recruiter.Domain;
using System;
using System.Data.Entity.ModelConfiguration;

namespace MinhLam.Recruiter.Infrastructure.DbConfiguration
{
    public class ProvinceConfiguration : EntityTypeConfiguration<Province>
    {
        public ProvinceConfiguration()
        {
            this.ToTable("Provinces");
            this.HasKey<Guid>(x => x.Id);

            this.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(50);

            this.Property(x => x.Area)
                .HasColumnType("nvarchar")
                .HasMaxLength(50);

            this.Property(x => x.Country)
                .HasColumnType("nvarchar")
                .HasMaxLength(50);
        }
    }
}
