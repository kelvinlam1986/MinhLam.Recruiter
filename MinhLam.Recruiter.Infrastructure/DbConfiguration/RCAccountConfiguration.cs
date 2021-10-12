using MinhLam.Recruiter.Domain;
using System;
using System.Data.Entity.ModelConfiguration;

namespace MinhLam.Recruiter.Infrastructure.DbConfiguration
{
    public class RCAccountConfiguration : EntityTypeConfiguration<RCAccount>
    {
        public RCAccountConfiguration()
        {
            this.ToTable("RCAccounts");
            this.HasKey<Guid>(x => x.Id);

            this.Property(x => x.Email)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(50);

            this.Property(x => x.Password)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(200);

            this.Property(x => x.CompanyName)
                .HasColumnType("nvarchar")
                .HasMaxLength(50);

            this.Property(x => x.EnglishName)
              .HasColumnType("varchar")
              .HasMaxLength(50);

            this.Property(x => x.AccountType).IsRequired();
            this.Property(x => x.Newsletter).IsRequired();
            this.Property(x => x.ResumeAlert).IsRequired();
            this.Property(x => x.Promotion).IsRequired();
            this.Property(x => x.Logo).IsRequired();
            this.Property(x => x.JobPostingBalance).IsRequired();
            this.Property(x => x.ResumeViewingBalance).IsRequired();
            this.Property(x => x.Activate).IsRequired();
            this.Property(x => x.Agency).IsRequired();
            this.Property(x => x.AvailableForPosting).IsRequired();
            this.Property(x => x.AvailableForViewing).IsRequired();
            this.Property(x => x.RegisterDate).IsRequired();
            this.Property(x => x.LastLogin).IsOptional();
            this.Property(x => x.HitViewed).IsRequired();
            this.Property(x => x.DefaultLanguage).IsRequired();
            this.Property(x => x.Contact).HasColumnType("nvarchar").HasMaxLength(50).IsOptional();
            this.Property(x => x.Address).HasColumnType("nvarchar").HasMaxLength(50).IsOptional();
            this.Property(x => x.Country).HasColumnType("nvarchar").HasMaxLength(30).IsOptional();
            this.Property(x => x.Tel).HasColumnType("varchar").HasMaxLength(20).IsOptional();
            this.Property(x => x.Fax).HasColumnType("varchar").HasMaxLength(20).IsOptional();
            this.Property(x => x.City).HasColumnType("nvarchar").HasMaxLength(50).IsOptional();
            this.Property(x => x.OpenDate).IsOptional();
            this.Property(x => x.ProvinceId).IsOptional();
        }
    }
}
