using System;

namespace MinhLam.Recruiter.Application.Commands
{
    public class RCForgotPasswordCommand
    {
        public RCForgotPasswordCommand(string email, string companyName, string englishName, DateTime dateEstablished)
        {
            Email = email;
            CompanyName = companyName;
            EnglishName = englishName;
            DateEstablished = dateEstablished;
        }

        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string EnglishName { get; set; }
        public DateTime DateEstablished { get; set; }
    }
}
