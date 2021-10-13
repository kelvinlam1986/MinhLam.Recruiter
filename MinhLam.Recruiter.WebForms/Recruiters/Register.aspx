<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="MinhLam.Recruiter.WebForms.Recruiters.Register" %>
<%@ Register src="rcBanner.ascx" tagname="rcBanner" tagprefix="uc1" %>
<%@ Register src="rcTop.ascx" tagname="rcTop" tagprefix="uc2" %>
<%@ Register src="rcMenu.ascx" tagname="rcMenu" tagprefix="uc3" %>
<%@ Register src="rcRight.ascx" tagname="rcRight" tagprefix="uc4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title>::Đăng ký mới</title>
        <link href="Css/newstyle.css" rel="stylesheet" />
        <link href="Css/style.css" rel="stylesheet" />
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    </head>
    <body topmargin="0" leftmargin="0" bottommargin="0" rightmargin="0" style="font-size: 12pt">
        <form id="form1" runat="server">
            <div>
                <table align="center" style="width: 960px" title="Xinviecnhanh Tài khoản">
                    <tr>
                        <td valign="top" colspan="5">
                            <uc2:rcTop ID="RcvTop1" runat="server" />
                        </td>
                    </tr>
                     <tr>
                        <td align="center" colspan="5" valign="top">
                            <uc1:rcBanner ID="rcBanner2" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5" style="height: 21px" valign="top">
                            <uc3:rcMenu ID="rcMenu2" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 3px; height: 351px">
                        </td>
                        <td style="width: 603px; height: 351px" valign="top">
                             <table style="width: 100%">
                                 <tr>
                                    <td colspan="2" style="height: 21px">
                                        <asp:Image ID="Image1" runat="server" 
                                            ImageUrl="Icons/titlenote.gif" />
                                        <asp:Label ID="lblHeader" runat="server" 
                                            Font-Bold="True" Text=" Đăng ký"
                                            Width="301px"></asp:Label>
                                    </td>
                                </tr>
                                 <tr>
                                    <td colspan="2">
                                        <asp:Literal ID="literalMessage" runat="server" 
                                            Text="Nếu bạn chưa có tài khoản. Hãy đăng ký tài khoản trên trang chúng tôi. Nó hoàn toàn miễn phí">
                                        </asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 23%; height: 21px">
                                    </td>
                                    <td style="width: 312px; height: 21px">
                                        <span style="color: #003063">Thông tin đăng ký</span>
                                    </td>
                                </tr>
                                 <tr style="color: #003063">
                                    <td align="left" style="width: 23%">
                                        <strong>Email đăng nhập:</strong></td>
                                    <td style="width: 312px">
                                        <asp:TextBox ID="txtEmail" runat="server" 
                                            ValidationGroup="Agree" Width="251px">
                                        </asp:TextBox>
                                        <span style="color: #003063"> </span>
                                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                                            ValidationGroup="Agree"
                                            ForeColor="Red">*</asp:RequiredFieldValidator>&nbsp;
                                        <asp:RegularExpressionValidator ID="revEmail" runat="server" 
                                            ControlToValidate="txtEmail"
                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                            ForeColor="Red"
                                            ValidationGroup="Agree">*</asp:RegularExpressionValidator></td>
                                </tr>
                                <tr id="trPassword" runat="server" style="color: #000000">
                                    <td align="left" style="width: 23%; text-align: left">
                                        <strong>Mật khẩu:</strong></td>
                                    <td style="width: 312px">
                                        <asp:TextBox ID="txtPassword" runat="server" 
                                            TextMode="Password" ValidationGroup="Agree"
                                            Width="251px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" 
                                            ControlToValidate="txtPassword"
                                            ForeColor="Red"
                                            ValidationGroup="Agree">*</asp:RequiredFieldValidator></td>
                                </tr>
                                 <tr id="trRetype" runat="server">
                                    <td align="left" style="width: 23%; text-align: left">
                                        <strong>Nhập lại mật khẩu:</strong></td>
                                    <td style="width: 312px">
                                        <asp:TextBox ID="txtRetype" runat="server" TextMode="Password" 
                                            ValidationGroup="Agree"
                                            Width="251px"></asp:TextBox>
                                        <asp:CompareValidator ID="cvRetype" runat="server" ControlToCompare="txtPassword"
                                            ControlToValidate="txtRetype" ErrorMessage="CompareValidator"
                                            ForeColor="Red"
                                            ValidationGroup="Agree">*</asp:CompareValidator></td>
                                </tr>
                                 <tr>
                                    <td align="left" style="width: 23%; text-align: left">
                                        <strong>Tên công ty:</strong></td>
                                    <td style="width: 312px">
                                        <asp:TextBox ID="txtCompanyName" runat="server" 
                                            ValidationGroup="Agree" Width="251px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" 
                                            ControlToValidate="txtCompanyName"
                                            ForeColor="Red"
                                            ValidationGroup="Agree">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                 <tr>
                                    <td align="left" style="width: 23%; height: 26px; text-align: left">
                                        <strong>Tên tiếng Anh:</strong></td>
                                    <td nowrap="nowrap" style="width: 312px; height: 26px">
                                        <asp:TextBox ID="txtEnglishName" runat="server" 
                                            ValidationGroup="Agree" Width="251px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvLastName" runat="server" 
                                            ControlToValidate="txtEnglishName"
                                            ForeColor="Red"
                                            ValidationGroup="Agree">*</asp:RequiredFieldValidator></td>
                                </tr>
                                 <tr>
                                    <td style="width: 23%; height: 22px; text-align: left" valign="top">
                                        <strong>Loại tài khoản:</strong></td>
                                    <td nowrap="nowrap" style="width: 312px; height: 22px" valign="top">
                                        <asp:RadioButtonList ID="rblType" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Selected="True" Value="0">Công ty thuê nhân viên</asp:ListItem>
                                            <asp:ListItem Value="1">Công ty săn việc</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                 <tr>
                                    <td style="width: 23%; height: 22px; text-align: left" valign="top">
                                    </td>
                                    <td nowrap="nowrap" style="width: 312px; height: 22px" valign="top">
                                        Tôi muốn nhận</td>
                                </tr>
                                <tr>
                                    <td style="width: 23%; height: 22px; text-align: left" valign="top">
                                        <strong></strong>
                                    </td>
                                    <td nowrap="nowrap" style="width: 312px; height: 22px" valign="top">
                                        <asp:CheckBox ID="chkNewLetter" runat="server" 
                                            Checked="True" Text="Thông báo mới qua Email" /></td>
                                </tr>
                                 <tr>
                                    <td style="width: 23%" valign="top">
                                    </td>
                                    <td nowrap="nowrap" style="width: 312px" valign="top">
                                        <asp:CheckBox ID="chkPromotinAlert" runat="server" Checked="True" 
                                            Text="Chương trình khuyến mãi mới" /></td>
                                </tr>
                                <tr>
                                    <td style="width: 23%; height: 33px" valign="top">
                                    </td>
                                    <td nowrap="nowrap" style="width: 312px; height: 33px" valign="top">
                                        <asp:CheckBox ID="chkResumeAlert" runat="server" Checked="True" 
                                            Text="Tin tức hằng tuần tương ứng với hồ sơ của tôi" /></td>
                                </tr>
                                <tr id="trTermofService" runat="server">
                                    <td style="width: 23%; text-align: left" valign="top">
                                        <strong>Điều khoản quy định:</strong></td>
                                    <td nowrap="nowrap" style="width: 312px" valign="top">
                                        <asp:TextBox ID="txtTerm" runat="server" Height="95px" 
                                            TextMode="MultiLine" Width="278px">
                                            Xinviecnhanh.com - Giải pháp cho tuyển dụng
                                            Xinviecnhanh.com có những công cụ cần thiết để bạn tuyển dụng
                                            những ứng viên chất lượng một cách nhanh hơn, tốt hơn tiết kiệm hơn. 
                                            Xinviecnhanh.com sẽ cung cấp cho bạn những công cụ tuyển dụng sau:
                                            Quản lý những Open Job một cách hiệu quả (24x7) 
                                            Tập trung, tìm kiếm và thuê những ứng viên chất lượng và phù hợp nhất
                                            Kiếm tra hồ sơ xuyên suốt quy trình tuyển dụng tư khi nộp hồ sơ cho tới khi gửi thư offer
                                            Nếu bạn chưa có một tài khoản trên trang chúng tôi, xin hãy đăng ký ngay.
                                            Nó hoàn toàn miển phí. Bạn chỉ thanh toán tiền khi bạn cần đăng một công việc
                                        </asp:TextBox>
                                    </td>
                                </tr>
                                <tr id="trAgree" runat="server">
                                    <td style="width: 23%; height: 79px">
                                    </td>
                                    <td nowrap="nowrap" style="width: 312px; height: 79px">
                                        <br />
                                        Khi bạn click "Tồi đồng ý" thì bạn đã đồng ý tất cả những diều khoản tại Xinviecnhanh.com<a href="/terms.htm"
                                            target="tos"> Điều khoản dịch vụ</a> và <a href="/privacy.htm" target="pp">quy chế nội bộ</a>,
                                        và (b) nhận những chú ý cần thiết từ Xinviecnhanh.com.<br />
                                        <br />
                                        <asp:CheckBox ID="chkAgree" runat="server" Text="Tôi đồng ý" ValidationGroup="Agree"
                                            Width="155px" />
                                    </td>
                                </tr>
                                 <tr>
                                    <td style="width: 23%">
                                    </td>
                                    <td nowrap="nowrap" style="width: 312px">
                                        <asp:Button ID="btnSave" runat="server" 
                                            Text="Tôi đồng ý" ValidationGroup="Agree"
                                            Width="72px" OnClick="btnSave_Click" />&nbsp;
                                        <asp:Button ID="btnNotAgree" runat="server" Text="Tôi không đồng ý" Width="104px" />
                                        </td>
                                </tr>
                                <tr>
                                    <td style="width: 23%">
                                    </td>
                                    <td nowrap="nowrap" style="width: 312px;">
                                        <asp:Literal ID="literalError" runat="server"></asp:Literal></td>
                                </tr>
                             </table>
                        </td>
                        <td style="width: 1px; height: 351px" valign="top">
                        </td>
                        <td style="width: 160px; height: 351px" valign="top">
                            <uc4:rcRight ID="rcvRight1" runat="server" />
                        </td>
                    </tr>
                </table>
            </div>
        </form>

    </body>
</html>