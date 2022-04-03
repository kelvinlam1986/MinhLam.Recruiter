using MinhLam.Recruiter.Domain;
using System;
using System.Data.Entity.ModelConfiguration;

namespace MinhLam.Recruiter.Infrastructure.DbConfiguration
{
    public class SalesPackageDetailConfiguration : EntityTypeConfiguration<SalesPackageDetail>
    {
        public SalesPackageDetailConfiguration()
        {
            this.ToTable("SalesPackageDetails");
            this.HasKey<Guid>(x => x.Id);

            this.Property(x => x.PackageName)
                .IsRequired()
                .HasColumnType("nvarchar");

            this.Property(x => x.PackageQuantity)
                .IsRequired();

            this.Property(x => x.PackagePrice)
               .IsRequired();

            this.Property(x => x.PackageType)
              .IsRequired();
        }
    }
}
