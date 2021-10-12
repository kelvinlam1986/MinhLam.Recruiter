﻿using MinhLam.Recruiter.Application;
using System.Web;

namespace MinhLam.Recruiter.Infrastructure.Applications
{
    public class Redirector : IRedirector
    {
        public void GoToLogin()
        {
            Redirect("Login.aspx");
        }

        public void GoToRCMyAccount()
        {
            Redirect("MyAccount.aspx");
        }

        public void GoToRCProfile()
        {
            Redirect("Profile.aspx");
        }

        private void Redirect(string path)
        {
            HttpContext.Current.Response.Redirect(path);
        }
    }
}
