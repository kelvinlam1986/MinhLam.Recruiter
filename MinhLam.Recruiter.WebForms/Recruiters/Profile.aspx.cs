using MinhLam.Framework;
using MinhLam.Recruiter.Application;
using MinhLam.Recruiter.Application.Commands;
using MinhLam.Recruiter.Domain;
using MinhLam.Recruiter.Infrastructure.Sessions;
using Ninject;
using System;
using System.Web.UI.WebControls;

namespace MinhLam.Recruiter.WebForms.Recruiters
{
    public partial class Profile : System.Web.UI.Page
    {
        [Inject]
        public IUserSession UserSession { get; set; }

        [Inject]
        public IRedirector Redirector { get; set; }

        [Inject]
        public IGetData GetData { get; set; }

        [Inject]
        public IRCAccountRepository AccountRepository { get; set; }

        [Inject]
        public IMembershipService MembershipService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserSession.RCUserId == Guid.Empty)
            {
                Redirector.GoToLogin();
            }
            else
            {
                if (!IsPostBack)
                {
                    LoadDataForDropDownList();
                    LoadProfile(UserSession.RCUserId);
                }
            }
        }

        private void LoadProfile(Guid accountId)
        {
            var account = AccountRepository.GetById(accountId);
            if (account == null)
            {
                btnNext.Text = "Lưu";
                txtDOE.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
            else
            {
                btnNext.Text = "Cập nhật";
                txtAddress.Text = account.Address;
                txtContactName.Text = account.Contact;
                txtTel.Text = account.Tel;
                txtFax.Text = account.Fax;
                ddlProvince.SelectedValue = account.ProvinceId.ToString();
                txtCity.Text = account.City;
                ddlCountry.SelectedValue = account.Country;
                if (account.OpenDate.HasValue)
                {
                    txtDOE.Text = account.OpenDate.Value.ToString("yyyy-MM-dd");
                }
            }
        }

        private void LoadDataForDropDownList()
        {
            var provinces = GetData.GetProvinces();
            foreach (var province in provinces)
            {
                ddlProvince.Items.Add(new ListItem { Text = province.Name, Value = province.Id.ToString() });
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                var updateCompanyCommand = new RCUpdateCompanyCommand(
                    UserSession.RCUserId,
                    txtContactName.Text,
                    txtAddress.Text,
                    Guid.Parse(ddlProvince.SelectedValue),
                    txtCity.Text,
                    Convert.ToDateTime(txtDOE.Text),
                    txtTel.Text,
                    txtFax.Text,
                    ddlCountry.SelectedValue);
                MembershipService.RCUpdateCompany(updateCompanyCommand);
                this.Redirector.GoToRCMyAccount();
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