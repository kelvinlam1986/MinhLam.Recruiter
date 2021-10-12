namespace MinhLam.Recruiter.Infrastructure.Configuration
{
    public interface IApplicationSettings
    {
        string ConnectionString { get; }
        string SiteEmail { get; }
    }
}
