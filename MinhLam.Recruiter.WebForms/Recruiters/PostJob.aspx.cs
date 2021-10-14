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
    public partial class PostJob : System.Web.UI.Page
    {
        [Inject]
        public IUserSession UserSession { get; set; }

        [Inject]
        public IRedirector Redirector { get; set; }

        [Inject]
        public IGetData GetData { get; set; }

        [Inject]
        public IWebContext WebContext { get; set; }

        [Inject]
        public IRCJobPostingRepository RCJobPostingRepository { get; set; }

        [Inject]
        public IJobPostingService RCJobPostingService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserSession.RCUserId == Guid.Empty)
            {
                Redirector.GoToLogin();
            }

            if (UserSession.RCActive == false)
            {
                btnSave.Enabled = false;
                btnActivate.Enabled = false;
                literalError.Text = "Bạn không thể sử dụng dịch vụ đăng tin ngay lúc này vì tài khoản bạn chưa được kích hoạt";
            }

            if (!IsPostBack)
            {
                LoadDataToDropDownList();
                postAndUpdateDate.Visible = false;
                if (WebContext.JobId != Guid.Empty)
                {
                    literalID.Text = WebContext.JobId.ToString();
                    if (LoadJob(WebContext.JobId) == false)
                    {
                        btnActivate.Visible = false;
                        btnPreView.Visible = false;
                        literalError.Text = "Tin không hợp lệ";
                    }
                    else
                    {
                        postAndUpdateDate.Visible = true;
                        lblTitle.Text = "Cập nhật tin tuyển dụng";
                        btnSave.Text = "Cập nhật tin";
                        btnActivate.Visible = true;
                        btnActivate.Visible = true;
                        literalError.Text = "";
                    }
                }
                else
                {
                    if (IsEnablePostJob())
                    {
                        LoadRangeOfDate(ddlCloseDate, 30, "");
                    }
                    else
                    {
                        Response.Redirect("PostJob.aspx");
                    }
                }
            }
        }

        private void LoadRangeOfDate(DropDownList ddl, int days, string selectedDate)
        {
            string formatDate = "dd/MM/yyyy";
            if (days > 0)
            {
                for (int day = 1; day <= days; day++)
                {
                    ddl.Items.Add(new ListItem(DateTime.Now.AddDays(day).ToString(formatDate), 
                        DateTime.Now.AddDays(day).ToString(formatDate)));

                }
                if (selectedDate != "")
                    ddl.SelectedValue = selectedDate;
                else
                    ddl.SelectedValue = DateTime.Now.AddDays(days).ToString(formatDate);
            }
            else
                ddl.Items.Add(selectedDate);
        }

        private bool IsEnablePostJob()
        {
            var account = GetData.GetRCAccountById(UserSession.RCUserId);
            if (account != null)
            {
                return account.AvailableForPosting > 0;
            }

            return false;
        }

        private bool LoadJob(Guid jobId)
        {
            string formatDate = "dd/MM/yyyy";
            var jobPosting = RCJobPostingRepository.GetById(jobId);
            if (jobPosting != null)
            {
                literalPostDate.Text = jobPosting.PostedDate.ToString(formatDate);
                literalUpdDate.Text = jobPosting.UpdatedDate.ToString(formatDate);
                txtNo.Text = jobPosting.JobNo;
                int remainDay = 30 - DateTime.Now.Date.Subtract(jobPosting.PostedDate.Date).Days;
                LoadRangeOfDate(ddlCloseDate, remainDay, jobPosting.ClosedDate.ToString(formatDate));
                txtTitle.Text = jobPosting.JobTitle;
                txtSummary.Text = jobPosting.JobSummary;
                ddlCategory.SelectedValue = jobPosting.JobCategoryId.ToString();
                ddlIndustry.SelectedValue = jobPosting.JobIndustryId.ToString();
                ddlCertificate.SelectedValue = jobPosting.CertificateId.ToString();
                ddlLevel.SelectedValue = jobPosting.ExperienceLevelId.ToString();
                txtYearExperience.Text = jobPosting.YearExperience;
                ddlWorkingType.SelectedValue = jobPosting.WorkingTypeId.ToString();
                txtContactEmail.Text = jobPosting.ContactEmail;
                txtContactPerson.Text = jobPosting.ContactPerson;
                txtContactTel.Text = jobPosting.ContactTel;
                txtNumber.Text = jobPosting.RequiredNumber.ToString();
                txtAge.Text = jobPosting.RangeOfAge;
                txtRecruitment.Text = jobPosting.RecruitmentType;
                chkShowLogo.Checked = jobPosting.CompanyLogo;
                txtSalaryFrom.Text = jobPosting.SalaryFrom.ToString();
                txtSalaryTo.Text = jobPosting.SalaryTo.ToString();
                ddlCurrency.SelectedValue = jobPosting.Currency;
                chkNegotive.Checked = jobPosting.SalaryNegotive;
                chkShowSalary.Checked = jobPosting.ShowSalary;
                ddlProvince.SelectedValue = jobPosting.ProvinceId.ToString();
                txtLocation.Text = jobPosting.WorkLocation;
                txtSkills.Text = jobPosting.JobSkill;
                txtAdv.Text = jobPosting.AdvName;
                chkApplyOnline.Checked = jobPosting.EnableApplyOnline;
                txtURL.Text = jobPosting.OnlyApplyUrl;
                ddlFolder.SelectedValue = jobPosting.FolderId.ToString();
                ddlTemplate.SelectedValue = jobPosting.TemplateId.ToString();
                btnActivate.Text = jobPosting.Activate ? "Bỏ kích hoạt" : "Kích hoạt";
                litDayLeft.Text = "Số ngày còn lại:" + remainDay.ToString();
                return true;
            }

            return false;
        }

        private void LoadDataToDropDownList()
        {
            LoadCategoryDropDownList();
            LoadIndustryDropDownList();
            LoadJSCertificatesDropDownList();
            LoadExperienceLevelDropDownList();
            LoadWorkingTypeDropDownList();
            LoadProvinceDropDownList();
            LoadRCFolderDropDownList(UserSession.RCUserId);
            LoadTemplateDropDownlist();
        }

        private void LoadTemplateDropDownlist()
        {
            var templates = GetData.GetTemplates();
            foreach (var template in templates)
            {
                ddlTemplate.Items.Add(new ListItem { Text = template.Name, Value = template.Id.ToString() });
            }
        }

        private void LoadRCFolderDropDownList(Guid recruiterId)
        {
            var folders = GetData.GetFoldersOfRecruiter(recruiterId);
            foreach (var folder in folders)
            {
                ddlFolder.Items.Add(new ListItem { Text = folder.FolderName, Value = folder.Id.ToString() });
            }
        }

        private void LoadProvinceDropDownList()
        {
            var provinces = GetData.GetProvinces();
            foreach (var province in provinces)
            {
                ddlProvince.Items.Add(new ListItem { Text = province.Name, Value = province.Id.ToString() });
            }
        }

        private void LoadWorkingTypeDropDownList()
        {
            var workingTypes = GetData.GetWorkingTypes();
            foreach (var workingType in workingTypes)
            {
                ddlWorkingType.Items.Add(new ListItem { Text = workingType.Name, Value = workingType.Id.ToString() });
            }
        }

        private void LoadExperienceLevelDropDownList()
        {
            var experienceLevels = GetData.GetExperienceLevels();
            foreach (var experienceLevel in experienceLevels)
            {
                ddlLevel.Items.Add(new ListItem { Text = experienceLevel.Name, Value = experienceLevel.Id.ToString() });
            }
        }

        private void LoadJSCertificatesDropDownList()
        {
            var certificates = GetData.GetJSCertificates();
            foreach (var certificate in certificates)
            {
                ddlCertificate.Items.Add(new ListItem { Text = certificate.Name, Value = certificate.Id.ToString() });
            }
        }

        private void LoadCategoryDropDownList()
        {
            var categories = GetData.GetJobCategories();
            foreach (var category in categories)
            {
                ddlCategory.Items.Add(new ListItem { Text = category.Name, Value = category.Id.ToString() });
            }
        }

        private void LoadIndustryDropDownList()
        {
            var industries = GetData.GetJobIndustries();
            foreach (var industry in industries)
            {
                ddlIndustry.Items.Add(new ListItem { Text = industry.Name, Value = industry.Id.ToString() });
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (UserSession.RCUserId == Guid.Empty)
                {
                    Redirector.GoToLogin();
                }

                if (WebContext.JobId == Guid.Empty)
                {
                    var addNewPostingJob = new AddNewJobPostingCommand(
                        UserSession.RCUserId,
                        txtTitle.Text,
                        txtNo.Text,
                        Convert.ToInt32(txtNumber.Text),
                        txtSummary.Text,
                        Guid.Parse(ddlWorkingType.SelectedValue),
                        Guid.Parse(ddlLevel.SelectedValue),
                        txtYearExperience.Text,
                        txtAge.Text,
                        txtRecruitment.Text,
                        Convert.ToInt32(txtSalaryFrom.Text),
                        Convert.ToInt32(txtSalaryTo.Text),
                        ddlCurrency.SelectedValue,
                        chkShowSalary.Checked,
                        chkNegotive.Checked,
                        Convert.ToDateTime(ddlCloseDate.SelectedValue),
                        chkShowLogo.Checked,
                        txtAdv.Text,
                        txtSkills.Text,
                        Guid.Parse(ddlIndustry.SelectedValue),
                        Guid.Parse(ddlCategory.SelectedValue),
                        Guid.Parse(ddlCertificate.SelectedValue),
                        txtLocation.Text,
                        Guid.Parse(ddlProvince.SelectedValue),
                        Guid.Parse(ddlTemplate.SelectedValue),
                        Guid.Parse(ddlFolder.SelectedValue),
                        chkApplyOnline.Checked,
                        txtURL.Text,
                        txtContactEmail.Text,
                        txtContactPerson.Text,
                        txtContactTel.Text
                        );

                    RCJobPostingService.AddNewJobPosting(addNewPostingJob);
                    Redirector.GoToJobManager();
                }
                
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
                literalError.Text = OperationExceptionCodes.InnerOperationProgramMessage;
            }
        }
    }
}