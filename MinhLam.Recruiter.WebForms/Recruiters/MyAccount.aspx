<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyAccount.aspx.cs" Inherits="MinhLam.Recruiter.WebForms.Recruiters.MyAccount" %>

<%@ Register Src="~/Recruiters/rcTop.ascx" TagPrefix="uc1" TagName="rcTop" %>
<%@ Register Src="~/Recruiters/rcMenu.ascx" TagPrefix="uc1" TagName="rcMenu" %>
<%@ Register Src="~/Recruiters/rcBanner.ascx" TagPrefix="uc1" TagName="rcBanner" %>
<%@ Register Src="~/Recruiters/rcRight.ascx" TagPrefix="uc1" TagName="rcRight" %>
<%@ Register Src="~/Recruiters/rcBottom.ascx" TagPrefix="uc1" TagName="rcBottom" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>::Tài khoản của tôi</title>
    <link href="Css/newstyle.css" rel="stylesheet" />
    <link href="Css/style.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>
<body topmargin="0" leftmargin="0" bottommargin="0" rightmargin="0" style="font-size: 12pt">
    <form id="form1" runat="server">
        <div title="Tài khoản của bạn">
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
                    <td style="width: 3px; height: 351px">
                    </td>
                    <td style="width: 600px; height: 351px" valign="top">
                        <table style="width: 100%">
                            <tr>
                                <td style="height: 21px; width: 100%;" colspan="2">
                                    <asp:Image id="Image2" runat="server" ImageUrl="Icons/titlenote.gif"></asp:Image> 
                                    <asp:Label ID="lblAccount" runat="server" Font-Bold="True" Text="Tài khoản của tôi" 
                                        Width="394px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                 <td colspan="2" style="height: 21px; width: 100%; text-align: left;">
                                     <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                         <tr valign="top">
                                            <td style="width: 100%">
                                                <table border="0" cellpadding="5" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td class="text_normal" colspan="2" valign="top" 
                                                            style="text-align: left">
                                                            Mẹo hồ sơ xin việc: 
                                                            Bạn đã từng cập nhật quy trình xin việc.
                                                            Một trong những quota công việc của bạn đang trống do
                                                            đó bạn phải mua một gói công việc mới.
                                                       </td>
                                                    </tr>
                                                   
                                                </table>
                                            </td>
                                        </tr>
                                        <tr valign="top">
                                            <td style="width: 100%; text-align: center;">
                                                <table border="0" cellpadding="0" cellspacing="1" width="100%">
                                                    <tr>
                                                        <td>
                                                            <img border="0" height="1" src="Images/blank.gif" width="3" />
                                                        </td>
                                                        <td bgcolor="#003399" valign="top">
                                                            <table border="0" cellpadding="5" cellspacing="1" width="100%">
                                                                <tr>
                                                                     <td bgcolor="#e3e3e3" width="70%">
                                                                        <table bgcolor="#e5f4ff" border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                            <tr>
                                                                                <td align="left" bgcolor="#e3e3e3" class="content">
                                                                                    <b>Tên công ty</b></td>
                                                                                <td align="right" bgcolor="#e3e3e3" class="content-sm">
                                                                                    (Nhấp vào tên công ty để xem chi tiết tài khoản)
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                    <td align="middle" bgcolor="#e3e3e3" class="content-sm" style="text-align: center"
                                                                        width="5%">
                                                                        Bật đăng bài
                                                                    </td>
                                                                    <td align="middle" bgcolor="#e3e3e3" class="content-sm" 
                                                                        style="width: 5%; text-align: center">
                                                                        &nbsp;Ngày đăng ký&nbsp;
                                                                    </td>
                                                                    <td align="middle" bgcolor="#e3e3e3" class="content-sm" 
                                                                        width="5%" style="text-align: center">
                                                                    &nbsp;Lần đăng nhập cuối</td>
                                                                </tr>
                                                                <tr style="color: #0000ff; text-decoration: underline">
                                                                    <td align="left" bgcolor="#ffffff" class="label" style="text-decoration: underline"
                                                                        width="70%">
                                                                        <table border="0" cellpadding="2" cellspacing="0" style="width: 88%">
                                                                            <tr>
                                                                                <td align="left" class="label" valign="top" style="width: 268px">
                                                                                    <asp:HyperLink ID="hyperLinkTitle" runat="server" 
                                                                                        ToolTip="Tiêu đề hồ sơ">[Tên công ty]</asp:HyperLink>
                                                                                    <a href="jmyresume.aspx?type=edit&rsid=124253">
                                                                                        <b><span style="color: #0000ff"></span></b></a>
                                                                                </td>
                                                                                <td style="color: #0000ff; width: 37px;">
                                                                                    <asp:Image ID="imgRequiredField" runat="server" 
                                                                                        ImageUrl="Icons/flash.gif" Visible="False" 
                                                                                        ToolTip="Xin nhập thêm thông  tin cho hồ sơ này" /></td>
                                                                                <td align="right" style="color: #0000ff" width="120px">
                                                                                    <asp:HyperLink ID="hylRquiredField" runat="server" 
                                                                                        Visible="False" Width="100%">yêu cầu cho mua gói hồ sơ
                                                                                    </asp:HyperLink>
                                                                                    <a class="content-sm" 
                                                                                        href="jeresume.aspx?type=edit&rsid=124253">
                                                                                        <span style="color: #0000ff"></span>
                                                                                    </a>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                    <td align="middle" bgcolor="#ffffff" style="color: #0000ff; text-decoration: underline"
                                                                        width="5%">
                                                                        <asp:Literal ID="litEnableForPosting" runat="server"></asp:Literal>
                                                                    </td>
                                                                     <td align="middle" bgcolor="#ffffff" style="color: #0000ff; text-decoration: underline; width: 2%;">
                                                                        <asp:Literal ID="litRegisterDate" runat="server"></asp:Literal>
                                                                     </td>
                                                                    <td align="middle" bgcolor="#ffffff" style="color: #0000ff; text-decoration: underline; text-align: center;"
                                                                        width="5%">
                                                                        <asp:Literal ID="litLastLogin" runat="server"></asp:Literal>
                                                                    </td>
                                                                 </tr>
                                                                <tr style="color: #0000ff; text-decoration: underline">
                                                                    <td align="left" bgcolor="#ffffff" class="label" 
                                                                        colspan="4" style="text-decoration: underline">
                                                                        <asp:Literal ID="literalWarning" runat="server"></asp:Literal>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" bgcolor="#ffffff" colspan="5" valign="top" >
                                                                        <table border="0" cellpadding="5" cellspacing="0" width="100%">
                                                                            <tr>
                                                                                <td valign="top" width="100%">
                                                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                                        <tr>
                                                                                            <td align="left" style="height: 14px" width="156">
                                                                                                Loại tài khoản:</td>
                                                                                            <td align="left" style="height: 14px" width="464">
                                                                                             <asp:Literal ID="litAccountType" runat="server"></asp:Literal></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" style="height: 14px" width="156">
                                                                                                RCV Đại lý:
                                                                                            </td>
                                                                                            <td align="left" style="height: 14px" width="464">
                                                                                            <asp:Literal ID="litAgency" runat="server"></asp:Literal></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" style="height: 14px" width="156">
                                                                                            </td>
                                                                                            <td align="left" style="height: 14px" width="464">
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" width="156" style="height: 14px">
                                                                                                Số lần đăng bài còn lại:</td>
                                                                                            <td align="left" width="464" style="height: 14px">
                                                                                                <asp:Literal ID="litJobPostingBalance" runat="server"></asp:Literal></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" class="content-sm" width="156" style="height: 14px">
                                                                                                Số lần xem hồ sơ còn lại:</td>
                                                                                            <td align="left" class="content-sm" width="464" style="height: 14px">
                                                                                                <asp:Literal ID="litResumeViewingBalance" runat="server"></asp:Literal></td>
                                                                                        </tr>
                                                                                         <tr>
                                                                                            <td align="left" class="content-sm" style="height: 14px" width="156">
                                                                                                Số giới hạn để đăng:</td>
                                                                                            <td align="left" class="content-sm" style="height: 14px" width="464">
                                                                                                <asp:Literal ID="litAvailableForPosting" runat="server"></asp:Literal></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" class="content-sm" width="156" style="height: 14px">
                                                                                                Số giới hạn để xem:</td>
                                                                                            <td align="left" class="content-sm" width="464" style="height: 14px">
                                                                                                <asp:Literal ID="litAvailableForViewing" runat="server"></asp:Literal></td>
                                                                                        </tr>
                                                                                         <tr>
                                                                                            <td colspan="2">
                                                                                                <img border="0" height="8" 
                                                                                                    src="Images/spacer.gif" width="1" />
                                                                                            </td>
                                                                                        </tr>
                                                                                         <tr>
                                                                                            <td align="left" class="content-sm" width="156" style="height: 16px">
                                                                                                Thống kê tài khoản:</td>
                                                                                            <td align="left" class="content-sm" width="464" style="height: 16px">
                                                                                                <a href="jsdo.aspx?type=statistics&rsid=122628"><span style="color: #0000ff"></span></a>
                                                                                                <asp:LinkButton OnClick="lbtResetStatistics_Click" ID="lbtResetStatistics" runat="server">Reset Thống kê</asp:LinkButton>
                                                                                            </td>
                                                                                        </tr>
                                                                                         <tr>
                                                                                            <td align="left" class="content-sm" nowrap="nowrap" width="156" style="height: 14px">
                                                                                                - Số lần xem bởi người tìm việc:</td>
                                                                                            <td align="left" class="content-sm" width="464" style="height: 14px">
                                                                                                <asp:Literal ID="litHitViewed" runat="server"></asp:Literal></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" class="content-sm" width="156" style="height: 14px">
                                                                                                - Số công việc đăng:</td>
                                                                                            <td align="left" class="content-sm" width="464" style="height: 14px">
                                                                                                <asp:Literal ID="litJobNo" runat="server"></asp:Literal></td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <asp:Literal ID="literalError" runat="server"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr valign="top">
                                            <td style="width: 100%">
                                            </td>
                                        </tr>
                                     </table>
                                 </td>
                             </tr>
                        </table>
                    </td>
                     <td style="width: 1px; height: 351px" valign="top">
                    </td>
                    <td style="width: 160px; height: 351px" valign="top" align="right">
                        <uc1:rcRight ID="rcvRight1" runat="server" />
                    </td>
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
