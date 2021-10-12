using System.Configuration;

namespace MinhLam.Recruiter.Infrastructure.Configuration
{
    public class WebConfigApplicationSettings : IApplicationSettings
    {
        public string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["Timviecnhanh"].ConnectionString;
            }
        }

        public string SiteEmail
        {
            get
            {
                return ConfigurationManager.AppSettings["SiteEmail"];
            }
        }
    }
}
