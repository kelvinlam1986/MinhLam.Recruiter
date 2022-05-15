<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JobPurchase.aspx.cs" Inherits="MinhLam.Recruiter.WebForms.Recruiters.JobPurchase" %>

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
                                                    <asp:Literal ID="litTitle" runat="server" Text="Tin và những gói xem"></asp:Literal>&nbsp;</b></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" colspan="2">
                                    <hr size="1" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" colspan="2">
                                    <table style="width: 745px">
                                        <tr>
                                            <td>Tên liên hệ:</td>
                                            <td>
                                                <asp:TextBox ID="txtContactName" runat="server" MaxLength="100" ValidationGroup="Purchase"
                                                    Width="256px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtContactName"
                                                    ValidationGroup="Purchase">*</asp:RequiredFieldValidator></td>
                                            <td>Tổng số tin:</td>
                                            <td>
                                                <asp:Literal ID="literalJobs" runat="server"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Thanh toán bởi:</td>
                                            <td>
                                                <asp:DropDownList ID="ddlPaymentBy" runat="server" ValidationGroup="Purchase" Width="262px">
                                                    <asp:ListItem Value="ATM Transfer" Selected="True">Chuyển khoản ATM</asp:ListItem>
                                                    <asp:ListItem Value="Cash">Tiền mặt</asp:ListItem>
                                                    <asp:ListItem Value="Bank Transfer">Chuyển khoản ngân hàng</asp:ListItem>
                                                </asp:DropDownList></td>
                                            <td>Tổng số lượt xem:</td>
                                            <td>
                                                <asp:Literal ID="literalViews" runat="server"></asp:Literal></td>
                                        </tr>
                                        <tr>
                                            <td>Loại tiền thanh toán:</td>
                                            <td>
                                                <asp:DropDownList ID="ddlCurrency" runat="server" ValidationGroup="Purchase">
                                                    <asp:ListItem Value="USD">USD</asp:ListItem>
                                                    <asp:ListItem Value="VND">VND</asp:ListItem>
                                                </asp:DropDownList></td>
                                            <td>Tổng discount:</td>
                                            <td>
                                                <asp:Literal ID="literalDiscount" runat="server"></asp:Literal></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">Bạn có thể thanh toán đến tài khoản ngân hàng #12345678 Ngân hàng ABC nếu bạn thanh toán bằng cách chuyển khoản/
                                                Chuyển khoản ATM</td>
                                            <td>Số tiền thanh toán:</td>
                                            <td>
                                                <asp:Literal ID="literalAmount" runat="server"></asp:Literal>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 14px" colspan="2"><font color="red">
                                            Chú ý: Bạn chí có thể xem 10 đơn ứng tuyển trên 1 công việc.</font></td>
                                            <td style="height: 14px"></td>
                                            <td style="height: 14px"></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" style="text-align: left" valign="top">
                                    <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                        PageSize="20" Width="100%" OnRowDataBound="GridView1_RowDataBound" OnSorting="GridView1_Sorting">
                                        <PagerSettings Mode="NumericFirstLast" />
                                        <Columns>
                                            <asp:BoundField DataField="PackageID" HeaderText="#"  ShowHeader="false">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <HeaderStyle HorizontalAlign="Center" Width="20px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Program" HeaderText="Chương trình" SortExpression="Program" />
                                            <asp:BoundField DataField="Name" HeaderText="Tên gói" SortExpression="Name" />
                                            <asp:BoundField DataField="Package" HeaderText="ĐVT" SortExpression="Package" >
                                                <ItemStyle HorizontalAlign="Center" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Price" HeaderText="Giá" SortExpression="Price">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Discount" HeaderText="%Giảm giá" SortExpression="Discount">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Currency" HeaderText="Tiền tệ" SortExpression="Currency">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Đặt mua">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtPurchase" runat="server" MaxLength="2" Width="52px"></asp:TextBox>
                                                    <asp:RangeValidator ID="rv" runat="server" ControlToValidate="txtPurchase"></asp:RangeValidator>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="MinQuantity" ShowHeader="False" />
                                            <asp:BoundField DataField="MaxQuantity" ShowHeader="False" />
                                            <asp:BoundField DataField="Type" ShowHeader="False" />
                                        </Columns>
                                    </asp:GridView>
                                    &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="text-align: left; width=25%" valign="top">
                                    <asp:Button
                                        ID="btnSave" runat="server" Text="Đặt mua" ValidationGroup="Đặt mua" Width="70px" OnClick="btnSave_Click" />&nbsp;
                                <asp:Button
                                    ID="btnCalculate" runat="server" Text="Tính toán" ValidationGroup="Tính toán" Width="70px" OnClick="btnCalculate_Click" /></td>
                                <td style="text-align: right" width="75%"></td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" style="text-align: center" valign="top">
                                    <b><font color="red">
                                    <asp:Literal ID="litError" runat="server"></asp:Literal></font></b></td>
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
