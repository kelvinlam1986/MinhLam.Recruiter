<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="MinhLam.Recruiter.WebForms.Recruiters.Profile" %>

<%@ Register Src="~/Recruiters/rcTop.ascx" TagPrefix="uc1" TagName="rcTop" %>
<%@ Register Src="~/Recruiters/rcMenu.ascx" TagPrefix="uc1" TagName="rcMenu" %>
<%@ Register Src="~/Recruiters/rcBanner.ascx" TagPrefix="uc1" TagName="rcBanner" %>
<%@ Register Src="~/Recruiters/rcRight.ascx" TagPrefix="uc1" TagName="rcRight" %>
<%@ Register Src="~/Recruiters/rcBottom.ascx" TagPrefix="uc1" TagName="rcBottom" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>::Company Profile</title>
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
                    <td style="width: 610px; height: 351px" valign="top" align="left">
                        <table>
                            <tr>
                                <td style="height: 351px;" valign="top" align="left" width="100%">
                                    <table style="width: 100%">
                                        <tr>
                                            <td colspan="2" style="height: 21px">
                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/Recruiters/Icons/titlenote.gif" />
                                                <strong>Thông tin công ty</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="width: 113px">
                                                <strong>Địa chỉ:</strong></td>
                                            <td>
                                                <asp:TextBox ID="txtAddress" runat="server" Width="280px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAddress"
                                                    ErrorMessage="Địa chỉ không hợp lệ" Width="5px">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="width: 113px">
                                                <strong>Người liên hệ:</strong></td>
                                            <td>
                                                <asp:TextBox ID="txtContactName" runat="server" Width="280px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtContactName"
                                                    ErrorMessage="Tên người liên hệ không chính xác" Width="5px">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="width: 113px; text-align: left">
                                                <strong>Số điện thoại:</strong></td>
                                            <td>
                                                <asp:TextBox ID="txtTel" runat="server" MaxLength="20" Width="280px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtTel"
                                                    ErrorMessage="Bạn phải nhập số điện thoại" Width="5px">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="width: 113px; height: 16px; text-align: left">
                                                <strong>Số Fax:</strong></td>
                                            <td style="height: 16px">
                                                <asp:TextBox ID="txtFax" runat="server" MaxLength="20" Width="280px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="text-align: left; width: 113px;" nowrap="nowrap">
                                                <strong>Ngày thành lập:</strong></td>
                                            <td>
                                                <asp:TextBox ID="txtDOE" runat="server" Width="150px" TextMode="Date"></asp:TextBox>
                                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtDOE"
                                                    ErrorMessage="Ngày thành lập không hợp lệ" Operator="DataTypeCheck" Type="Date">*</asp:CompareValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="width: 113px; text-align: left">
                                                <strong>Quốc gia:</strong></td>
                                            <td>
                                                <asp:DropDownList ID="ddlCountry" runat="server" Width="126px">
                                                    <asp:ListItem>Vietnam</asp:ListItem>
                                                </asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="width: 113px; height: 26px; text-align: left">
                                                <strong>Tỉnh thành:</strong></td>
                                            <td nowrap="nowrap" style="height: 26px">
                                                <asp:DropDownList ID="ddlProvince" runat="server" Width="126px">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlProvince"
                                                    ErrorMessage="Bạn phải chọn tỉnh thành">*</asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="width: 113px; height: 26px; text-align: left">
                                                <strong>Thành phố:</strong></td>
                                            <td nowrap="nowrap" style="height: 26px">
                                                <asp:TextBox ID="txtCity" runat="server" Width="230px"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 113px"></td>
                                            <td nowrap="nowrap">
                                                <asp:Button ID="btnNext" runat="server" OnClick="btnNext_Click" Text="Lưu" Width="58px" />&nbsp;
                                            <input id="Button1" onclick="window.history.go(-1);" style="width: 58px" type="button"
                                                value="Trở về" /></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 113px"></td>
                                            <td nowrap="nowrap">
                                                <asp:Literal ID="literalError" runat="server"></asp:Literal>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 1px; height: 351px" valign="top"></td>
                    <td style="width: 160px; height: 351px" valign="top" align="right">
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
