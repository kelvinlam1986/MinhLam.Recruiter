<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="MinhLam.Recruiter.WebForms.Recruiters.ForgotPassword" %>

<%@ Register Src="~/Recruiters/rcTop.ascx" TagPrefix="uc1" TagName="rcTop" %>
<%@ Register Src="~/Recruiters/rcMenu.ascx" TagPrefix="uc1" TagName="rcMenu" %>
<%@ Register Src="~/Recruiters/rcBanner.ascx" TagPrefix="uc1" TagName="rcBanner" %>
<%@ Register Src="~/Recruiters/rcRight.ascx" TagPrefix="uc1" TagName="rcRight" %>
<%@ Register Src="~/Recruiters/rcBottom.ascx" TagPrefix="uc1" TagName="rcBottom" %>
<%@ Register Src="~/Recruiters/rcLeft.ascx" TagPrefix="uc1" TagName="rcLeft" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>::Quên mật khẩu</title>
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
                    <td style="width: 160px; height: 351px" valign="top">
                        <uc1:rcLeft ID="RcLeft1" runat="server" />
                    </td>
                    <td style="width: 3px; height: 351px"></td>
                    <td style="width: 450px; height: 351px" valign="top">
                        <table style="width: 100%">
                            <tr>
                                <td colspan="2" style="height: 21px">
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Recruiters/Icons/titlenote.gif" />
                                    <strong>Quên mật khẩu</strong>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 21px; width: 117%;"></td>
                                <td style="width: 312px; height: 21px">
                                    <asp:Label ID="lblHeader" runat="server" Text="Để phục hồi mật khẩu vui lòng nhập email của bạn"
                                        Width="353px" Font-Bold="False"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 117%">
                                    <strong>Email:</strong>
                                </td>
                                <td style="width: 312px">
                                    <asp:TextBox ID="txtEmail" runat="server" Width="280px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail"
                                        ErrorMessage="Bạn phải nhập email">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                                        ErrorMessage="Địa chỉ email của bạn không đúng định dạng"
                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="text-align: left; width: 117%;" nowrap="noWrap">
                                    <strong>Tên công ty:</strong></td>
                                <td style="width: 312px">
                                    <asp:TextBox ID="txtCompanyName" runat="server" Width="280px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCompanyName"
                                        ErrorMessage="Bạn phải nhập tên công ty">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left; width: 117%;" align="left">
                                    <strong>Tên tiếng Anh:</strong></td>
                                <td style="width: 312px">
                                    <asp:TextBox ID="txtEnglishName" runat="server" Width="280px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEnglishName"
                                        ErrorMessage="Bạn phải nhập tên tiếng Anh">*</asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td style="width: 117%" nowrap="noWrap" align="left">
                                    <strong>Ngày thành lập:</strong></td>
                                <td style="width: 312px" nowrap="noWrap">
                                    <asp:TextBox ID="txtDOE" runat="server" Width="280px" TextMode="Date"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDOE"
                                        ErrorMessage="Bạn phải nhập ngày thành lập">*</asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td style="width: 117%"></td>
                                <td style="width: 312px">
                                    <asp:Button ID="btnOK" runat="server" Text="OK" Width="50px" OnClick="btnOK_Click" />
                                    <input id="btnReset" type="reset" value="Reset" /></td>
                            </tr>
                            <tr>
                                <td style="width: 117%"></td>
                                <td nowrap="nowrap" style="width: 312px">&nbsp;<asp:Literal ID="literalError" runat="server"></asp:Literal></td>
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
