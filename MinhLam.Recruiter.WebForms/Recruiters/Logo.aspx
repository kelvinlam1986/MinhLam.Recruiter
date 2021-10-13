<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logo.aspx.cs" Inherits="MinhLam.Recruiter.WebForms.Recruiters.Logo" %>

<%@ Register Src="~/Recruiters/rcTop.ascx" TagPrefix="uc1" TagName="rcTop" %>
<%@ Register Src="~/Recruiters/rcMenu.ascx" TagPrefix="uc1" TagName="rcMenu" %>
<%@ Register Src="~/Recruiters/rcBanner.ascx" TagPrefix="uc1" TagName="rcBanner" %>
<%@ Register Src="~/Recruiters/rcRight.ascx" TagPrefix="uc1" TagName="rcRight" %>
<%@ Register Src="~/Recruiters/rcBottom.ascx" TagPrefix="uc1" TagName="rcBottom" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>::My Account</title>
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
                        <table style="width: 100%">
                            <tr>
                                <td colspan="2" style="height: 21px">
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Recruiters/Icons/titlenote.gif" />
                                    <strong>Logo Công ty</strong>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 21px">Nếu bạn muốn hiển thị logo công ty lên phần mô tả công việc, 
                                    Vui lòng chọn đường dẫn đến file ảnh và click vào nút bên dưới.
                                    <br />
                                    <br />
                                    <table width="100%">
                                        <tr>
                                            <td nowrap="nowrap" style="width: 95px">Logo file:</td>
                                            <td>
                                                <asp:FileUpload ID="fileUpload" runat="server" Width="369px" /></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 95px"></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 95px"></td>
                                            <td>
                                                <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="Upload" /></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 95px"></td>
                                            <td>
                                                <font color="red"><asp:Literal ID="literalError" runat="server"></asp:Literal></font></td>
                                        </tr>
                                    </table>
                                    <br />
                                    <br />
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 312px; height: 21px"></td>
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
