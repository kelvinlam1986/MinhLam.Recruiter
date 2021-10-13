<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="rcLeft.ascx.cs" Inherits="MinhLam.Recruiter.WebForms.Recruiters.rcLeft" %>
<table style="width: 160px" cellSpacing="0" cellPadding="0">
    <tr>
         <td style="width: 160px">
             <asp:TreeView ID="TreeView1" runat="server">
                 <Nodes>
                     <asp:TreeNode Text="Tài khoản" Value="Tài khoản">
                        <asp:TreeNode Text="Thông tin đăng nhập" Value="Thông tin đăng nhập" NavigateUrl="~/JobSeekers/register.aspx"></asp:TreeNode>
                        <asp:TreeNode Text="Thông tin cá nhân" Value="Thông tin cá nhân" NavigateUrl="~/JobSeekers/personal.aspx"></asp:TreeNode>
                        <asp:TreeNode Text="Trình độ học vấn" Value="Trình độ học vấn" NavigateUrl="~/JobSeekers/educations.aspx"></asp:TreeNode>
                        <asp:TreeNode Text="Kinh nghiệm" Value="Kinh nghiệm" NavigateUrl="~/JobSeekers/experiences.aspx"></asp:TreeNode>
                        <asp:TreeNode Text="Thông tin kỹ năng" Value="Thông tin kỹ năng" NavigateUrl="~/JobSeekers/skills.aspx"></asp:TreeNode>
                        <asp:TreeNode Text="Thông tin khác" Value="Thông tin khác" NavigateUrl="~/JobSeekers/other.aspx"></asp:TreeNode>
                    </asp:TreeNode>
                     <asp:TreeNode Text="Hồ sơ" Value="Hồ sơ">
                        <asp:TreeNode NavigateUrl="~/JobSeekers/coverletters.aspx" Text="Thư giới thiệu" Value="Thư giới thiệu">
                        </asp:TreeNode>
                        <asp:TreeNode Text="Thông tin hồ sơ" Value="Thông tin hồ sơ" NavigateUrl="~/JobSeekers/resumes.aspx"></asp:TreeNode>
                        <asp:TreeNode Text="Chi tiết hồ sơ" Value="Chi tiết hồ sơ" NavigateUrl="~/JobSeekers/resumedetails.aspx"></asp:TreeNode>
                        <asp:TreeNode Text="Khóa tìm kiếm" Value="Khóa tìm kiếm" NavigateUrl="~/JobSeekers/BlockSearchs.aspx"></asp:TreeNode>
                    </asp:TreeNode>
                     <asp:TreeNode Text="Thông tin lịch sử" Value="Thông tin lịch sử">
                        <asp:TreeNode Text="Những Job đã lưu" Value="Những Job đã lưu" NavigateUrl="~/JobSeekers/savedjobs.aspx"></asp:TreeNode>
                        <asp:TreeNode Text="Tìm kiếm của tôi" Value="Tìm kiếm của tôi" NavigateUrl="~/JobSeekers/savedsearchs.aspx"></asp:TreeNode>
                        <asp:TreeNode Text="Những Job đã nộp" Value="Những Job đã nộp" NavigateUrl="~/JobSeekers/jobapplied.aspx"></asp:TreeNode>
                        <asp:TreeNode Text="Thông báo của tôi" Value="Thông báo của tôi" NavigateUrl="~/JobSeekers/jobalerts.aspx"></asp:TreeNode>
                    </asp:TreeNode>
                 </Nodes>
             </asp:TreeView>
         </td>
    </tr>
</table>