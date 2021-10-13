<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="MinhLam.Recruiter.WebForms.Recruiters.Logout" %>

<%@ Register Src="~/Recruiters/rcTop.ascx" TagPrefix="uc1" TagName="rcTop" %>
<%@ Register Src="~/Recruiters/rcMenu.ascx" TagPrefix="uc1" TagName="rcMenu" %>
<%@ Register Src="~/Recruiters/rcBanner.ascx" TagPrefix="uc1" TagName="rcBanner" %>
<%@ Register Src="~/Recruiters/rcRight.ascx" TagPrefix="uc1" TagName="rcRight" %>
<%@ Register Src="~/Recruiters/rcBottom.ascx" TagPrefix="uc1" TagName="rcBottom" %>
<%@ Register Src="~/Recruiters/rcLeft.ascx" TagPrefix="uc1" TagName="rcLeft" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>::Đăng xuất</title>
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
                    <td style="width: 3px; height: 351px"></td>
                    <td style="width: 610px; height: 351px" valign="top">
                        <table style="width: 100%">
                            <tr>
                                <td style="height: 21px" colspan="1">
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Recruiters/Icons/titlenote.gif"></asp:Image>
                                    <strong>Đăng xuất</strong>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 312px; height: 21px">Bạn đã đăng xuất khỏi Timviecnhanh.com,
                                    để đăng nhập xin click vào nút bên dưới<br />
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 312px; height: 21px">
                                    <input id="Button1" style="width: 158px" type="button"
                                        value="Trở về" onclick="window.open('Login.aspx', target='_main');" /></td>
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
