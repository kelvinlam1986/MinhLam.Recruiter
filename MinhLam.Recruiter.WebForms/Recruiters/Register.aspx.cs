using MinhLam.Framework;
using MinhLam.Recruiter.Application;
using MinhLam.Recruiter.Application.Commands;
using MinhLam.Recruiter.Domain;
using MinhLam.Recruiter.Infrastructure.Configuration;
using MinhLam.Recruiter.Infrastructure.Sessions;
using Ninject;
using System;

namespace MinhLam.Recruiter.WebForms.Recruiters
{
    public partial class Register : System.Web.UI.Page
    {
        [Inject]
        public IApplicationSettings ApplicationSettings { get; set; }

        [Inject]
        public IUserSession UserSession { get; set; }

        [Inject]
        public IMembershipService MembershipService { get; set; }

        [Inject]
        public ISendEmail SendEmail { get; set; }

        [Inject]
        public IRedirector Redirector { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserSession.RCUserId == Guid.Empty)
            {
                NotLogin();
            }
            else
            {
                Logged();
            }

        }

        private void NotLogin()
        {
            lblHeader.Text = "Đăng ký mởi";
            this.Title = "::Đăng ký mới";
            literalMessage.Visible = true;
            trTermofService.Visible = true;
            trAgree.Visible = true;
            txtEmail.Enabled = true;
            btnSave.Text = "I Agree";

            Page.ClientScript.RegisterClientScriptBlock(
                this.GetType(), "ClientScriptFunctionAgree",
                ClientScriptFunctionAgree(), true);
            btnSave.Attributes.Add("onclick",
            "return validateAgree();");
            trPassword.Visible = true;
            trRetype.Visible = true;
            btnNotAgree.Visible = true;
        }

        private void Logged()
        {
            this.Title = "::Cập nhật thông tin đăng nhập";
            literalMessage.Visible = false;
            trTermofService.Visible = false;
            trAgree.Visible = false;
            lblHeader.Text = "Cập nhật thông tin đăng nhập";
            txtEmail.Enabled = false;
            txtEmail.Text = UserSession.RCEmail;
            btnSave.Text = "Cập nhật";
            trPassword.Visible = false;
            trRetype.Visible = false;
            btnNotAgree.Visible = false;
            if (!IsPostBack)
            {
                EditAccount();
            }
        }

        private void EditAccount()
        {
            var account = this.MembershipService.GetRCAccountByEmail(UserSession.RCEmail);
            if (account == null)
            {
                this.literalError.Text = "Không thể tìm thấy tài khoản";
            }

            txtCompanyName.Text = account.CompanyName;
            txtEnglishName.Text = account.EnglishName;
            rblType.SelectedValue = account.AccountType ? "1" : "0";
            chkNewLetter.Checked = account.Newsletter;
            chkPromotinAlert.Checked = account.Promotion;
            chkResumeAlert.Checked = account.ResumeAlert;
        }

        private string ClientScriptFunctionAgree()
        {
            var strScript =
            "function validateAgree()\n" +
            "{\n if(!document.getElementById('"
            + chkAgree.ID + "').checked){alert('"
            + "Please check Agree checkbox " +
            "if you agree our policy');" +
            "return false;} return true;" +
            " \n}\n";
            return strScript;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (UserSession.RCUserId == Guid.Empty)
            {
                try
                {
                    var registerCommand = new RCRegisterAccountCommand(
                           txtEmail.Text,
                           txtPassword.Text,
                           txtCompanyName.Text,
                           txtEnglishName.Text,
                           rblType.SelectedValue == "1" ? true : false,
                           chkNewLetter.Checked,
                           chkResumeAlert.Checked,
                           chkPromotinAlert.Checked);
                    this.MembershipService.RCRegisterAccount(registerCommand);
                    this.SendEmail.SendNewRegisterSuccessfulRCAccount(txtEmail.Text);
                    var account = this.MembershipService.GetRCAccountByEmail(txtEmail.Text);
                    if (account == null)
                    {
                        literalError.Text = $"Tài khoản với email {txtEmail.Text} không tồn tại";
                        return;
                    }

                    UserSession.RCUserId = account.Id;
                    UserSession.RCEmail = account.Email;
                    UserSession.RCCompanyName = account.CompanyName + " " + account.EnglishName;
                    UserSession.RCJobFree = false;
                    UserSession.RCActive = false;
                    literalError.Text = "Tài khoản của bạn đã tạo thành công";
                }
                catch (DomainException ex)
                {
                    literalError.Text = ex.Message;
                }
                catch (ApplicationServiceException ex)
                {
                    literalError.Text = ex.Message;
                }
                catch (Exception)
                {
                    literalError.Text = OperationExceptionCodes.InnerOperationProgramMessage;
                }

            }
            else
            {
                try
                {
                    var updateCmd = new RCUpdateAccountCommand(
                        UserSession.RCUserId,
                        txtCompanyName.Text,
                        txtEnglishName.Text,
                        rblType.SelectedValue == "1",
                        chkNewLetter.Checked,
                        chkPromotinAlert.Checked,
                        chkResumeAlert.Checked);
                    this.MembershipService.RCUpdateAccount(updateCmd);
                    literalMessage.Text = "Cập nhật thành công";
                }
                catch (DomainException ex)
                {
                    literalError.Text = ex.Message;
                }
                catch (ApplicationException ex)
                {
                    literalError.Text = ex.Message;
                }
                catch (Exception)
                {
                    literalError.Text = OperationExceptionCodes.InnerOperationProgramMessage;
                }
            }

            Redirector.GoToRCProfile();
        }
    }
}