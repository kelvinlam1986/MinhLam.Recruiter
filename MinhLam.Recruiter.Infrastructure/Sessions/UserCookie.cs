namespace MinhLam.Recruiter.Infrastructure.Sessions
{
    public class UserCookie : IUserCookie
    {
        private IWebContext webContext;

        public UserCookie(IWebContext webContext)
        {
            this.webContext = webContext;
        }

        public bool RCRemember 
        {
            get { return this.webContext.RCRemember; }
            set { this.webContext.RCRemember = value; }
        }

        public string RCRememberEmail
        {
            get { return this.webContext.RCRememberEmail; }
            set { this.webContext.RCRememberEmail = value; }
        }

        public string RCTime
        {
            get { return this.webContext.RCTime; }
            set { this.webContext.RCTime = value; }
        }
    }
}
