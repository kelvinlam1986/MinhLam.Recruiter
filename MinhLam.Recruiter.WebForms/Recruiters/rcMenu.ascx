<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="rcMenu.ascx.cs" Inherits="MinhLam.Recruiter.WebForms.Recruiters.rcMenu" %>
<table border="0" width="100%" cellpadding="0" cellspacing="0">
    <tr bgcolor="#000099">
        <td width="154" valign="middle" height="20">
            <div class="OLblEms">
                <img src="Images/recruiter.gif" align="absmiddle"></div>
        </td>
        <td width="64" align="center" bgcolor="#099999" height="13" nowrap runat="server" id="TdHome">
            <div class="OLblEms"><a href="/index.aspx" class="OLblEms">
                <font color="white">Trang chủ</font></a></div>
        </td>
        <td width="100" align="center" height="13" nowrap runat="server" id="TdMyAccount">
            <div class="OLblEms"><a href="/recruiters/myaccount.aspx" class="OLblEms">
                <font color="white">Quản lý Account</font></a></div>
        </td>
        <td width="90" align="center" height="13" nowrap>
            <div class="OLblEms"><a href="/recruiters/jobmanager.aspx" class="OLblEms">
                <font color="white">Quản lý Job</font></a></div>
        </td>
        <td width="100" align="center" height="13" nowrap>
            <div class="OLblEms"><a href="/recruiters/resumemanager.aspx" class="OLblEms">
                <font color="white">Quản lý Resume</font></a></div>
        </td>
        <td width="100" align="center" height="13" nowrap>
            <div class="OLblEms"><a href="/recruiters/search.aspx" class="OLblEms">
                <font color="white">Tìm kiếm Resume</font></a></div>
        </td>
        <td width="80" height="13" align="center">
            <div class="OLblEms"><a href="/recruiters/savedresumes.aspx" class="OLblEms">
                <font color="white">Lưu tìm kiếm</font></a></div>
        </td>
        <td width="80" height="13" align="center">
            <div class="OLblEms"><a href="/recruiters/resumealerts.aspx" class="OLblEms">
                <font color="white">Thông báo</font></a></div>
        </td>
    </tr>

    <tr>
        <td align="center" colspan="8" nowrap="nowrap" valign="middle">
            <asp:Panel ID="panelMenu" runat="server" Height="20px" Width="100%" BackColor="#099999" Font-Bold="True" ForeColor="White"></asp:Panel>
        </td>
    </tr>
</table>
