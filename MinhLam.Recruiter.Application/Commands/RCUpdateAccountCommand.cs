using System;

namespace MinhLam.Recruiter.Application.Commands
{
    public class RCUpdateAccountCommand
    {
        public RCUpdateAccountCommand(
            Guid recruiterId,
            string companyName,
            string englishName,
            bool accountType,
            bool newsletter,
            bool promotion,
            bool resumeAlert)
        {
            RecruiterId = recruiterId;
            CompanyName = companyName;
            EnglishName = englishName;
            AccountType = accountType;
            Newslettter = newsletter;
            Promotion = promotion;
            ResumeAlert = resumeAlert;
        }

        public Guid RecruiterId { get; set; }
        public string CompanyName { get; set; }
        public string EnglishName { get; set; }
        public bool AccountType { get; set; }
        public bool Newslettter { get; set; }
        public bool Promotion { get; set; }
        public bool ResumeAlert { get; set; }
    }
}
