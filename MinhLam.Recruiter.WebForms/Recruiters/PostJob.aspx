<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PostJob.aspx.cs" Inherits="MinhLam.Recruiter.WebForms.Recruiters.PostJob" %>

<%@ Register Src="~/Recruiters/rcTop.ascx" TagPrefix="uc1" TagName="rcTop" %>
<%@ Register Src="~/Recruiters/rcMenu.ascx" TagPrefix="uc1" TagName="rcMenu" %>
<%@ Register Src="~/Recruiters/rcBanner.ascx" TagPrefix="uc1" TagName="rcBanner" %>
<%@ Register Src="~/Recruiters/rcRight.ascx" TagPrefix="uc1" TagName="rcRight" %>
<%@ Register Src="~/Recruiters/rcBottom.ascx" TagPrefix="uc1" TagName="rcBottom" %>
<%@ Register Src="~/Recruiters/rcLeft.ascx" TagPrefix="uc1" TagName="rcLeft" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>::Đăng tin</title>
    <link href="Css/newstyle.css" rel="stylesheet" />
    <link href="Css/style.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>
<body topmargin="0" leftmargin="0" bottommargin="0" rightmargin="0" style="font-size: 12pt">
    <form id="form1" runat="server">
        <div title="Đăng tin">
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
                    <td style="width: 600px; height: 351px" valign="top">
                        <table style="width: 100%">
                            <tr>
                                <td style="height: 21px; width: 100%;" colspan="2">
                                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Recruiters/Icons/titlenote.gif"></asp:Image>
                                    <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Text="Đăng một tin" Width="394px"></asp:Label>
                                    <asp:Literal ID="literalID" runat="server" Visible="False"></asp:Literal></td>
                            </tr>
                            <tr>
                                <td colspan="2" style="height: 21px; width: 100%; text-align: left;">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr valign="top">
                                            <td style="width: 100%">
                                                <table border="0" cellpadding="5" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td class="text_normal" colspan="2" valign="top"
                                                            style="text-align: left; height: 20px;">Típ resume: Chúng tối đã cập nhật qui trình 
                                                            đặt mua. Một trong những tin quota của bạn đang rỗng nên bạn 
                                                            phải mua một gói tin mới. 
                                                        </td>
                                                    </tr>
                                                    <tr valign="top">
                                                        <td style="width: 100%; text-align: left;">
                                                            <table style="width: 100%">
                                                                <tr id="postAndUpdateDate" runat="server">
                                                                    <td style="width: 79px; text-align: left">Ngày đăng</td>
                                                                    <td style="width: 85px">
                                                                        <asp:Literal ID="literalPostDate" runat="server"></asp:Literal></td>
                                                                    <td style="width: 104px">Ngày cập nhật</td>
                                                                    <td nowrap="nowrap" style="width: 147px">
                                                                        <asp:Literal ID="literalUpdDate" runat="server"></asp:Literal>&nbsp;
                                                                        <asp:Literal ID="litDayLeft" runat="server"></asp:Literal>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 79px; text-align: left">Mã số</td>
                                                                    <td style="width: 85px">
                                                                        <asp:TextBox ID="txtNo" runat="server"></asp:TextBox></td>
                                                                    <td style="width: 104px">Ngày đóng</td>
                                                                    <td nowrap="noWrap" style="width: 147px">
                                                                        <asp:DropDownList ID="ddlCloseDate" runat="server" Width="147px">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 79px; text-align: left" valign="top">Tiêu đề
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                                            ControlToValidate="txtTitle" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td colspan="3" valign="top">
                                                                        <asp:TextBox ID="txtTitle" runat="server" Height="71px" MaxLength="100"
                                                                            TextMode="MultiLine"
                                                                            Width="443px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 79px; text-align: left" valign="top">Tóm tắt
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                                            ControlToValidate="txtSummary" ErrorMessage="*"></asp:RequiredFieldValidator></td>
                                                                    <td colspan="3">
                                                                        <asp:TextBox ID="txtSummary" runat="server" Height="71px" TextMode="MultiLine" Width="443px"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 79px; text-align: left">Loại tin</td>
                                                                    <td style="width: 85px">
                                                                        <asp:DropDownList ID="ddlCategory" runat="server" Width="154px">
                                                                        </asp:DropDownList></td>
                                                                    <td style="width: 104px">Nghành công nghiệp</td>
                                                                    <td style="width: 147px">
                                                                        <asp:DropDownList ID="ddlIndustry" runat="server" Width="154px">
                                                                        </asp:DropDownList></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 79px; text-align: left">Chứng chỉ</td>
                                                                    <td style="width: 85px">
                                                                        <asp:DropDownList ID="ddlCertificate" runat="server" Width="154px">
                                                                        </asp:DropDownList></td>
                                                                    <td style="width: 104px">Mức kinh nghiệm</td>
                                                                    <td style="width: 147px">
                                                                        <asp:DropDownList ID="ddlLevel" runat="server" Width="154px">
                                                                        </asp:DropDownList></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 79px; text-align: left">Năm kinh nghiệp</td>
                                                                    <td nowrap="noWrap">Ít nhất
                                                                        <asp:TextBox ID="txtYearExperience" runat="server" MaxLength="50" Width="21px"></asp:TextBox>
                                                                        &nbsp;năm
                                                                        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtYearExperience"
                                                                            ErrorMessage="1-20" MaximumValue="20" MinimumValue="1" Type="Integer"></asp:RangeValidator></td>
                                                                    <td style="width: 104px">Loại công việc</td>
                                                                    <td style="width: 147px">
                                                                        <asp:DropDownList ID="ddlWorkingType" runat="server" Width="154px">
                                                                        </asp:DropDownList></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 85px; height: 16px"></td>
                                                                    <td style="width: 96px; height: 16px"></td>
                                                                    <td style="width: 104px; height: 16px"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 79px; text-align: left; height: 16px;">Email liên hệ</td>
                                                                    <td style="width: 85px; height: 16px;">
                                                                        <asp:TextBox ID="txtContactEmail" runat="server" MaxLength="50"></asp:TextBox></td>
                                                                    <td style="width: 104px; height: 16px">Điện thoại liên hệ</td>
                                                                    <td style="width: 147px; height: 16px">
                                                                        <asp:TextBox ID="txtContactTel" runat="server" MaxLength="10"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 79px; text-align: left">Người liên hệ</td>
                                                                    <td style="width: 85px">
                                                                        <asp:TextBox ID="txtContactPerson" runat="server" MaxLength="50"></asp:TextBox></td>
                                                                    <td style="width: 104px"></td>
                                                                    <td style="width: 147px"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 79px; text-align: left"></td>
                                                                    <td style="width: 85px"></td>
                                                                    <td style="width: 104px"></td>
                                                                    <td style="width: 147px"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 79px; text-align: left; height: 16px;">Số yêu cầu</td>
                                                                    <td style="width: 85px; height: 16px;">
                                                                        <asp:TextBox ID="txtNumber" runat="server" MaxLength="3">1</asp:TextBox>
                                                                        <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtNumber"
                                                                            ErrorMessage="*" MaximumValue="20" MinimumValue="1" Type="Integer"></asp:RangeValidator></td>
                                                                    <td style="width: 104px; height: 16px">Độ tuổi</td>
                                                                    <td style="width: 147px; height: 16px;">
                                                                        <asp:TextBox ID="txtAge" runat="server" MaxLength="50"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 79px; text-align: left">Kiểu tuyển dụng</td>
                                                                    <td style="width: 85px">
                                                                        <asp:TextBox ID="txtRecruitment" runat="server" MaxLength="50"></asp:TextBox></td>
                                                                    <td colspan="2">
                                                                        <asp:CheckBox ID="chkShowLogo" runat="server"
                                                                            Text="Hiển thị logo kèm theo tin" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 79px; text-align: left; height: 16px;"></td>
                                                                    <td style="width: 85px; height: 16px;"></td>
                                                                    <td style="width: 104px; height: 16px"></td>
                                                                    <td style="width: 147px; height: 16px"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 79px; text-align: left">Lương từ</td>
                                                                    <td style="width: 85px">
                                                                        <asp:TextBox ID="txtSalaryFrom" runat="server" MaxLength="10"></asp:TextBox></td>
                                                                    <td style="width: 104px">
                                                                        <asp:DropDownList ID="ddlCurrency" runat="server" Width="57px">
                                                                            <asp:ListItem>USD</asp:ListItem>
                                                                            <asp:ListItem>VND</asp:ListItem>
                                                                        </asp:DropDownList></td>
                                                                    <td style="width: 147px">
                                                                        <asp:CheckBox ID="chkNegotive" runat="server" Text="Thỏa thuận lương" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 79px; text-align: left">Đến</td>
                                                                    <td style="width: 85px" nowrap="noWrap">
                                                                        <asp:TextBox ID="txtSalaryTo" runat="server" MaxLength="10"></asp:TextBox></td>
                                                                    <td colspan="2">
                                                                        <asp:CheckBox
                                                                            ID="chkShowSalary" runat="server"
                                                                            Text="Không hiển thị lương trong mô tả" Checked="True" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 79px; text-align: left"></td>
                                                                    <td style="width: 85px"></td>
                                                                    <td style="width: 104px"></td>
                                                                    <td style="width: 147px"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 79px; text-align: left">Tỉnh</td>
                                                                    <td style="width: 85px">
                                                                        <asp:DropDownList ID="ddlProvince" runat="server" Width="154px">
                                                                        </asp:DropDownList></td>
                                                                    <td style="width: 104px">Vị trí làm việc</td>
                                                                    <td style="width: 147px">
                                                                        <asp:TextBox ID="txtLocation" runat="server"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 79px; text-align: left"></td>
                                                                    <td style="width: 85px"></td>
                                                                    <td style="width: 104px"></td>
                                                                    <td style="width: 147px"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 79px; text-align: left">Những kỷ năng</td>
                                                                    <td colspan="3">
                                                                        <asp:TextBox ID="txtSkills" runat="server" Height="71px"
                                                                            TextMode="MultiLine" Width="443px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 79px; text-align: left">Tên quảng cáo</td>
                                                                    <td colspan="3">
                                                                        <asp:TextBox ID="txtAdv" runat="server" Height="71px"
                                                                            MaxLength="1000" TextMode="MultiLine"
                                                                            Width="443px"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 79px; text-align: left"></td>
                                                                    <td style="width: 85px"></td>
                                                                    <td style="width: 104px"></td>
                                                                    <td style="width: 147px"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 79px; text-align: left">Thực hiện Online</td>
                                                                    <td style="width: 85px">
                                                                        <asp:CheckBox ID="chkApplyOnline" runat="server" Width="105px" />&nbsp;
                                                                    </td>
                                                                    <td style="width: 104px">Chỉ Apply URL</td>
                                                                    <td style="width: 147px">
                                                                        <asp:TextBox ID="txtURL" runat="server"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 79px; text-align: left"></td>
                                                                    <td style="width: 85px"></td>
                                                                    <td style="width: 104px"></td>
                                                                    <td style="width: 147px"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 79px; text-align: left">Thư mục</td>
                                                                    <td style="width: 85px">
                                                                        <asp:DropDownList ID="ddlFolder" runat="server" Width="154px">
                                                                        </asp:DropDownList></td>
                                                                    <td style="width: 104px">Template</td>
                                                                    <td style="width: 147px">
                                                                        <asp:DropDownList ID="ddlTemplate" runat="server" Width="154px">
                                                                        </asp:DropDownList></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 79px; text-align: left"></td>
                                                                    <td style="width: 85px"></td>
                                                                    <td style="width: 104px"></td>
                                                                    <td style="width: 147px"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 79px; text-align: left"></td>
                                                                    <td colspan="2" nowrap="noWrap">
                                                                        <asp:Button ID="btnSave" runat="server" Text="Lưu" Width="52px" OnClick="btnSave_Click" />
                                                                        <asp:Button ID="btnActivate" runat="server" Text="Kích hoạt" Width="92px" />
                                                                        <asp:Button ID="btnPreView" runat="server" Text="Xem trước" Width="92px" /></td>
                                                                    <td style="width: 147px"></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr valign="top">
                                                        <td style="width: 100%; text-align: center;">
                                                            <asp:Literal ID="literalError" runat="server"></asp:Literal></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width: 1px; height: 351px" valign="top"></td>

                            </tr>
                        </table>
                    </td>
                    <td style="width: 160px; height: 351px" valign="top" align="right">
                        <uc1:rcRight ID="rcvRight1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="4">
                        <uc1:rcBottom id="RcvBottom1" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
