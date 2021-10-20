<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JobDetails.aspx.cs" Inherits="MinhLam.Recruiter.WebForms.Recruiters.JobDetails" %>

<%@ Register Src="~/Recruiters/rcTop.ascx" TagPrefix="uc1" TagName="rcTop" %>
<%@ Register Src="~/Recruiters/rcMenu.ascx" TagPrefix="uc1" TagName="rcMenu" %>
<%@ Register Src="~/Recruiters/rcBanner.ascx" TagPrefix="uc1" TagName="rcBanner" %>
<%@ Register Src="~/Recruiters/rcRight.ascx" TagPrefix="uc1" TagName="rcRight" %>
<%@ Register Src="~/Recruiters/rcBottom.ascx" TagPrefix="uc1" TagName="rcBottom" %>
<%@ Register Src="~/Recruiters/rcLeft.ascx" TagPrefix="uc1" TagName="rcLeft" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>::Tin chi tiết</title>
    <link href="Css/newstyle.css" rel="stylesheet" />
    <link href="Css/style.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>
<body topmargin="0" leftmargin="0" bottommargin="0" rightmargin="0" style="font-size: 12pt">
    <form id="form1" runat="server">
        <div>
            <table align="center" style="width: 960px" title="Timviecnhanh">
                <tr>
                    <td valign="top" colspan="5">
                        <uc1:rcTop ID="RcvTop1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="5" valign="top">
                        <uc1:rcBanner ID="rcBanner1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="5" style="height: 21px" valign="top">
                        <uc1:rcMenu ID="rcMenu1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 3px; height: 351px"></td>
                    <td style="width: 610px; height: 351px" valign="top">
                        <table align="center" style="width: 100%" title="Timviecnhanh">
                            <tr>
                                <td style="width: 100%;" valign="top">
                                    <table style="width: 99%">
                                        <tr>
                                            <td style="width: 400px; height: 21px" valign="top">
                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/Recruiters/Icons/titlenote.gif" />
                                                <strong>Chi tiết tin đăng</strong></td>
                                            <td style="width: 171px; text-align: right" valign="top">
                                                <table>
                                                    <tr>
                                                        <td style="height: 18px">
                                                            <asp:HyperLink ID="hyperLinkPrint" runat="server" NavigateUrl="#">In tin này</asp:HyperLink></td>
                                                        <td style="height: 18px">
                                                            <asp:HyperLink ID="hyperLinkBack" runat="server" Font-Bold="False"
                                                                NavigateUrl="javascript:window.history.go(-1);">Trở về</asp:HyperLink></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 400px; height: 19px" valign="top">
                                                <table style="width: 100%">
                                                    <tr>
                                                        <td align="justify">
                                                            <asp:Literal ID="literalIntro" runat="server"></asp:Literal></td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td style="width: 171px; height: 19px; text-align: right" valign="top"></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="width: 100%;">
                                                <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" BorderStyle="None"
                                                    GridLines="Horizontal" Width="100%">
                                                    <Fields>
                                                        <asp:BoundField DataField="CompanyName" HeaderText="Tên công ty: " />
                                                        <asp:BoundField DataField="JobID" HeaderText="Mã quy định:" />
                                                        <asp:BoundField DataField="JobNo" HeaderText="Mã hồ sơ: " />
                                                        <asp:BoundField DataField="JobTitle" HeaderText="Tên tin: " />
                                                        <asp:BoundField DataField="RequiredNumber" HeaderText="Số lượng yêu cầu:" />
                                                        <asp:BoundField DataField="JobCategoryName" HeaderText="Loại công việc: " />
                                                        <asp:BoundField DataField="JobIndustryName" HeaderText="Chuyên ngành: " />
                                                        <asp:BoundField DataField="CertificateName" HeaderText="Chứng chỉ: " />
                                                        <asp:BoundField DataField="RangeOfAge" HeaderText="Tuổi:" />
                                                        <asp:BoundField DataField="RecruitmentType" HeaderText="Yêu cầu Nam/Nữ" />
                                                        <asp:BoundField DataField="WorkLocation" HeaderText="Vị trí làm việc: " />
                                                        <asp:BoundField HeaderText="Thông tin liên hệ">
                                                            <HeaderStyle Font-Bold="True" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="ContactEmail" HeaderText="Email liên hệ:" />
                                                        <asp:BoundField DataField="ContactPerson" HeaderText="Người liên hệ: " />
                                                        <asp:BoundField DataField="ContactTel" HeaderText="Điện thoại liên hệ: " />
                                                        <asp:BoundField HeaderText="Mô tả công việc:">
                                                            <HeaderStyle Font-Bold="True" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="JobSummary" HeaderText="Mô tả công việc:" ShowHeader="False">
                                                            <ItemStyle Font-Bold="False" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Ký năng kỹ thiết:">
                                                            <HeaderStyle Font-Bold="True" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="JobSkills" ShowHeader="False" />
                                                        <asp:BoundField DataField="WorkingTypeName" HeaderText="Hình thức làm việc:" />
                                                        <asp:BoundField DataField="ExperienceLevelName" HeaderText="Mức kinh nghiệm:" />
                                                        <asp:BoundField DataField="YearExperience" HeaderText="Số năm kinh nghiệm:" />
                                                        <asp:BoundField DataField="SalaryFrom" HeaderText="Mức lương từ: " DataFormatString="{0:C0}"  />
                                                        <asp:BoundField DataField="SalaryTo" HeaderText="Mức lương đến:" DataFormatString="{0:C0}"  />
                                                        <asp:BoundField DataField="Currency" HeaderText="Loại tiền tê: " />
                                                        <asp:BoundField DataField="SalaryNegotive" HeaderText="Lương đàm phán: " />
                                                        <asp:BoundField DataField="ShowSalary" HeaderText="Hiển thị lương" />
                                                        <asp:BoundField DataField="CloseDate" HeaderText="Ngày đóng tin:" />
                                                        <asp:BoundField DataField="OnlyApplyURL" HeaderText="Cho phép nộp đơn tại website công ty:">
                                                            <ItemStyle Height="0px" />
                                                            <HeaderStyle Height="0px" />
                                                        </asp:BoundField>
                                                    </Fields>
                                                </asp:DetailsView>
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                    <table style="width: 99%">
                                        <tr>
                                            <td align="center" colspan="2" style="width: 312px; height: 16px;">
                                                <font color="red"><b>
                                                <asp:Literal ID="litError" runat="server"></asp:Literal></b></font></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 1px; height: 351px" valign="top"></td>
                    <td style="width: 160px; height: 351px" valign="top">
                        <uc1:rcRight ID="rcvRight1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="5">
                        <uc1:rcBottom id="RcvBottom1" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
