using MinhLam.Framework;
using MinhLam.Recruiter.Application;
using MinhLam.Recruiter.Application.Commands;
using MinhLam.Recruiter.Application.Query;
using MinhLam.Recruiter.Infrastructure.Sessions;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MinhLam.Recruiter.WebForms.Recruiters
{
    public partial class JobFolders : System.Web.UI.Page
    {
        [Inject]
        public IUserSession UserSession { get; set; }

        [Inject]
        public IRedirector Redirector { get; set; }
        
        [Inject]
        public IFolderQuery FolderQuery { get; set; }

        [Inject]
        public IFolderService FolderService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserSession.RCUserId == Guid.Empty)
            {
                Redirector.GoToLogin();
            }

            if (!IsPostBack)
            {
                ViewState["SortDirection"] = "ASC";
                ShowFolders();
            }
        }

        private void ShowFolders(string sortColumn = "", string sortDirection = "")
        {
            var result = FolderQuery.GetFolderList(UserSession.RCUserId, sortColumn, sortDirection);
            GridView1.DataSource = result;
            GridView1.DataBind();

            if (GridView1.Rows.Count == 0)
            {
                litError.Text = "Không tìm thấy thư mục nào";
                btnDelete.Visible = false;
            }
            else
            {
                literalTotal.Text = GridView1.Rows.Count.ToString();
                btnDelete.Visible = true;
                if (GridView1.Rows.Count < 10)
                {
                    btnSave.Visible = true;
                }
                else
                {
                    btnSave.Visible = false;
                }
                litError.Text = "";
            }

        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            ShowFolders(
              e.SortExpression,
              ViewState["SortDirection"].ToString());

            if (ViewState["SortDirection"].ToString() == "ASC")
                ViewState["SortDirection"] = "DESC";
            else
                ViewState["SortDirection"] = "ASC";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var addNewFolderCommand = new AddNewFolderCommand(
                    UserSession.RCUserId,
                    txtName.Text,
                    txtDescription.Text,
                    txtManager.Text);
                FolderService.AddNewFolder(addNewFolderCommand);
                ShowFolders();
                ClearTextBox();
                
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

        private void ClearTextBox()
        {
            txtName.Text = "";
            txtDescription.Text = "";
            txtManager.Text = "";
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string selectItem = GetSelectItem();
                if (string.IsNullOrEmpty(selectItem) == false)
                {
                    selectItem = selectItem.Substring(0, selectItem.Length - 1);
                    var listFolderId = selectItem.Split(',');
                    foreach (var folderId in listFolderId)
                    {
                        try
                        {
                            var removeFolderCommand = new RCFolderRemoveCommand(Guid.Parse(folderId));
                            FolderService.RemoveFolder(removeFolderCommand);
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

                    ShowFolders();
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
                litError.Text = OperationExceptionCodes.InnerOperationProgramMessage;
            }
        }

        private string GetSelectItem()
        {
            string selectItem = "";
            foreach (GridViewRow gridViewRow in GridView1.Rows)
            {
                CheckBox checkBox = (CheckBox)
                gridViewRow.FindControl("chkFolderID");

                if (checkBox.Checked)
                {
                    var folderId = gridViewRow.Cells[1].Text;
                    selectItem += folderId + ",";
                }
            }

            return selectItem;
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            GridViewRow gridViewRow = e.Row;
            gridViewRow.Cells[1].Visible = false;
        }
    }
}