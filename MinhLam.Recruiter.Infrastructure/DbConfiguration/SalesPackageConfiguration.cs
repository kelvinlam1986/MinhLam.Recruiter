using MinhLam.Recruiter.Domain;
using System;
using System.Data.Entity.ModelConfiguration;

namespace MinhLam.Recruiter.Infrastructure.DbConfiguration
{
    public class SalesPackageConfiguration : EntityTypeConfiguration<SalesPackage>
    {
        public SalesPackageConfiguration()
        {
            this.ToTable("SalesPackages");
            this.HasKey<Guid>(x => x.Id);

            this.Property(x => x.ContactName)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(100);

            this.Property(x => x.OrderDate)
                .IsRequired();

            this.Property(x => x.PaymentCurrency)
               .IsOptional()
               .HasColumnType("char")
               .HasMaxLength(3);

            this.Property(x => x.PaymentCurrency)
              .IsOptional()
              .HasColumnType("nvarchar")
              .HasMaxLength(50);

            this.Property(x => x.RecruiterId).IsRequired();

            this.Property(x => x.PaidStatus)
              .IsOptional();

            this.Property(x => x.PaidDate)
             .IsOptional();
        }
    }
}
