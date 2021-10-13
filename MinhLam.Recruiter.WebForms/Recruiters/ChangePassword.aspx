<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="MinhLam.Recruiter.WebForms.Recruiters.ChangePassword" %>

<%@ Register Src="~/Recruiters/rcTop.ascx" TagPrefix="uc1" TagName="rcTop" %>
<%@ Register Src="~/Recruiters/rcMenu.ascx" TagPrefix="uc1" TagName="rcMenu" %>
<%@ Register Src="~/Recruiters/rcBanner.ascx" TagPrefix="uc1" TagName="rcBanner" %>
<%@ Register Src="~/Recruiters/rcRight.ascx" TagPrefix="uc1" TagName="rcRight" %>
<%@ Register Src="~/Recruiters/rcBottom.ascx" TagPrefix="uc1" TagName="rcBottom" %>
<%@ Register Src="~/Recruiters/rcLeft.ascx" TagPrefix="uc1" TagName="rcLeft" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>::Đổi mật khẩu</title>
    <link href="Css/newstyle.css" rel="stylesheet" />
    <link href="Css/style.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>
<body topmargin="0" leftmargin="0" bottommargin="0" rightmargin="0" style="font-size: 12pt" alink="#0">
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
                                    <strong>Thay đổi mật khẩu</strong>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 21px;" width="35%"></td>
                                <td style="width: 312px; height: 21px">
                                    <asp:Label ID="lblHeader" runat="server" Text="Vui lòng nhập mật khẩu hiện tại và mật khẩu mới."
                                        Width="289px" Font-Bold="False"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="left" style="height: 40px;" width="35%" nowrap>
                                    <strong>Mật khẩu cũ:</strong></td>
                                <td style="width: 312px; height: 40px;">
                                    <asp:TextBox ID="txtOldPassword" runat="server" Width="280px" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtOldPassword"
                                        ErrorMessage="Vui lòng nhập mật khẩu">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="text-align: left;" width="35%" nowrap>
                                    <strong>Mật khẩu mới:</strong></td>
                                <td style="width: 312px">
                                    <asp:TextBox ID="txtPassword" runat="server" Width="280px" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword"
                                        ErrorMessage="Vui lòng nhập mật khẩu mới">*</asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td style="text-align: left;" width="35%" nowrap>
                                    <strong>Xác nhận mật khẩu:</strong></td>
                                <td style="width: 312px">
                                    <asp:TextBox ID="txtRetype" runat="server" Width="280px" TextMode="Password"></asp:TextBox>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtRetype"
                                        ControlToValidate="txtPassword" ErrorMessage="Mật khẩu nhập lại không giống">*</asp:CompareValidator></td>
                            </tr>
                            <tr>
                                <td width="35%"></td>
                                <td style="width: 312px">
                                    <asp:Button ID="btnOK" runat="server" Text="Thay đổi" Width="58px" OnClick="btnOK_Click" />
                                    <input id="btnReset" type="reset" value="Reset" /></td>
                            </tr>
                            <tr>
                                <td width="35%"></td>
                                <td nowrap="nowrap" style="width: 312px">
                                    <font color="red"><asp:Literal ID="literalError" runat="server"></asp:Literal></font></td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 1px; height: 351px" valign="top"></td>
                    <td style="width: 160px; height: 351px" valign="top">
                        <uc1:rcRight id="rcvRight1" runat="server" />
                    </td>
                </tr>
                <tr>
              <td align="center" colspan="5">
                  <uc1:rcBottom ID="RcvBottom1" runat="server" />
                </td>
            </tr>
            </table>
        </div>
    </form>
</body>
</html>
