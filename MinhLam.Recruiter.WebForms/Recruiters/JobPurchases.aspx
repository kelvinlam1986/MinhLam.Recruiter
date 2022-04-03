<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JobPurchases.aspx.cs" Inherits="MinhLam.Recruiter.WebForms.Recruiters.JobPurchases" %>

<%@ Register Src="~/Recruiters/rcTop.ascx" TagPrefix="uc1" TagName="rcTop" %>
<%@ Register Src="~/Recruiters/rcMenu.ascx" TagPrefix="uc1" TagName="rcMenu" %>
<%@ Register Src="~/Recruiters/rcBanner.ascx" TagPrefix="uc1" TagName="rcBanner" %>
<%@ Register Src="~/Recruiters/rcRight.ascx" TagPrefix="uc1" TagName="rcRight" %>
<%@ Register Src="~/Recruiters/rcBottom.ascx" TagPrefix="uc1" TagName="rcBottom" %>
<%@ Register Src="~/Recruiters/rcLeft.ascx" TagPrefix="uc1" TagName="rcLeft" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>::Đặt mua</title>
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
                                </td>
                                <td align="right">
                                    <asp:HyperLink ID="hyperLinkPurchase" runat="server" Font-Bold="True" NavigateUrl="~/Recruiters/jobpurchase.aspx"
                                        Width="60px">Đặt mua</asp:HyperLink>&nbsp;
                                    <asp:HyperLink ID="hyperLinkPrint" runat="server" Font-Bold="True" NavigateUrl="#"
                                        Width="44px">In</asp:HyperLink>&nbsp;
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
                                        PageSize="20" Width="100%">
                                        <PagerSettings Mode="NumericFirstLast" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="#">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkPackageID" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="PackageID" HeaderText="Package ID" SortExpression="PackageID">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ContactName" HeaderText="Contact Name" SortExpression="ContactName" />
                                            <asp:BoundField DataField="OrdersDate" HeaderText="Order Date" SortExpression="OrderDate">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Quantity" HeaderText="Quantity">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Package" HeaderText="Package">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Price" HeaderText="Price">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Currency" HeaderText="Currency">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="PaymentBy" HeaderText="Payment By" />
                                            <asp:BoundField DataField="Status" HeaderText="Status">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="PaidDate" HeaderText="Paid Date" />
                                        </Columns>
                                    </asp:GridView>
                                    &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="text-align: left" valign="top" width="70%">&nbsp;
                                    <asp:Button ID="btnDelete" runat="server" Text="Xóa" />&nbsp;
                                &nbsp;&nbsp;<br />
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
                        <uc1:rcBottom ID="RcvBottom1" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
