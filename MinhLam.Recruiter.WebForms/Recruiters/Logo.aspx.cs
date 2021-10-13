using MinhLam.Framework;
using MinhLam.Recruiter.Application;
using MinhLam.Recruiter.Application.Commands;
using MinhLam.Recruiter.Infrastructure.Sessions;
using Ninject;
using System;
using System.IO;
using System.Web;

namespace MinhLam.Recruiter.WebForms.Recruiters
{
    public partial class Logo : System.Web.UI.Page
    {
        [Inject]
        public IUserSession UserSession { get; set; }

        [Inject]
        public IMembershipService MembershipService { get; set; }

        [Inject]
        public IRedirector Redirector { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserSession.RCUserId == Guid.Empty)
            {
                Redirector.GoToLogin();
            }

            if (UserSession.RCActive == false)
            {
                btnUpload.Enabled = false;
                literalError.Text = "Bạn không thể upload logo công ty <br> bởi tài khoản của bạn chưa được chấp thuận";
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                string folderToSave = Server.MapPath("") + "\\Logos\\";
                HttpPostedFile myFile = Request.Files[0];
                if (myFile != null && myFile.FileName != "")
                {
                    myFile.SaveAs(folderToSave + UserSession.RCUserId + Path.GetExtension(myFile.FileName));
                    literalError.Text = "File " + myFile.FileName + " đã được lưu thành công. <br>";
                }

                var uploadLogoCommand = new RCUploadLogoCommand(UserSession.RCUserId);
                MembershipService.RCUploadLogo(uploadLogoCommand); 
            }
            catch (DomainException ex)
            {
                literalError.Text = ex.Message;
            }
            catch (ApplicationServiceException ex)
            {
                literalError.Text = ex.Message;
            }
            catch (Exception ex)
            {
                literalError.Text = ex.Message;
            }
        }
    }
}