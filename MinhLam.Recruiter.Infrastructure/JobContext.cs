using MinhLam.Recruiter.Domain;
using MinhLam.Recruiter.Infrastructure.DbConfiguration;
using System.Data.Entity;

namespace MinhLam.Recruiter.Infrastructure
{
    public class JobContext : DbContext
    {
        public JobContext() : base("name=Job")
        {

        }

        public DbSet<RCAccount> RCAccounts { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<JobCategory> JobCategories { get; set; }
        public DbSet<JobIndustry> JobIndustries { get; set; }
        public DbSet<JSCertificate> JSCertificates { get; set; }
        public DbSet<ExperienceLevel> ExperienceLevels { get; set; }
        public DbSet<WorkingType> WorkingTypes { get; set; }
        public DbSet<RCFolder> RCFolders { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new RCAccountConfiguration());
            modelBuilder.Configurations.Add(new ProvinceConfiguration());
            modelBuilder.Configurations.Add(new JobCategoryConfiguration());
            modelBuilder.Configurations.Add(new JobIndustryConfiguration());
            modelBuilder.Configurations.Add(new JSCertificateConfiguration());
            modelBuilder.Configurations.Add(new ExperienceLevelConfiguration());
            modelBuilder.Configurations.Add(new WorkingTypeConfiguration());
            modelBuilder.Configurations.Add(new RCFolderConfiguration());
        }
    }
}
