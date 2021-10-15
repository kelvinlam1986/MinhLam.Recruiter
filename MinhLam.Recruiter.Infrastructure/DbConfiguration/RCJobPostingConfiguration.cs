using MinhLam.Recruiter.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhLam.Recruiter.Infrastructure.DbConfiguration
{
    public class RCJobPostingConfiguration : EntityTypeConfiguration<RCJobPosting>
    {
        public RCJobPostingConfiguration()
        {
            this.ToTable("RCJobPostings");
            this.HasKey<Guid>(x => x.Id);
            this.Property(x => x.JobTitle)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(100);
            this.Property(x => x.JobNo)
                .IsOptional()
                .HasColumnType("varchar")
                .HasMaxLength(10);
            this.Property(x => x.RequiredNumber)
                .IsRequired();
            this.Property(x => x.JobSummary)
                .IsRequired()
                .HasColumnType("ntext");
            this.Property(x => x.WorkingTypeId)
                .IsRequired();
            this.Property(x => x.ExperienceLevelId)
                .IsRequired();
            this.Property(x => x.YearExperience)
                .IsOptional();
            this.Property(x => x.RangeOfAge)
                .IsOptional()
                .HasColumnType("nvarchar")
                .HasMaxLength(50);
            this.Property(x => x.RecruitmentType)
              .IsOptional()
              .HasColumnType("nvarchar")
              .HasMaxLength(50);
            this.Property(x => x.SalaryFrom)
                .IsOptional();
            this.Property(x => x.SalaryTo)
                .IsOptional();
            this.Property(x => x.Currency)
                .IsOptional()
                .HasColumnType("char")
                .HasMaxLength(3);
            this.Property(x => x.ShowSalary)
                .IsRequired();
            this.Property(x => x.SalaryNegotive)
                .IsRequired();
            this.Property(x => x.ClosedDate)
                .IsRequired();
            this.Property(x => x.CompanyLogo)
                .IsRequired();
            this.Property(x => x.AdvName)
                .IsOptional()
                .HasColumnType("nvarchar")
                .HasMaxLength(1000);
            this.Property(x => x.JobSkill)
                .IsOptional()
                .HasColumnType("ntext");
            this.Property(x => x.JobIndustryId)
                .IsRequired();
            this.Property(x => x.JobCategoryId)
                .IsRequired();
            this.Property(x => x.CertificateId)
                .IsRequired();
            this.Property(x => x.WorkLocation)
                .IsOptional()
                .HasColumnType("nvarchar")
                .HasMaxLength(100);
            this.Property(x => x.ProvinceId)
                .IsOptional();
            this.Property(x => x.TemplateId)
                .IsRequired();
            this.Property(x => x.FolderId)
                .IsOptional();
            this.Property(x => x.EnableApplyOnline)
                 .IsRequired();
            this.Property(x => x.OnlyApplyUrl)
                .IsOptional()
                .HasColumnType("varchar")
                .HasMaxLength(100);
            this.Property(x => x.ContactEmail)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(50);
            this.Property(x => x.ContactPerson)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(50);
            this.Property(x => x.ContactTel)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(10);
            this.Property(x => x.ViewedNo)
                .IsOptional();
            this.Property(x => x.PostedDate)
                .IsRequired();
            this.Property(x => x.UpdatedDate)
                .IsRequired();
            this.Property(x => x.Activate)
              .IsRequired();
        }
    }
}
