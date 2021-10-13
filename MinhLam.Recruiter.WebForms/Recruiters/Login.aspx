<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MinhLam.Recruiter.WebForms.Recruiters.Login" %>

<%@ Register src="rcTop.ascx" tagname="rcTop" tagprefix="uc1" %>
<%@ Register src="rcRight.ascx" tagname="rcRight" tagprefix="uc2" %>
<%@ Register src="rcMenu.ascx" tagname="rcMenu" tagprefix="uc3" %>
<%@ Register src="rcBanner.ascx" tagname="rcBanner" tagprefix="uc4" %>
<%@ Register Src="~/Recruiters/rcBottom.ascx" TagPrefix="uc1" TagName="rcBottom" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>::Đăng nhập</title>
    <link href="Css/newstyle.css" rel="stylesheet" />
    <link href="Css/style.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>
<body topmargin="0" leftmargin="0" bottommargin="0" rightmargin="0" style="font-size: 12pt">
    <form id="form1" runat="server">
        <div>
            <table align="center" style="width: 960px" title="Xinviecnhanh">
                <tr>
                    <td valign="top" colspan="3">
                         <uc1:rcTop ID="RcvTop1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="3" valign="top">
                        <uc4:rcBanner ID="RcBanner1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 21px" valign="top">
                        <uc3:rcMenu ID="RcMenu1" runat="server" />
                    </td>
                </tr>
                <tr>
                     <td style="width: 610px; height: 351px" valign="top">
                         <table style="width: 100%">
                              <tr>
                                <td style="height: 21px" colspan="2">
                                    <strong>
                                        <asp:Image ID="Image1" runat="server" ImageUrl="Icons/titlenote.gif" />
                                        Đăng nhập
                                    </strong>
                                </td>
                              </tr>
                             <tr>
                                <td   colspan="2">
                                    <hr size="1"/>
                                    <asp:Literal ID="literalError" runat="server"></asp:Literal></td>
                             </tr>
                             <tr>
                                <td style="height: 21px; width: 20%;">
                                </td>
                                <td style="width: 396px; height: 21px">
                                    <asp:Label ID="lblHeader" runat="server" 
                                        Text="Để đăng nhập, Xin nhập Email và Mật khẩu bên dưới:"
                                        Width="309px" Font-Bold="False"></asp:Label></td>
                            </tr>
                             <tr>
                                <td style="width: 20%">
                                    <strong>Email:</strong></td>
                                <td style="width: 396px">
                                    <asp:TextBox ID="txtEmail" runat="server" Width="220px" MaxLength=50></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator></td>
                            </tr>
                            <tr>
                                <td style="width: 20%">
                                    <strong>Mật khẩu:</strong></td>
                                <td style="width: 396px">
                                    <asp:TextBox ID="txtPassword" runat="server" MaxLength="20"  
                                        TextMode="Password" Width="220px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                                        runat="server" ControlToValidate="txtPassword">*</asp:RequiredFieldValidator></td>
                            </tr>
                             <tr>
                                <td style="width: 20%">
                                </td>
                                <td style="width: 396px">
                                    <asp:Button ID="btnLogin" runat="server" Text="OK" 
                                        Width="50px" OnClick="btnLogin_Click" />
                                    <input id="btnReset" type="reset" value="Reset" /></td>
                            </tr>
                             <tr>
                                <td style="width: 20%">
                                </td>
                                <td nowrap="nowrap" style="width: 396px">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 20%">
                                </td>
                                <td nowrap="nowrap" style="width: 396px">
                                    <asp:CheckBox ID="CheckBoxRememberEmail" 
                                        runat="server" Text="Ghi nhớ email vào máy tính của bạn"
                                        Width="335px" /></td>
                            </tr>
                            <tr>
                                <td style="height: 21px; width: 20%;">
                                </td>
                                <td style="width: 396px; height: 21px;">
                                    ---------------------------------------------------------------------------------------</td>
                            </tr>
                            <tr id="Restrict" runat="server">
                                <td style="width: 20%">
                                </td>
                                <td nowrap="nowrap" style="width: 396px">
                                    <asp:Image ID="imageRestrict" runat="server" /><br />
                                    <asp:Literal ID="literalRestrictText" runat="server" 
                                        Text="Xin nhập những cái bạn thấy ở ảnh trên"></asp:Literal>
                                    <br />
                                    <asp:TextBox ID="txtRestrictText" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" 
                                        runat="server" ControlToValidate="txtRestrictText"
                                        ErrorMessage="*"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                        ControlToValidate="txtRestrictText"
                                        ErrorMessage="Không hợp lệ"></asp:CompareValidator>
                                </td>
                            </tr>
                             <tr>
                                <td style="width: 20%">
                                </td>
                                <td style="width: 396px"  >
                                    &nbsp;<asp:HyperLink ID="HyperLink1" runat="server" 
                                        NavigateUrl="~/Recruiters/forgotpassword.aspx"
                                        Width="118px">Quên mật khẩu ?</asp:HyperLink>
                                    | &nbsp;
                                    <asp:HyperLink ID="HyperLink2" runat="server" 
                                        NavigateUrl="/help.htm" Width="44px">Giúp đỡ</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 20%">
                                </td>
                                <td style="width: 396px">
                                    ----------------------------------------------------------------------------------------</td>
                            </tr>
                             <tr>
                                <td style="width: 20%">
                                </td>
                                 <td style="width: 396px">
                                     Bạn chưa có tài khoản tại Timviecnhanh ?
                                     <br />
                                     <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                         <tr>
                                            <td align="left" class="content">
                                                <b>Để tìm đúng ứng viên, Bạn phải tạo một tài khoản RCV để tìm kiếm online.
                                                </b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <img alt="" height="10" src="Images/blank.gif" width="1" />
                                            </td>
                                        </tr>
                                         <tr>
                                            <td align="left" class="content">
                                                Timviecnhanh có những công cụ mà bạn cần để tuyển dụng ứng viên chất lượng cao
                                                một cách dễ dàng, nhanh chóng, hiệu quả và chi phí hợp lý
                                            </td>
                                        </tr>
                                         <tr>
                                            <td>
                                                <img alt="" height="10" src="Images/blank.gif" width="1" />

                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" class="content">
                                                <li class="content"><b>Quản lý danh sách việc làm (24x7)</b>
                                                </li>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" class="content">
                                                <li class="content">
                                                    <b>Tập trung, tìm kiếm và thuê ứng viên top chất lượng&nbsp;</b> 
                                                </li>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td align="left" class="content">
                                                <li class="content">
                                                    <b>Kiểm tra danh sách ứng quyên thông qua quy trình tuyển dụng &nbsp;</b> 
                                                </li>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" class="content">
                                             <li class="content"><b>Giả chi phí cho việc tuyển dụng </b> </li>
                                            </td>
                                        </tr>
                                     </table>
                                     <br />
                                     <div>
                                           Việc đăng ký thật dể dàng. &nbsp;
                                         <asp:HyperLink ID="HyperLinkNewJobSeeker" runat="server" 
                                             Width="137px" NavigateUrl="~/Recruiters/register.aspx">
                                             Chỉ với 3 bước >>
                                         </asp:HyperLink><br />
                                     </div>
                                 </td>
                             </tr>
                         </table>
                     </td>
                     <td style="width: 1px; height: 351px" valign="top">
                     </td>
                    <td style="width: 160px; height: 351px" valign="top">
                        <uc2:rcRight id="rcvRight1" runat="server"></uc2:rcRight>
                    </td>
                </tr>
                <tr>
                  <td align="center" colspan="3">
                      &nbsp;<uc1:rcBottom runat="server" id="rcBottom" />
                  </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
