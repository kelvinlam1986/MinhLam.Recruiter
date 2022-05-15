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
    public partial class JobPurchases : System.Web.UI.Page
    {
        [Inject]
        public IUserSession UserSession { get; set; }

        [Inject]
        public IRedirector Redirector { get; set; }

        [Inject]
        public IJobPurchaseQuery JobPurchaseQuery { get; set; }

        [Inject]
        public IJobPostingService JobPostingService { get; set; }

        private int itemPerPage = 15;
        int pagePerSeggment = 5;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserSession.RCUserId == Guid.Empty)
            {
                Redirector.GoToLogin();
            }

            RegisterJavaScript();

            if (!IsPostBack)
            {
                ViewState["SortDirection"] = "ASC";
                ShowResult(0);
            }

            CreateNavigation(
               Convert.ToInt32(literalPages.Text),
               Convert.ToInt32(literalCurrentPage.Text),
               itemPerPage,
               pagePerSeggment,
               this.panelNavigation);
        }

        private void RegisterJavaScript()
        {
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "openWindow" + this.GridView1.ID, Printer.CreateScriptForPrint(this.GridView1.ID));
            this.hyperLinkPrint.Attributes.Add("onclick", "openWindow" + this.GridView1.ID + "('" + GridView1.ID.ToString() + "',400,700);return false;");

        }

        private void ShowResult(int page, string sortColumn = "", string sortDirection = "")
        {
            var totalRow = 0;
            var result = JobPurchaseQuery.GetJobPurchaseList(
                UserSession.RCUserId,
                page,
                itemPerPage,
                out totalRow,
                sortColumn,
                sortDirection);
            if (page == 0)
            {
                literalTotal.Text = totalRow.ToString();
                ShowTotalPages(Convert.ToInt32(literalTotal.Text));
            }

            GridView1.DataSource = result;
            GridView1.DataBind();

            if (GridView1.Rows.Count == 0)
            {
                litError.Text = "Không tìm thấy tin nào";
                ShowHide(false);
            }
            else
            {
                ShowHide(true);
                litError.Text = "";
                int currentRecords = Convert.ToInt32(literalCurrentPage.Text);
                literalRecords.Text = " - Hiển thị tin: " + ((currentRecords - 1) * itemPerPage + 1).ToString()
                    + "-";
                if ((currentRecords - 1) * itemPerPage + itemPerPage < Convert.ToInt32(literalTotal.Text))
                    literalRecords.Text +=
                    ((currentRecords - 1) * itemPerPage +
                    itemPerPage).ToString();
                else
                    literalRecords.Text += literalTotal.Text;
                literalRecords.Text += " trên " + literalTotal.Text;
            }
            CreateNavigation(Convert.ToInt32(
                       literalPages.Text), Convert.ToInt32(
                       literalCurrentPage.Text), itemPerPage,
                       pagePerSeggment, this.panelNavigation);
        }

        private void ShowTotalPages(int totalRows)
        {
            int totalPage = totalRows / itemPerPage;
            if (totalRows % itemPerPage != 0)
            {
                totalPage += 1;
            }

            literalPages.Text = totalPage.ToString();
        }

        private void ShowHide(bool flag)
        {
            literalTotal.Visible = flag;
            literalCurrentPage.Visible = flag;
            literalOfText.Visible = flag;
            literalPageText.Visible = flag;
            literalTotalText.Visible = flag;
            literalRecords.Visible = flag;
            literalPages.Visible = flag;
            btnDelete.Visible = flag;
        }

        private void CreateNavigation(
           int totalPages,
           int currentPage,
           int itemPerPage,
           int pagePerSeggent,
           Panel panelLinks
           )
        {
            panelLinks.Controls.Clear();
            int startPageNo = 0; int endPageNo = 0; int seggmentNo = 0;
            if (totalPages > 1)
            {
                seggmentNo = currentPage / pagePerSeggent;
                if ((currentPage % pagePerSeggent) > 0) seggmentNo += 1;
                startPageNo = pagePerSeggent * (seggmentNo - 1) + 1;
                if (seggmentNo * pagePerSeggent > totalPages)
                    endPageNo = totalPages;
                else
                    endPageNo = seggmentNo * pagePerSeggent;


                LinkButton linkButton;
                Label labelSpace;

                if (seggmentNo > 1)
                {
                    linkButton = new LinkButton();
                    linkButton.Text = "Đầu";
                    linkButton.Click += new EventHandler(linkButton_Click);
                    linkButton.ID = (1).ToString();
                    labelSpace = new Label();
                    labelSpace.Text = "&nbsp; ";
                    panelLinks.Controls.Add(linkButton);
                    panelLinks.Controls.Add(labelSpace);
                }

                if (currentPage > pagePerSeggent)
                {
                    linkButton = new LinkButton();
                    linkButton.Text = "Trước";
                    linkButton.Click += new EventHandler(linkButton_Click);
                    linkButton.ID = (startPageNo - 1).ToString();
                    labelSpace = new Label();
                    labelSpace.Text = "&nbsp; ";
                    panelLinks.Controls.Add(linkButton);
                    panelLinks.Controls.Add(labelSpace);
                }
                int i = 0;
                for (i = startPageNo; i <= endPageNo; i++)
                {
                    linkButton = new LinkButton();
                    linkButton.Text = i.ToString();

                    linkButton.ID = i.ToString();
                    if (i == currentPage)
                        linkButton.BackColor = System.Drawing.Color.Aqua;
                    linkButton.Click += new EventHandler(linkButton_Click);
                    labelSpace = new Label();
                    labelSpace.Text = "&nbsp; ";
                    panelLinks.Controls.Add(linkButton);
                    panelLinks.Controls.Add(labelSpace);
                }
                if (seggmentNo * pagePerSeggent < totalPages)
                {
                    linkButton = new LinkButton();
                    linkButton.Text = "Tiếp";
                    linkButton.ID = (i).ToString();
                    linkButton.Click += new EventHandler(linkButton_Click);
                    labelSpace = new Label();
                    labelSpace.Text = "&nbsp; ";
                    panelLinks.Controls.Add(linkButton);
                    panelLinks.Controls.Add(labelSpace);
                }
                if (seggmentNo * pagePerSeggent + 1 < totalPages)
                {
                    linkButton = new LinkButton();
                    linkButton.Text = "Cuối";
                    linkButton.ID = totalPages.ToString();
                    linkButton.Click += new EventHandler(linkButton_Click);
                    labelSpace = new Label();
                    labelSpace.Text = "&nbsp;";
                    panelLinks.Controls.Add(linkButton);
                    panelLinks.Controls.Add(labelSpace);
                }
            }
        }

        private void linkButton_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            int nextPage = 0;
            nextPage = Convert.ToInt32(linkButton.ID);
            literalCurrentPage.Text = nextPage.ToString();
            int endJobs = nextPage * Convert.ToInt32(itemPerPage);
            if (endJobs > Convert.ToInt32(literalTotal.Text)) endJobs = Convert.ToInt32(literalTotal.Text);
            literalRecords.Text = " - Hiển thị tin: " + (nextPage - 1) * itemPerPage + " -> " + endJobs.ToString();
            ShowResult(nextPage - 1);
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            GridViewRow gridViewRow = e.Row;
            gridViewRow.Cells[1].Visible = false;
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            GridViewRow gridViewRow = e.Row;
            if (gridViewRow.RowType == DataControlRowType.DataRow)
            {
                CheckBox checkBox = (CheckBox)gridViewRow.Cells[0].FindControl("chkPackageID");
                if (gridViewRow.Cells[1].Text == "")
                {
                    checkBox.Visible = false;
                }

                if (gridViewRow.Cells[9].Text == "Đã thanh toán")
                {
                    checkBox.Enabled = false;
                }
            }
        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            ShowResult( Convert.ToInt32(literalCurrentPage.Text) - 1, e.SortExpression, ViewState["SortDirection"].ToString());
            if (ViewState["SortDirection"].ToString() == "ASC")
                ViewState["SortDirection"] = "DESC";
            else
                ViewState["SortDirection"] = "ASC";
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string selectItem = GetSelectItem();
            if (string.IsNullOrEmpty(selectItem) == false)
            {
                selectItem = selectItem.Substring(0, selectItem.Length - 1);
                var listPackageId = selectItem.Split(',');
                foreach (var salesPackageId in listPackageId)
                {
                    try
                    {
                        var removeSalesPackageCommand = new RCRemoveSalesPackageCommand(Guid.Parse(salesPackageId));
                        JobPostingService.RemoveSalesPackage(removeSalesPackageCommand);
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
                        litError.Text = OperationExceptionCodes.InnerOperationProgramMessage;
                    }
                }

                ShowResult(0);
            }
        }

        private string GetSelectItem()
        {
            string selectItem = "";
            foreach (GridViewRow gridViewRow in GridView1.Rows)
            {
                CheckBox checkBox = (CheckBox)
                gridViewRow.FindControl("chkPackageID");

                if (checkBox.Checked)
                {
                    // PackageID
                    var jobId = gridViewRow.Cells[1].Text;
                    selectItem += jobId + ",";
                }
            }

            return selectItem;
        }

    }
}