<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JobManager.aspx.cs" Inherits="MinhLam.Recruiter.WebForms.Recruiters.JobManager" %>

<%@ Register Src="~/Recruiters/rcTop.ascx" TagPrefix="uc1" TagName="rcTop" %>
<%@ Register Src="~/Recruiters/rcMenu.ascx" TagPrefix="uc1" TagName="rcMenu" %>
<%@ Register Src="~/Recruiters/rcBanner.ascx" TagPrefix="uc1" TagName="rcBanner" %>
<%@ Register Src="~/Recruiters/rcRight.ascx" TagPrefix="uc1" TagName="rcRight" %>
<%@ Register Src="~/Recruiters/rcBottom.ascx" TagPrefix="uc1" TagName="rcBottom" %>
<%@ Register Src="~/Recruiters/rcLeft.ascx" TagPrefix="uc1" TagName="rcLeft" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>::Quản lý Job</title>
    <link href="Css/newstyle.css" rel="stylesheet" />
    <link href="Css/style.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>
<body topmargin="0" leftmargin="0" bottommargin="0" rightmargin="0" style="font-size: 12pt" alink="#0">
    <form id="form1" runat="server">
        <div>
            <table align="center" style="width: 960px" title="Timviecnhanh">
                <tr>
                    <td valign="top" colspan="4">
                        <uc1:rcTop ID="RcvTop1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="4" valign="top">
                        <uc1:rcBanner ID="rcBanner1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 21px" valign="top">
                        <uc1:rcMenu ID="rcMenu1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 3px; height: 351px"></td>
                    <td style="width: 100%" valign="top">
                        <table border="0" style="width: 100%">
                            <tr>
                                <td align="center" style="height: 12px; text-align: left" valign="top">
                                    <table style="width: 100%">
                                        <tr>
                                            <td style="width: 340px; height: 16px">
                                                <b>
                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Recruiters/Icons/titlenote.gif" />
                                                    <asp:Literal ID="litType" runat="server" Text="Quản lý tin"></asp:Literal>&nbsp;</b></td>
                                        </tr>
                                    </table>
                                    Chú ý: Click vào Tiêu đề  để chỉnh sửa tin và Mã số để xem phản hồi tin</td>
                                <td align="right">
                                    <strong>Thu mục:</strong>
                                    <asp:DropDownList ID="ddlFolder" runat="server" AutoPostBack="True" Width="119px" 
                                        OnSelectedIndexChanged="ddlFolder_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:Button ID="btnPrint" runat="server" Text="In" Width="57px" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" colspan="2">
                                    <hr size="1" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" style="text-align: left" valign="top">
                                    <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                        PageSize="20" Width="100%" OnRowDataBound="GridView1_RowDataBound" OnRowCreated="GridView1_RowCreated"
                                        OnSorting="GridView1_Sorting">
                                        <PagerSettings Mode="NumericFirstLast" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="#">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkJobID" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="" HeaderText="Xem" />
                                            <asp:HyperLinkField DataNavigateUrlFields="JobID" DataNavigateUrlFormatString="PostJob.aspx?JobID={0}"
                                                DataTextField="JobTitle" HeaderText="Tiêu đề" SortExpression="JobTitle" />
                                            <asp:HyperLinkField DataNavigateUrlFields="JobID" DataNavigateUrlFormatString="JobResponses.aspx?JobID={0}"
                                                DataTextField="JobNo" HeaderText="Mã số">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:HyperLinkField>
                                            <asp:BoundField DataField="CategoryName" HeaderText="Loại công việc" />
                                            <asp:BoundField DataField="PostDate" HeaderText="Post Date" SortExpression="PostedDate">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CloseDate" HeaderText="Ngày đóng" SortExpression="ClosedDate">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="RequiredNumber" HeaderText="Số lượng cần">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ViewedNo" HeaderText="Số lần xem">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Tên thư mục">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlFolder" runat="server" Width="105px">
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="FolderId" ShowHeader="False" />
                                            <asp:BoundField DataField="JobId" ShowHeader="False" />
                                        </Columns>
                                    </asp:GridView>
                                    &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="center" style="text-align: left" valign="top" width="70%">&nbsp;
                                    <asp:Button ID="btnDelete" runat="server" Text="Xóa" OnClick="btnDelete_Click" />&nbsp;
                                <asp:Button ID="btnDisactivate" runat="server" Text="Bỏ kích hoạt" Width="90px" OnClick="btnDisactivate_Click" />&nbsp;
                                <asp:Button ID="btnUpdate" runat="server" Text="Cập nhật thư mục"
                                    Width="120px" OnClick="btnUpdate_Click" /><br />
                                    <br />
                                    <asp:Literal ID="literalTotalText" runat="server" Text="Tổng số lượng tin: "></asp:Literal>
                                    <asp:Literal ID="literalTotal" runat="server" Text="0"></asp:Literal>
                                    <asp:Literal ID="literalRecords" runat="server"></asp:Literal>&nbsp;
                                <asp:Literal ID="literalPageText" runat="server" Text=" - Trang: "></asp:Literal>
                                    <asp:Literal ID="literalCurrentPage" runat="server" Text="1"></asp:Literal>
                                    <asp:Literal ID="literalOfText" runat="server" Text=" trên "></asp:Literal>
                                    <asp:Literal ID="literalPages" runat="server"></asp:Literal>
                                </td>
                                <td style="text-align: right" width="30%">
                                    <asp:Panel ID="panelNavigation" runat="server">
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" style="text-align: center" valign="top">
                                    <b>
                                        <asp:Literal ID="litError" runat="server"></asp:Literal></b></td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 1px; height: 351px" valign="top"></td>
                </tr>
                <tr>
                    <td align="center" colspan="4">
                        <uc1:rcBottom id="RcvBottom1" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
