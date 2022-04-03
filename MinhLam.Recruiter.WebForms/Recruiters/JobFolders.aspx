<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JobFolders.aspx.cs" Inherits="MinhLam.Recruiter.WebForms.Recruiters.JobFolders" %>

<%@ Register Src="~/Recruiters/rcTop.ascx" TagPrefix="uc1" TagName="rcTop" %>
<%@ Register Src="~/Recruiters/rcMenu.ascx" TagPrefix="uc1" TagName="rcMenu" %>
<%@ Register Src="~/Recruiters/rcBanner.ascx" TagPrefix="uc1" TagName="rcBanner" %>
<%@ Register Src="~/Recruiters/rcRight.ascx" TagPrefix="uc1" TagName="rcRight" %>
<%@ Register Src="~/Recruiters/rcBottom.ascx" TagPrefix="uc1" TagName="rcBottom" %>
<%@ Register Src="~/Recruiters/rcLeft.ascx" TagPrefix="uc1" TagName="rcLeft" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>::Thư mục</title>
    <link href="Css/newstyle.css" rel="stylesheet" />
    <link href="Css/style.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>
<body topmargin="0" leftmargin="0" bottommargin="0" rightmargin="0" style="font-size: 12pt">
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
                                                    <asp:Literal ID="litTitle" runat="server" Text="Thư mục tin"></asp:Literal>&nbsp;</b></td>
                                        </tr>
                                    </table>
                                    Chú ý: Bạn chỉ có thẻ tạo tối đa 15 thư mục</td>
                            </tr>
                            <tr>
                                <td align="left" colspan="2">
                                    <hr size="1" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" style="text-align: left" valign="top">
                                    <asp:GridView ID="GridView1" runat="server" AllowSorting="True"
                                        AutoGenerateColumns="False"
                                        PageSize="20" Width="100%"
                                        OnSorting="GridView1_Sorting"
                                        OnRowCreated="GridView1_RowCreated"
                                        >
                                        <Columns>
                                            <asp:TemplateField HeaderText="#">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkFolderID" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        <asp:BoundField DataField="FolderId" HeaderText="Mã số" SortExpression="FolderId" ShowHeader="false"/>
                                        <asp:BoundField DataField="FolderName" HeaderText="Tên thư mục" SortExpression="FolderName" />
                                        <asp:BoundField DataField="FolderDescription" HeaderText="Mô tả" />
                                        <asp:BoundField DataField="Jobs" HeaderText="Số tin" SortExpression="Jobs" >
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                    &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="center" style="text-align: left" valign="top" width="25%">
                                    &nbsp;
                                    <asp:Button ID="btnDelete" runat="server" Text="Xóa" OnClick="btnDelete_Click" />&nbsp;&nbsp;
                                    <asp:Literal ID="literalTotalText" runat="server" Text="Total folders: "></asp:Literal>
                                    <asp:Literal ID="literalTotal" runat="server" Text="0"></asp:Literal>  
                                     &nbsp; &nbsp; &nbsp;
                                </td>
                                <td style="text-align: right" width="75%">
                                    Tên: <asp:TextBox ID="txtName" runat="server" Width="112px" MaxLength="10"></asp:TextBox>
                                    Mô tả: &nbsp;<asp:TextBox ID="txtDescription" runat="server" Width="112px" MaxLength="50"></asp:TextBox>
                                    Quản lý: <asp:TextBox ID="txtManager" runat="server" Width="112px" MaxLength="50"></asp:TextBox>&nbsp;
                                    <asp:Button ID="btnSave" runat="server" Text="Thêm mới" OnClick="btnSave_Click" />
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
                        <uc1:rcBottom ID="RcvBottom1" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
