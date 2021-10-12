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
        // public DbSet<RCJobPosting> RCJobPostings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new RCAccountConfiguration());
            modelBuilder.Configurations.Add(new ProvinceConfiguration());
        }
    }
}
