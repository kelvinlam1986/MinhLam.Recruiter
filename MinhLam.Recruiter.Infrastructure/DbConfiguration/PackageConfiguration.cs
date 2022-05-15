using MinhLam.Recruiter.Domain;
using System;
using System.Data.Entity.ModelConfiguration;

namespace MinhLam.Recruiter.Infrastructure.DbConfiguration
{
    public class PackageConfiguration : EntityTypeConfiguration<Package>
    {
        public PackageConfiguration()
        {
            this.ToTable("Packages");
            this.HasKey<Guid>(x => x.Id);

            this.Property(x => x.StartDate)
                .IsOptional();

            this.Property(x => x.EndDate)
              .IsOptional();

            this.Property(x => x.Program)
                .HasColumnType("nvarchar")
                .HasMaxLength(50);

            this.Property(x => x.Name)
                .HasColumnType("nvarchar")
                .HasMaxLength(100);

            this.Property(x => x.MinQuantity)
                .IsOptional();

            this.Property(x => x.MaxQuantity)
               .IsOptional();

            this.Property(x => x.Price)
               .IsOptional();

            this.Property(x => x.Discount)
               .IsOptional();

            this.Property(x => x.Currency)
                .HasColumnType("char")
                .HasMaxLength(3)
                .IsOptional();

            this.Property(x => x.Type)
               .IsOptional();

            this.Property(x => x.Activate)
                .IsOptional();

            this.Property(x => x.EntryDate)
               .IsOptional();
        }
    }
}
