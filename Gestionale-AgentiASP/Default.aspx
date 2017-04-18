<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Gestionale_AgentiASP.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    </head>
<body>
    <form id="form1" runat="server">
    <div style="height: 62px; width: 776px; text-align: center">
    <asp:Panel runat="server" style="text-align: right">
        <asp:LinkButton ID="btnLogOut" runat="server" Font-Italic="False" Font-Names="Century Gothic" Font-Underline="False" ForeColor="#990000" PostBackUrl="~/LogIn.aspx">LOGOUT</asp:LinkButton>
        </asp:Panel>
        <asp:Label ID="Label1" runat="server" Font-Names="Century Gothic" Text="MY WITAPP" Font-Size="XX-Large" Font-Bold="False" ForeColor="Black"></asp:Label>
    
    </div>
        <div style="height: 309px; width: 777px; text-align: center">
            <br />

            <asp:Panel ID="pnlAreeInteresse" runat="server" BorderColor="Black" BorderStyle="Solid" Height="264px">
                <br />
                <asp:LinkButton ID="LinkButton1" runat="server" Font-Names="Century Gothic" Font-Underline="False" PostBackUrl="~/Offerte.aspx" ForeColor="#990000">Offerte Presentate Ai Clienti</asp:LinkButton>
                <br />
                <br />
                <asp:LinkButton ID="LinkButton2" runat="server" Font-Names="Century Gothic" Font-Underline="False" ForeColor="#990000" PostBackUrl="~/Contratti.aspx">Contratti Conclusi</asp:LinkButton>
                <br />
                <br />
                <asp:LinkButton ID="LinkButton3" runat="server" Font-Names="Century Gothic" Font-Underline="False" ForeColor="#990000" PostBackUrl="~/Agenda.aspx">La Mia Agenda</asp:LinkButton>
                <br />
                <br />
                <asp:LinkButton ID="LinkButton4" runat="server" Font-Names="Century Gothic" Font-Underline="False" ForeColor="#990000" PostBackUrl="~/Fatture.aspx">La mia Situazione</asp:LinkButton>
                <br />
                <br />
                <asp:LinkButton ID="LinkButton5" runat="server" Font-Names="Century Gothic" Font-Underline="False" ForeColor="#990000" PostBackUrl="~/Richieste.aspx">Richiedi un&#39;offerta</asp:LinkButton>
                <br />
                <br />
                <asp:LinkButton ID="LinkButton6" runat="server" Font-Names="Century Gothic" Font-Underline="False" ForeColor="#990000" PostBackUrl="~/Documentazione.aspx">Documentazione</asp:LinkButton>
            </asp:Panel>
            
        </div>
    </form>
</body>
</html>
