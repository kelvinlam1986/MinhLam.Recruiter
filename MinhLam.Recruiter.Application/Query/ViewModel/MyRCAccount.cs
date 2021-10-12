using System;

namespace MinhLam.Recruiter.Application.Query.ViewModel
{
    public class MyRCAccount
    {
        public Guid RecruiterId { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string EnglishName { get; set; }
        public bool AccountType { get; set; }
        public bool Agency { get; set; }
        public string RegisterDate { get; set; }
        public string LastLogin { get; set; }
        public int JobPostingBalance { get; set; }
        public int ResumeViewingBalance { get; set; }
        public int AvailableForPosting { get; set; }
        public int AvailableForViewing { get; set; }
        public int HitViewed { get; set; }
        public bool Activate { get; set; }
        public int JobNo { get; set; }
    }
}
