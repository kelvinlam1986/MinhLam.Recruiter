using System;

namespace MinhLam.Recruiter.WebForms.Recruiters
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Session.Abandon();
        }
    }
}