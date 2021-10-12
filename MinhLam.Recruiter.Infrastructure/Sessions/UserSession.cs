using System;

namespace MinhLam.Recruiter.Infrastructure.Sessions
{
    public class UserSession : IUserSession
    {
        private IWebContext webContext;

        public UserSession(IWebContext webContext)
        {
            this.webContext = webContext;
        }

        public Guid RCUserId 
        {
            get { return this.webContext.RCUserId; }
            set { this.webContext.RCUserId = value; }
        }

        public string RCEmail 
        { 
            get { return this.webContext.RCEmail; }
            set { this.webContext.RCEmail = value; }
        }

        public string RCCompanyName
        {
            get { return this.webContext.RCCompanyName; }
            set { this.webContext.RCCompanyName = value; }
        }

        public bool RCJobFree
        {
            get { return this.webContext.RCJobFree; }
            set { this.webContext.RCJobFree = value; }
        }

        public bool RCActive
        {
            get { return this.webContext.RCActive; }
            set { this.webContext.RCActive = value; }
        }

        public int RCLoginAttempts
        {
            get { return this.webContext.RCLoginAttempts; }
            set { this.webContext.RCLoginAttempts = value; }
        }
    }
}
