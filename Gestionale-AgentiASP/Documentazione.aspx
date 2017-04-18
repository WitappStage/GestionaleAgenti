<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Documentazione.aspx.cs" Inherits="Gestionale_AgentiASP.Documentazione" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    </head>
<body>
    <form id="form1" runat="server">
    <div style="height: 91px; width: 776px; text-align: center">
    <asp:Panel runat="server" style="text-align: right">
        <asp:LinkButton ID="btnLogOut" runat="server" Font-Italic="False" Font-Names="Century Gothic" Font-Underline="False" ForeColor="#990000" PostBackUrl="~/LogIn.aspx">LOGOUT</asp:LinkButton>
        </asp:Panel>       
    
        <div style ="float:left; width:70px ; height: 70px;">
            <asp:HyperLink ID="hplkHome" runat="server" ImageHeight="60px" ImageUrl="~/Immagini/home-icon.png" NavigateUrl="~/Default.aspx"></asp:HyperLink>
        </div>
    </div>
        <div style="height: 311px; width: 777px; text-align: center">
            <br />

            <asp:Panel ID="pnlDocumenti" runat="server" BorderColor="Black" BorderStyle="Solid" Height="279px">
                <br />
                <asp:Button ID="btnBrochure" runat="server" OnClick="btnBrochure_Click" Text="Brochure" BackColor="White" BorderColor="Black" BorderStyle="None" Font-Bold="True" Font-Names="Century Gothic" Font-Size="Medium" ForeColor="#990000" />
                <br />                
                <br />
                <asp:Button ID="btnCatalogo" runat="server" OnClick="btnCatalogo_Click" Text="Catalogo" BackColor="White" BorderStyle="None" Font-Bold="True" Font-Names="Century Gothic" Font-Size="Medium" ForeColor="#990000" />
                <br />
                <br />
                <asp:Button ID="btnListinoPrezzi" runat="server" OnClick="btnListinoPrezzi_Click" Text="Listino Prezzi" BackColor="White" BorderColor="Black" BorderStyle="None" Font-Bold="True" Font-Names="Century Gothic" Font-Size="Medium" ForeColor="#990000" />
                <br />
                <br />
                <asp:Button ID="btnContrattoWitapp" runat="server" OnClick="btnContrattoWitapp_Click" Text="Contratto Witapp" BackColor="White" BorderColor="Black" BorderStyle="None" Font-Bold="True" Font-Names="Century Gothic" Font-Size="Medium" ForeColor="#990000" />
                <br />
                <br />
                <asp:Button ID="btnContrattoRW" runat="server" OnClick="btnContrattoRW_Click" Text="Contratto Rental Web" BackColor="White" BorderColor="Black" BorderStyle="None" Font-Bold="True" Font-Names="Century Gothic" Font-Size="Medium" ForeColor="#990000" />
                <br />
                <br />
                <asp:Button ID="btnCalcoloRataRW" runat="server" OnClick="btnCalcoloRataRW_Click" Text="Calcolo Rata Rental Web" BackColor="White" BorderColor="Black" BorderStyle="None" Font-Bold="True" Font-Names="Century Gothic" Font-Size="Medium" ForeColor="#990000" />
            </asp:Panel>
            
        </div>
    </form>
</body>
</html>
