<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="rcTop.ascx.cs" Inherits="MinhLam.Recruiter.WebForms.Recruiters.rcTop" %>
<table cellSpacing=0 cellPadding=0 width="100%" border=0 align="center">             
      <tr valign="middle" bgcolor="#000099" > 
        <td width="50%" height="25" align="left">
            <font color=white>
                &nbsp;
                <asp:Label ID="lblAccount" runat="server" Font-Bold="True" Width="353px"></asp:Label>
            </font>
        </td>
        <td width="50%"  colspan=2 align="right">
            <a href="/contact.aspx">
                <font color=white>Liên hệ</font>
            </a> | 
            <a href="/aboutus.aspx">
                <font color=white>Về chúng tôi</font>
            </a> | 
            <a href="/sitemap.aspx">
                <font color=white>SiteMap</font>
            </a>&nbsp;&nbsp;</td>                            
      </tr>             
</table>