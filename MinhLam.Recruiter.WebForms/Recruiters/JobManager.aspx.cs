using MinhLam.Framework;
using MinhLam.Recruiter.Application;
using MinhLam.Recruiter.Application.Commands;
using MinhLam.Recruiter.Application.Query;
using MinhLam.Recruiter.Application.Query.ViewModel;
using MinhLam.Recruiter.Domain;
using MinhLam.Recruiter.Infrastructure.Sessions;
using Ninject;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace MinhLam.Recruiter.WebForms.Recruiters
{
    public partial class JobManager : System.Web.UI.Page
    {
        [Inject]
        public IUserSession UserSession { get; set; }

        [Inject]
        public IRedirector Redirector { get; set; }

        [Inject]
        public IGetData GetData { get; set; }

        [Inject]
        public IJobPostingQuery JobPostingQuery { get; set; }

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

            if (!IsPostBack)
            {
                LoadFolders();
                ViewState["SortDirection"] = "ASC";
                ShowResult(Guid.Parse(ddlFolder.SelectedValue), 0);
            }

            CreateNavigation(
                Convert.ToInt32(literalPages.Text),
                Convert.ToInt32(literalCurrentPage.Text),
                itemPerPage,
                pagePerSeggment,
                this.panelNavigation);
        }

        private void ShowResult(Guid folderId, int page, string sortColumn = "", string sortDirection = "")
        {
            var totalRow = 0;
            var result = JobPostingQuery.GetJobList(
                UserSession.RCUserId, 
                true, 
                folderId, 
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
                    linkButton.Text = "First";
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
                    linkButton.Text = "Previous";
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
                    linkButton.Text = "Next";
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
                    linkButton.Text = "Last";
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
            ShowResult(Guid.Parse(ddlFolder.SelectedValue), nextPage - 1);
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
            btnDisactivate.Visible = flag;
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

        private void LoadFolders()
        {
            var folders = GetData.GetFoldersOfRecruiter(UserSession.RCUserId);
            foreach (var folder in folders)
            {
                ddlFolder.Items.Add(new ListItem { Text = folder.FolderName, Value = folder.Id.ToString() });
            }

            ddlFolder.Items.Insert(0, new ListItem { Text = "", Value = Guid.NewGuid().ToString() });
        }

        protected void ddlFolder_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowResult(Guid.Parse(ddlFolder.SelectedValue), 0);
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            GridViewRow gridViewRow = e.Row;

            if (gridViewRow.RowType == DataControlRowType.DataRow)
            {
                // Add the edit link to action column
                HyperLink editLink = new HyperLink();
                editLink.Text = "Xem";
                editLink.NavigateUrl = string.Format("JobDetails.aspx?JobID={0}",
                    ((JobPostingDto)e.Row.DataItem).JobId.ToString());
                e.Row.Cells[1].Controls.Add(editLink);
                DropDownList dropDownList = (DropDownList)gridViewRow.Cells[9].FindControl("ddlFolder");
                var value = gridViewRow.Cells[10].Text;
                dropDownList.SelectedValue = value;
            }
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            GridViewRow gridViewRow = e.Row;
            List<RCFolder> folderList = null;

            if (gridViewRow.RowType == DataControlRowType.DataRow)
            {
                if (folderList == null)
                {
                    folderList = GetData.GetFoldersOfRecruiter(UserSession.RCUserId);
                }
                DropDownList dropDownList = (DropDownList)gridViewRow.Cells[9].FindControl("ddlFolder");
                foreach (var folder in folderList)
                {
                    dropDownList.Items.Add(new ListItem { Text = folder.FolderName, Value = folder.Id.ToString() });
                }

                dropDownList.Items.Insert(0, new ListItem { Text = "", Value = Guid.Empty.ToString() });

            }

            gridViewRow.Cells[10].Visible = false;
            gridViewRow.Cells[11].Visible = false;
        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            ShowResult(Guid.Parse(ddlFolder.SelectedValue),
                Convert.ToInt32(literalCurrentPage.Text) - 1,
                e.SortExpression,
                ViewState["SortDirection"].ToString());
            if (ViewState["SortDirection"].ToString() == "ASC")
                ViewState["SortDirection"] = "DESC";
            else
                ViewState["SortDirection"] = "ASC";
        }

        private string GetSelectItem()
        {
            string selectItem = "";
            foreach (GridViewRow gridViewRow in GridView1.Rows)
            {
                CheckBox checkBox = (CheckBox)
                gridViewRow.FindControl("chkJobID");

                if (checkBox.Checked)
                {
                    // JobId
                    var jobId = gridViewRow.Cells[11].Text;
                    selectItem += jobId + ",";
                }
            }

            return selectItem;
        }

        protected void btnDisactivate_Click(object sender, EventArgs e)
        {
            string selectItem = GetSelectItem();
            if (string.IsNullOrEmpty(selectItem) == false)
            {
                selectItem = selectItem.Substring(0, selectItem.Length - 1);
                var listJobIds = selectItem.Split(',');
                foreach (var jobId in listJobIds)
                {
                    try
                    {
                        var toggleActiveCommand = new ToggleActiveJobCommand(Guid.Parse(jobId));
                        JobPostingService.ToggleActive(toggleActiveCommand);
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

                ShowResult(Guid.Parse(ddlFolder.SelectedValue), 0);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string selectItem = GetSelectItem();
            if (string.IsNullOrEmpty(selectItem) == false)
            {
                selectItem = selectItem.Substring(0, selectItem.Length - 1);
                var listJobIds = selectItem.Split(',');
                foreach (var jobId in listJobIds)
                {
                    try
                    {
                        var removeJobPostingCommand = new RCRemoveJobPostingCommand(Guid.Parse(jobId));
                        JobPostingService.RemoveJobPostig(removeJobPostingCommand);
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

                ShowResult(Guid.Parse(ddlFolder.SelectedValue), 0);
            }
        }
    }
}