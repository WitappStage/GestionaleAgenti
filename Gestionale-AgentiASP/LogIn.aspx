<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="Gestionale_AgentiASP.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style2 {
            width: 148px;
        }
        .auto-style3 {
            width: 86px;
        }
    </style>
</head>
<body style="height: 234px; width: 789px;">
    <form id="form1" runat="server">
    <div style="height: 62px; width: 776px; text-align: center">
        <asp:Label ID="Label1" runat="server" Font-Names="Century Gothic" Text="MY WITAPP" Font-Size="XX-Large" Font-Bold="False" ForeColor="Black"></asp:Label>
    
    </div>
        <div style="height: 153px; width: 777px; text-align: center">
            <br />

            <asp:Panel ID="pnlLogin" runat="server" Height="91px" BorderColor="Black" BorderStyle="Solid" style="margin-left: 266px" Width="228px">
            <table style="width:101%; height: 90px;">
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="lblUsername" runat="server" Text="Username" Font-Names="Century Gothic"></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtUsername" runat="server" Font-Names="Century Gothic"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="lblPassword" runat="server" Text="Password" Font-Names="Century Gothic"></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtPassword" runat="server" Font-Names="Century Gothic" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Button ID="btnAccedi" runat="server" Text="ACCEDI" OnClick="btnAccedi_Click" Font-Names="Century Gothic" />
                    </td>
                    <td class="auto-style2">
                        <asp:Label ID="lblErrore" runat="server" Font-Names="Century Gothic" ForeColor="Red" Text="Label"></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>

        </div>
    </form>
</body>
</html>
