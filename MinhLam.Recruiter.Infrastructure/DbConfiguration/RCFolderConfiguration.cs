using MinhLam.Recruiter.Domain;
using System;
using System.Data.Entity.ModelConfiguration;

namespace MinhLam.Recruiter.Infrastructure.DbConfiguration
{
    public class RCFolderConfiguration : EntityTypeConfiguration<RCFolder>
    {
        public RCFolderConfiguration()
        {
            this.ToTable("RCFolders");
            this.HasKey<Guid>(x => x.Id);

            this.Property(x => x.FolderName)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(50);
            this.Property(x => x.FolderDescription)
                .IsOptional()
                .HasColumnType("nvarchar")
                .HasMaxLength(100);
            this.Property(x => x.FolderManager)
               .IsOptional()
               .HasColumnType("nvarchar")
               .HasMaxLength(50);
            this.Property(x => x.RecruiterId).IsRequired();
        }
    }
}
