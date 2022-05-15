using MinhLam.Framework;
using MinhLam.Recruiter.Application;
using MinhLam.Recruiter.Application.Commands;
using MinhLam.Recruiter.Application.Query;
using MinhLam.Recruiter.Infrastructure.Sessions;
using Ninject;
using System;
using System.Web.UI.WebControls;

namespace MinhLam.Recruiter.WebForms.Recruiters
{
    public partial class JobPurchase : System.Web.UI.Page
    {
        [Inject]
        public IUserSession UserSession { get; set; }

        [Inject]
        public IRedirector Redirector { get; set; }

        [Inject]
        public ISalesPackagesViewQuery SalesPackageViewQuery { get; set; }

        [Inject]
        public IJobPostingService JobPostingService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserSession.RCUserId == Guid.Empty)
            {
                Redirector.GoToLogin();
            }

            if (!IsPostBack)
            {
                ViewState["SortDirection"] = "ASC";
                ShowPackages();
            }

            if (UserSession.RCActive == false)
            {
                btnSave.Enabled = false;
                litError.Text = "<img border=0 src='/icons/warning.gif'>Bạn không thể đặt mua RCV tin tuyển dụng và xem những dịch vụ, " +
                    "<br>bởi vì tài khoản của bạn chưa được chấp thuận bởi quản lý.";
            }
        }

        private void ShowPackages()
        {
            var result = SalesPackageViewQuery.GetList();
            GridView1.DataSource = result;
            GridView1.DataBind();

            if (GridView1.Rows.Count == 0)
                litError.Text = "Không tìm thấy gói tin tuyển dụng.";
            else
            {
                FillValidate();
                litError.Text = "";
            }
        }

        private void ShowPackages(string columnName, string sortType)
        {
            var result = SalesPackageViewQuery.GetList(columnName, sortType);
            GridView1.DataSource = result;
            GridView1.DataBind();

            if (GridView1.Rows.Count == 0)
                litError.Text = "Không tìm thấy gói tin tuyển dụng.";
            else
            {
                FillValidate();
                litError.Text = "";
            }
        }

        private void FillValidate()
        {
            foreach (GridViewRow gridViewRow in GridView1.Rows)
            {
                RangeValidator rangeValidator = (RangeValidator)
                gridViewRow.FindControl("rv");
                rangeValidator.MinimumValue = gridViewRow.Cells[8].Text;
                rangeValidator.MaximumValue = gridViewRow.Cells[9].Text;
                rangeValidator.Type = ValidationDataType.Integer;
                rangeValidator.Text = "Giá trị: " + gridViewRow.Cells[8].Text + "-" + gridViewRow.Cells[9].Text;
            }
        }

        protected void GridView1_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            GridViewRow gridViewRow = e.Row;
            gridViewRow.Cells[0].Visible = false;
            gridViewRow.Cells[8].Visible = false;
            gridViewRow.Cells[9].Visible = false;
            gridViewRow.Cells[10].Visible = false;
        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            ShowPackages(e.SortExpression, ViewState["SortDirection"].ToString());
            if (ViewState["SortDirection"].ToString() == "ASC")
                ViewState["SortDirection"] = "DESC";
            else
                ViewState["SortDirection"] = "ASC";
        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            int totalJobAmount = 0, totalViewAmount = 0;
            int totalJobs = 0, totalViews = 0;
            int totalDiscount = 0;
            foreach (GridViewRow gridViewRow in GridView1.Rows)
            {
                TextBox textBox = (TextBox)gridViewRow.FindControl("txtPurchase");

                if (textBox.Text != "")
                {
                    if (gridViewRow.Cells[10].Text == "False")
                    {
                        totalJobs += Convert.ToInt32(textBox.Text);
                        totalJobAmount += Convert.ToInt32(gridViewRow.Cells[4].Text) * Convert.ToInt32(textBox.Text);
                        if (gridViewRow.Cells[5].Text != "")
                        {
                            totalDiscount += totalJobAmount * Convert.ToInt32(gridViewRow.Cells[5].Text) / 100;
                        }
                    }
                    else
                    {
                        totalViews += Convert.ToInt32(textBox.Text);
                        totalViewAmount += Convert.ToInt32(gridViewRow.Cells[4].Text) * Convert.ToInt32(textBox.Text);
                        if (gridViewRow.Cells[5].Text != "")
                        {
                            totalDiscount -= totalDiscount * Convert.ToInt32(gridViewRow.Cells[5].Text) / 100;
                        }
                    }
                }

            }
            totalViewAmount -= totalDiscount;
            literalJobs.Text = totalJobs.ToString();
            literalViews.Text = totalViews.ToString();
            literalDiscount.Text = totalDiscount.ToString("#,###.00");
            literalAmount.Text = (totalJobAmount + totalViewAmount).ToString("#,###.00");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlPaymentBy.SelectedValue == "Cash"
                   || ddlPaymentBy.SelectedValue == "Bank Transfer"
                   || ddlPaymentBy.SelectedValue == "ATM Transfer")
                {
                    var command = new RCAddSalesPackageCommand(UserSession.RCUserId, txtContactName.Text, ddlPaymentBy.SelectedValue, ddlCurrency.SelectedValue);

                    int totalJobs = 0, totalViews = 0;
                    foreach (GridViewRow gridViewRow in GridView1.Rows)
                    {
                        TextBox textBox = (TextBox)gridViewRow.FindControl("txtPurchase");
                        if (textBox.Text != "")
                        {
                            command.AddPackage(new RCSalesPackageDetailDto(
                                packageId: Guid.Parse(gridViewRow.Cells[0].Text),
                                packageName: gridViewRow.Cells[2].Text,
                                packageQuantity: Convert.ToInt32(textBox.Text),
                                packagePrice: Convert.ToInt32(gridViewRow.Cells[4].Text),
                                packageType: Convert.ToBoolean(gridViewRow.Cells[10].Text))
                            );

                            if (gridViewRow.Cells[10].Text == "False")
                            {
                                totalJobs += Convert.ToInt32(textBox.Text);
                            }
                            else
                            {
                                totalViews += Convert.ToInt32(textBox.Text);
                            }
                        }
                    }

                    JobPostingService.AddSalesPackage(command);
                    Redirector.GoToJobPurchases();
                }
                else
                {
                    litError.Text = "Phương thức thanh toán không hỗ trợ";
                }
            }
            catch (DomainException ex)
            {
                litError.Text = ex.Message;
            }
            catch (ApplicationServiceException ex)
            {
                litError.Text = ex.Message;
            }
            catch (Exception ex)
            {
                litError.Text = ex.Message;
            }
        }
    }
}