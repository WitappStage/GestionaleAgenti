<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Agenda.aspx.cs" Inherits="Gestionale_AgentiASP.Agenda" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style3 {
            width: 171px;
        }
        #form1 {
            height: 1891px;
        }
        .auto-style4 {
            width: 171px;
            height: 23px;
        }
        .auto-style5 {
            height: 23px;
        }
        .auto-style6 {
            width: 171px;
            height: 26px;
        }
        .auto-style7 {
            height: 26px;
        }
        .auto-style8 {
            width: 171px;
            height: 54px;
        }
        .auto-style9 {
            height: 54px;
        }
        .auto-style10 {
            width: 171px;
            height: 30px;
        }
        .auto-style11 {
            height: 30px;
        }
        .auto-style12 {
            width: 171px;
            height: 25px;
        }
        .auto-style13 {
            height: 25px;
        }
    </style>
</head>
<body style="height: ">
    <form id="form1" runat="server" style="height: 0px; color: #000000;">
    <div style="text-align: center; width: 800px;">

        <asp:Panel runat="server" style="text-align: right">
        <asp:LinkButton ID="btnLogOut" runat="server" Font-Italic="False" Font-Names="Century Gothic" Font-Underline="False" ForeColor="#990000" PostBackUrl="~/LogIn.aspx">LOGOUT</asp:LinkButton>
        </asp:Panel>
    
        <div style ="float:left; width:70px ; height: 70px;">
            <asp:HyperLink ID="hplkHome" runat="server" ImageHeight="60px" ImageUrl="~/Immagini/home-icon.png" NavigateUrl="~/Default.aspx"></asp:HyperLink>
        </div>
    
        <asp:Label ID="lblTitolo" runat="server" Text="LA MIA AGENDA" Font-Bold="True" Font-Size="XX-Large" Font-Names="Century Gothic"></asp:Label>
    
    </div>
        <asp:Panel ID="pnlInserisciAppuntamento" runat="server" Width="604px" BorderColor="#990000" BorderStyle="Solid" style="margin-left: 134px">
            <div>
                <asp:Label ID="lblIntestazione" runat="server" Text="Inserisci Appuntamento" Font-Bold="True" Font-Size="X-Large" Font-Names="Century Gothic"></asp:Label>
                <asp:HiddenField ID="hddAgenteModifica" runat="server" Visible="False" />
            </div>
            <table style="width:100%; height: 104px;">
                 <tr>
                    <td class="auto-style3"><asp:Label ID="lblId" runat="server" Text="Id" Font-Names="Century Gothic"></asp:Label></td>
                    <td style="font-family: 'Century Gothic'">
                        <asp:TextBox ID="txtId" runat="server" Enabled="false" Width="415px" Font-Names="Century Gothic"></asp:TextBox>
                     </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="lblData" runat="server" Text="Data" Font-Names="Century Gothic"></asp:Label></td>
                    <td style="font-family: 'Century Gothic'">
                        <asp:TextBox ID="txtData" runat="server" Width="415px" Font-Names="Century Gothic" TextMode="Date"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                     <td class="auto-style3">
                         <asp:Label ID="lblOrario" runat="server" Font-Names="Century Gothic" Text="Orario"></asp:Label>
                     </td>
                     <td style="font-family: 'Century Gothic'">
                         <asp:TextBox ID="txtOrario" runat="server" Font-Names="Century Gothic" TextMode="Time" Width="415px"></asp:TextBox>
                     </td>
                 </tr>
                <tr>
                    <td class="auto-style3"><asp:Label ID="lblCliente" runat="server" Text="Cliente" Font-Names="Century Gothic"></asp:Label></td>
                    <td style="font-family: 'Century Gothic'">
                        <asp:DropDownList ID="ddlCliente" runat="server" OnSelectedIndexChanged="ddlCliente_SelectedIndexChanged" AutoPostBack="true" Font-Names="Century Gothic">
                        </asp:DropDownList>
                        &nbsp;<asp:Button ID="btnCliente" runat="server" Text="Nuovo" OnClick="btnCliente_Click" Width="83px" Font-Names="Century Gothic" />
                        <asp:Button ID="btnModifica" runat="server" Text="Modifica" Width="83px" Visible="false" OnClick="btnModifica_Click" Font-Names="Century Gothic"/>
                        <asp:Button ID="btnEliminaCliente" runat="server" Font-Names="Century Gothic" OnClick="btnEliminaCliente_Click" OnClientClick="return confirm ('Sei sicuro di voler eliminare questo cliente?');"  Text="Elimina" Visible="false" Width="83px" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style8"><asp:Label ID="lblDescrizione" runat="server" Text="Descrizione" Font-Names="Century Gothic"></asp:Label></td>
                    <td class="auto-style9" style="font-family: 'Century Gothic'">
                        <asp:TextBox ID="txtDescrizione" runat="server" Height="40px" Width="415px" TextMode="MultiLine" Font-Names="Century Gothic"></asp:TextBox>
                    </td>
                </tr>
            </table>            
            <asp:Label ID="lblErrore1" runat="server" ForeColor="Red" Text="Label" Visible="False" Font-Names="Century Gothic"></asp:Label>
            <br />
            <asp:Button ID="btnInserisci" runat="server" Text="INSERISCI" Width="604px" Height="26px" OnClick="btnInserisci_Click" Font-Names="Century Gothic" Font-Bold="True" />
            <asp:Button ID="btnUpdate" runat="server" Font-Bold="True" Font-Names="Century Gothic" Height="26px" OnClick="btnUpdate_Click" Text="SALVA MODIFICHE" Width="604px" />
        </asp:Panel>

        <asp:HiddenField ID="hddAg" runat="server"/>
         
        <br />

        <asp:Panel ID="pnlInserisciCliente" runat="server" Width="433px" BorderColor="#990000" BorderStyle="Solid" style="margin-left: 208px">
            <div style="width: 433px">
                <asp:Label ID="Label1" runat="server" Text="Inserisci Cliente" Font-Bold="True" Font-Size="X-Large" Font-Names="Century Gothic"></asp:Label>
                <asp:HiddenField ID="hddId" runat="server" />
            </div>
            <table style="width:99%; height: 396px;">
                 <tr>
                    <td class="auto-style3"><asp:Label ID="lblRagioneSociale" runat="server" Text="Ragione Sociale" Font-Names="Century Gothic"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtRagioneSociale" runat="server" Width="235px" Font-Names="Century Gothic"></asp:TextBox>
                     </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="lblSedeLegale" runat="server" Text="Sede Legale" Font-Names="Century Gothic"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtSedeLegale" runat="server" Width="235px" Font-Names="Century Gothic"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3"><asp:Label ID="lblPartitaIva" runat="server" Text="Partita IVA" Font-Names="Century Gothic"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtPartitaIva" runat="server" Width="235px" Font-Names="Century Gothic"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4"><asp:Label ID="LblCodiceFiscale" runat="server" Text="Codice Fiscale" Font-Names="Century Gothic"></asp:Label></td>
                    <td class="auto-style5">
                        <asp:TextBox ID="txtCodiceFiscale" runat="server" Width="235px" Font-Names="Century Gothic"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6"><asp:Label ID="lblEmail" runat="server" Text="E-mail" Font-Names="Century Gothic"></asp:Label></td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" Width="235px" Font-Names="Century Gothic"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style10"><asp:Label ID="lblPec" runat="server" Text="PEC" Font-Names="Century Gothic"></asp:Label></td>
                    <td class="auto-style11">
                        <asp:TextBox ID="txtPec" runat="server" Width="235px" Font-Names="Century Gothic" TextMode="Email"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3"><asp:Label ID="lblTelefono" runat="server" Text="Telefono" Font-Names="Century Gothic"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtTelefono" runat="server" Width="235px" Font-Names="Century Gothic" TextMode="Phone"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3"></td>
                    <td>                        
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3"></td>
                    <td>                        
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="lblReferente" runat="server" Text="Referente dell'azienda" Font-Names="Century Gothic"></asp:Label>
                    </td>
                    <td>                        
                        <asp:TextBox ID="txtReferente" runat="server" Width="235px" Font-Names="Century Gothic"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3"><asp:Label ID="lblRefTelefono" runat="server" Text="Telefono del Referente" Font-Names="Century Gothic"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtRefTelefono" runat="server" Width="235px" Font-Names="Century Gothic" TextMode="Phone"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3"><asp:Label ID="lblRefEmail" runat="server" Text="E-mail del Referente" Font-Names="Century Gothic"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtRefEmail" runat="server" Width="235px" Font-Names="Century Gothic" TextMode="Email"></asp:TextBox>
                    </td>
                </tr>
            </table>            
            <asp:Label ID="lblErrore2" runat="server" Text="Label" Visible="False" ForeColor="Red" Font-Names="Century Gothic"></asp:Label>
            <br />
            <asp:Button ID="btnInserisci2" runat="server" Text="Inserisci" Width="183px" Height="24px" style="margin-top: 0px" OnClick="btnInserisci2_Click" Font-Names="Century Gothic" />
            <asp:Button ID="btnSalvaModifiche" runat="server" Text="Salva Modifiche" Width="183px" visible="false" Height="24px" OnClick="btnSalvaModifiche_Click" OnClientClick="return confirm ('Sei sicuro di voler apportare queste modifiche?');" Font-Names="Century Gothic"/>
            <asp:Button ID="btnAnnulla" runat="server" Height="24px" style="margin-left: 63px" Text="Annulla" Width="183px" OnClick="btnAnnulla_Click" Font-Names="Century Gothic"/>
        </asp:Panel>

               
        <br />
        <br />
    
        <asp:Label ID="lblTitolo0" runat="server" Text="Seleziona la Data" Font-Bold="False" Font-Size="X-Large" Font-Names="Century Gothic"></asp:Label>
    
        <br />

        <asp:Calendar ID="Calendario" runat="server" BackColor="White" BorderColor="Black" BorderWidth="3px" Font-Names="Century Gothic" Font-Size="X-Large" ForeColor="Black" Height="358px" NextPrevFormat="FullMonth" Width="786px" BorderStyle="Outset" OnSelectionChanged="Calendario_SelectionChanged" >
            <DayHeaderStyle Font-Bold="True" Font-Size="Medium" ForeColor="#990000" Font-Names="Century Gothic" />
            <DayStyle ForeColor="Black" />
            <NextPrevStyle Font-Bold="True" Font-Size="Medium" ForeColor="#333333" VerticalAlign="Bottom" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <SelectedDayStyle BackColor="#990000" ForeColor="White" />
            <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="X-Large" ForeColor="#990000" />
            <TodayDayStyle BackColor="#CCCCCC" />
        </asp:Calendar>

            <asp:Button ID="btnVediTutti" runat="server" Text="Vedi tutti gli Appuntamenti" Width="786px" style="margin-top: 1px" OnClick="btnVediTutti_Click" Font-Names="Century Gothic" Font-Bold="True" Font-Size="Large" />

        <br />

        <br />
        <br />

        <asp:GridView ID="grdListaAppuntamenti" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="Black" BorderWidth="1px" CellPadding="4" Font-Names="Century Gothic" ItemType="LibreriaGestionaleAgente.Appuntamento" OnRowCommand="grdListaAppuntamenti_RowCommand" ForeColor="Black">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" />
                <asp:BoundField DataField="Data" HeaderText="Data e Ora" />
                <asp:TemplateField HeaderText="Cliente">
                    <ItemTemplate>
                        <asp:Button ID="btnDettagli" runat="server" Text="<%#BindItem.NominativoCliente%>" Font-Names="century Gothic" CommandName="VediDettagli" CommandArgument="<%# BindItem.Id %>"/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Descrizione" HeaderText="Descrizione" />
                <asp:BoundField DataField="NominativoAgente" HeaderText="Agente"/>
                <asp:TemplateField>                
                <ItemTemplate>                        
                        <asp:Button ID="btnElimina" runat="server" Text="ELIMINA" Font-Names="Century Gothic" CommandArgument="<%# BindItem.Id %>" CommandName="Elimina" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>                        
                        <asp:Button ID="btnModifica" runat="server" Text="MODIFICA" Font-Names="Century Gothic" CommandArgument="<%# BindItem.Id %>" CommandName="Modifica" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#FFFFCC" ForeColor="Black" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="Black" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            <SortedAscendingCellStyle BackColor="#FEFCEB" />
            <SortedAscendingHeaderStyle BackColor="#AF0101" />
            <SortedDescendingCellStyle BackColor="#F6F0C0" />
            <SortedDescendingHeaderStyle BackColor="#7E0000" />
        </asp:GridView>

        <br />
        <br />

        <asp:Panel ID="pnlDettagliCliente" runat="server" Width="433px" BorderColor="#990000" BorderStyle="Solid" Visible="false" style="margin-left: 119px">
            <div style="width: 433px">
                <asp:Label ID="lblDettagliCliente" runat="server" Text="Dettagli Cliente" Font-Bold="True" Font-Size="X-Large" Font-Names="Century Gothic"></asp:Label>
            </div>
            <table style="width:99%; height: 396px;">
                 <tr>
                    <td class="auto-style3">
                        <asp:Label ID="lblDettagliId" runat="server" Font-Names="Century Gothic" Text="Id"></asp:Label>
                     </td>
                    <td>
                        <asp:TextBox ID="txtDettagliId" runat="server" Width="235px" Enabled="False" Font-Names="Century Gothic"></asp:TextBox>
                     </td>
                </tr>
                 <tr>
                     <td class="auto-style12">
                         <asp:Label ID="lblDettagliRagioneSociale" runat="server" Font-Names="Century Gothic" Text="Ragione Sociale"></asp:Label>
                     </td>
                     <td class="auto-style13">
                         <asp:TextBox ID="txtDettagliRagioneSociale" runat="server" Width="235px" Enabled="False" Font-Names="Century Gothic"></asp:TextBox>
                     </td>
                 </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="lblDettagliSedeLegale" runat="server" Text="Sede Legale" Font-Names="Century Gothic"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtDettagliSedeLegale" runat="server" Width="235px" Enabled="False" Font-Names="Century Gothic"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3"><asp:Label ID="lblDettagliPartitaIva" runat="server" Text="Partita IVA" Font-Names="Century Gothic"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtDettagliPartitaIva" runat="server" Width="235px" Enabled="False" Font-Names="Century Gothic"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4"><asp:Label ID="lblDettagliCodiceFiscale" runat="server" Text="Codice Fiscale" Font-Names="Century Gothic"></asp:Label></td>
                    <td class="auto-style5">
                        <asp:TextBox ID="txtDettagliCodiceFiscale" runat="server" Width="235px" Enabled="False" Font-Names="Century Gothic"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6"><asp:Label ID="lblDettagliEmail" runat="server" Text="E-mail" Font-Names="Century Gothic"></asp:Label></td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txtDettagliEmail" runat="server" TextMode="Email" Width="235px" Enabled="False" Font-Names="Century Gothic"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style10"><asp:Label ID="lblDettagliPec" runat="server" Text="PEC" Font-Names="Century Gothic"></asp:Label></td>
                    <td class="auto-style11">
                        <asp:TextBox ID="txtDettagliPec" runat="server" Width="235px" Enabled="False" Font-Names="Century Gothic"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3"><asp:Label ID="lblDettagliTelefono" runat="server" Text="Telefono" Font-Names="Century Gothic"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtDettagliTelefono" runat="server" Width="235px" Enabled="False" Font-Names="Century Gothic"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3"></td>
                    <td>                        
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3"></td>
                    <td>                        
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="lblDettagliReferente" runat="server" Text="Referente dell'azienda" Font-Names="Century Gothic"></asp:Label>
                    </td>
                    <td>                        
                        <asp:TextBox ID="txtDettagliReferente" runat="server" Width="235px" Enabled="False" Font-Names="Century Gothic"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3"><asp:Label ID="lblDettagliRefTelefono" runat="server" Text="Telefono del Referente" Font-Names="Century Gothic"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtDettagliRefTelefono" runat="server" Width="235px" Enabled="False" Font-Names="Century Gothic"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3"><asp:Label ID="lblDettagliRefEmail" runat="server" Text="E-mail del Referente" Font-Names="Century Gothic"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtDettagliRefEmail" runat="server" Width="235px" Enabled="False" Font-Names="Century Gothic"></asp:TextBox>
                    </td>
                </tr>
            </table>            
            <asp:Label ID="lblErrore3" runat="server" Font-Names="Century Gothic" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
            <br />
            <asp:Button ID="btnChiudiDettagli" runat="server" Font-Names="Century Gothic" Height="37px" OnClick="btnChiudiDettagli_Click" Text="CHIUDI" Width="434px" />
            <br />
        </asp:Panel>

        
    </form>
</body>

</html>
