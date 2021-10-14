using MinhLam.Recruiter.Domain;
using System;
using System.Data.Entity.ModelConfiguration;

namespace MinhLam.Recruiter.Infrastructure.DbConfiguration
{
    public class TemplateConfiguration : EntityTypeConfiguration<Template>
    {
        public TemplateConfiguration()
        {
            this.ToTable("Templates");
            this.HasKey<Guid>(x => x.Id);

            this.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(50);
        }
    }
}
