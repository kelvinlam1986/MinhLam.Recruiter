<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="rcRight.ascx.cs" Inherits="MinhLam.Recruiter.WebForms.Recruiters.rcRight" %>
<table style="width: 160px" border=0 cellpadding =0 cellspacing=0>
    <tr>
        <td>
            <asp:AdRotator ID="AdRotator1" runat="server" AdvertisementFile="~/advert.xml" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:AdRotator ID="AdRotator2" runat="server" AdvertisementFile="~/advert.xml" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:AdRotator ID="AdRotator3" runat="server" AdvertisementFile="~/advert.xml" />
        </td>
    </tr>
</table>