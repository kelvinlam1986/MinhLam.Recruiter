namespace MinhLam.Recruiter.Application.Commands
{
    public class RCRegisterAccountCommand
    {
        public RCRegisterAccountCommand(
            string email,
            string purePassword,
            string companyName,
            string englishName,
            bool accountType,
            bool newsletter,
            bool resumeAlert,
            bool promotion)
        {
            this.Email = email;
            this.PurePassword = purePassword;
            this.CompanyName = companyName;
            this.EnglishName = englishName;
            this.AccountType = accountType;
            this.Newsletter = newsletter;
            this.ResumeAlert = resumeAlert;
            this.Promotion = promotion;
        }

        public string Email { get; set; }
        public string PurePassword { get; set; }
        public string CompanyName { get; set; }
        public string EnglishName { get; set; }
        public bool AccountType { get; set; }
        public bool Newsletter { get; set; }
        public bool ResumeAlert { get; set; }
        public bool Promotion { get; set; }
    }
}
