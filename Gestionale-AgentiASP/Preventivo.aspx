<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Preventivo.aspx.cs" Inherits="Gestionale_AgentiASP.Preventivo" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #form1 {
            height: 200px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" style="height: 0PX">
        <div style="height: 0px; width: 892px">
            <asp:Panel ID="Panel9" runat="server" BackColor="White" Height="25px" Style="text-align: right">
                <asp:Button ID="btnReset" runat="server" Text="RESET" OnClick="btnReset_Click" />
            </asp:Panel>
            <asp:Panel ID="pnlScelta" runat="server" BorderStyle="Solid">
                <asp:Panel ID="Panel8" runat="server" BackColor="#990000" Height="44px" Style="text-align: center">
                    <asp:Label ID="Label29" runat="server" Font-Bold="True" Font-Names="Century Gothic" Font-Size="XX-Large" ForeColor="White" Style="text-align: center" Text="SCEGLI UN'OPZIONE"></asp:Label>
                    <br />
                </asp:Panel>
                <br />

                <asp:Button ID="btnSceltaApp" runat="server" Font-Bold="True" Font-Names="Century Gothic" Font-Size="X-Large" Height="51px" Style="margin-left: 288px" Text="SOLO APPLICAZIONE" Width="312px" OnClick="btnSceltaApp_Click" />
                <br />
                <br />
                <asp:Button ID="btnSceltaExtra" runat="server" Font-Bold="True" Font-Names="Century Gothic" Font-Size="X-Large" Height="51px" Style="margin-left: 288px" Text="SOLO SERVIZI EXTRA" Width="312px" OnClick="btnSceltaExtra_Click" />
                <br />
                <br />
                <asp:Button ID="btnSceltaEntrambi" runat="server" Font-Bold="True" Font-Names="Century Gothic" Font-Size="X-Large" Height="51px" Style="margin-left: 288px" Text="APP + SERVIZI EXTRA" Width="312px" OnClick="btnSceltaEntrambi_Click" />
                <br />
                <br />
            </asp:Panel>

            <br />

            <asp:Panel ID="pnlApp" runat="server" BorderStyle="Solid">

                <asp:Panel ID="Panel2" runat="server" BackColor="#990000" Height="44px" Style="text-align: center">
                    <asp:Label ID="Label28" runat="server" Font-Bold="True" Font-Names="Century Gothic" Font-Size="XX-Large" ForeColor="White" Style="text-align: center" Text="APPLICAZIONE MOBILE"></asp:Label>
                </asp:Panel>

                <br />
                <asp:CheckBox ID="cbBasic" runat="server" Font-Bold="True" Font-Names="Century Gothic" Font-Size="X-Large" Text="BASIC" Checked="true" Enabled="False" />
                <br />
                <br />
                <asp:CheckBox ID="cbPlus" runat="server" Font-Bold="True" Font-Names="Century Gothic" Font-Size="X-Large" Text="PLUS" OnCheckedChanged="cbPlus_CheckedChanged" AutoPostBack="true" />
                &nbsp;<asp:Label ID="Label25" runat="server" Font-Bold="True" Font-Names="Century Gothic" Font-Size="Large" Text="(spuntare la casella per selezionare tutte le funzionalità)"></asp:Label>
                <asp:CheckBoxList ID="cblPlus" runat="server" Font-Names="Century Gothic" Style="margin-left: 32px">
                    <asp:ListItem Value="700">SISTEMA DI PRENOTAZIONE AVANZATO</asp:ListItem>
                    <asp:ListItem Value="600">REALIZZAZIONE SITO WEB</asp:ListItem>
                    <asp:ListItem Value="250">FIDELITY CARD &amp; LOYALTY</asp:ListItem>
                    <asp:ListItem Value="200">AREA LOGIN UTENTI</asp:ListItem>
                    <asp:ListItem Value="230">PAGAMENTI IN APP</asp:ListItem>
                    <asp:ListItem Value="250">APP MULTILINGUA</asp:ListItem>
                    <asp:ListItem Value="2000">E-SHOP APP BROWSER</asp:ListItem>
                    <asp:ListItem Value="2000">INTEGRAZIONE GESTIONALE</asp:ListItem>
                </asp:CheckBoxList>
                <br />
                <br />
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Century Gothic" Font-Size="X-Large" Text="AD HOC"></asp:Label>
                &nbsp;<asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Names="Century Gothic" Font-Size="Large" Text="(spuntare la casella della categoria per selezionarne tutte le funzionalità)"></asp:Label>
                <br />
                <br />
                <asp:CheckBox ID="cbRistorazione" runat="server" Font-Bold="True" Font-Names="Century Gothic" Font-Size="Large" Text="RISTORANTI, PIZZERIE, FAST FOOD, TAKE AWAY, LOUNGEBAR, PUB" OnCheckedChanged="cbRistorazione_CheckedChanged" AutoPostBack="true" />
                <br />
                <asp:CheckBoxList ID="cblRistorazione" runat="server" Font-Names="Century Gothic" Style="margin-left: 32px">
                    <asp:ListItem>PRENOTAZIONE TAVOLO, SALA, ECC. IN APP</asp:ListItem>
                    <asp:ListItem>ORDINA IL TUO MENU DIRETTAMENTE DALL&#39;APP</asp:ListItem>
                    <asp:ListItem>PRESENTA IL MENU DEL GIORNO</asp:ListItem>
                    <asp:ListItem>CREA I TUOI COUPON INTERATTIVI</asp:ListItem>
                </asp:CheckBoxList>
                <asp:CheckBox ID="cbHotel" runat="server" Font-Bold="True" Font-Names="Century Gothic" Font-Size="Large" Text="HOTEL, B&amp;B, OSTELLI, CASA VACANZE" OnCheckedChanged="cbHotel_CheckedChanged" AutoPostBack="true" />
                <asp:CheckBoxList ID="cblHotel" runat="server" Font-Names="Century Gothic" Style="margin-left: 32px">
                    <asp:ListItem>CREA IL TUO SISTEMA DI BOOKING</asp:ListItem>
                    <asp:ListItem>GUIDA TURISTICA IN APP (DOVE MANGIARE, COSA VISITARE, ECC.)</asp:ListItem>
                    <asp:ListItem>PAGAMENTO CAMERA/SERVIZI IN APP</asp:ListItem>
                </asp:CheckBoxList>
                <asp:CheckBox ID="cbCampeggi" runat="server" Font-Bold="True" Font-Names="Century Gothic" Font-Size="Large" Text="STABILIMENTI BALNEARI, CAMPEGGI, VILLAGGI" OnCheckedChanged="cbCampeggi_CheckedChanged" AutoPostBack="true" />
                <asp:CheckBoxList ID="cblCampeggi" runat="server" Font-Names="Century Gothic" Style="margin-left: 32px">
                    <asp:ListItem>CREA IL TUO SISTEMA DI BOOKING</asp:ListItem>
                    <asp:ListItem>PRENOTAZIONE SERVIZI IN APP (CAMPO SPORTIVO, OMBRELLONE, SDRAIO, ECC.)</asp:ListItem>
                    <asp:ListItem>PAGAMENTO SERVIZI IN APP</asp:ListItem>
                </asp:CheckBoxList>
                <asp:CheckBox ID="cbImmobiliare" runat="server" Font-Bold="True" Font-Names="Century Gothic" Font-Size="Large" Text="AGENZIE IMMOBILIARI" OnCheckedChanged="cbImmobiliare_CheckedChanged" AutoPostBack="true" />
                <asp:CheckBoxList ID="cblImmobiliare" runat="server" Font-Names="Century Gothic" Style="margin-left: 32px">
                    <asp:ListItem>ALERT PER IMMOBILI DI INTERESSE - CREA LA TUA PREFERENZA</asp:ListItem>
                    <asp:ListItem>SCHEDA IMMOBILE INTEGRATA CON QR CODE IN APP</asp:ListItem>
                    <asp:ListItem>PRENOTAZIONE VISITA IMMOBILE CON SCELTA AGENTE</asp:ListItem>
                </asp:CheckBoxList>
                <asp:CheckBox ID="cbParrucchieri" runat="server" Font-Bold="True" Font-Names="Century Gothic" Font-Size="Large" Text="SALONI DI PARRUCCHIERIA" OnCheckedChanged="cbParrucchieri_CheckedChanged" AutoPostBack="true" />
                <asp:CheckBoxList ID="cblParrucchieri" runat="server" Font-Names="Century Gothic" Style="margin-left: 32px">
                    <asp:ListItem>CATALOGO DIGITALE PRODOTTI DI PARRUCCHIERIA</asp:ListItem>
                    <asp:ListItem>PRENOTAZIONE PRODOTTI DI PARRUCCHIERIA IN APP</asp:ListItem>
                    <asp:ListItem>PAGAMENTO PRODOTTI DI PARRUCCHIERIA IN APP</asp:ListItem>
                    <asp:ListItem>CREA I TUOI COUPON INTERATTIVI</asp:ListItem>
                    <asp:ListItem>SISTEMA DI BOOKING PERSONALIZZATO</asp:ListItem>
                </asp:CheckBoxList>
                <asp:CheckBox ID="cbBenessere" runat="server" Font-Bold="True" Font-Names="Century Gothic" Font-Size="Large" Text="CENTRI DI BENESSERE, WELLNESS, SPA" OnCheckedChanged="cbBenessere_CheckedChanged" AutoPostBack="true" />
                <asp:CheckBoxList ID="cblBenessere" runat="server" Font-Names="Century Gothic" Style="margin-left: 32px">
                    <asp:ListItem>CATALOGO DIGITALE PRODOTTI DI BENESSERE</asp:ListItem>
                    <asp:ListItem>PRENOTAZIONE PRODOTTI DI BENESSERE IN APP</asp:ListItem>
                    <asp:ListItem>PAGAMENTO PRODOTTI DI BENESSERE IN APP</asp:ListItem>
                    <asp:ListItem>CREA I TUOI COUPON INTERATTIVI</asp:ListItem>
                    <asp:ListItem>SISTEMA DI BOOKING PERSONALIZZATO</asp:ListItem>
                </asp:CheckBoxList>
                <asp:CheckBox ID="cbFitness" runat="server" Font-Bold="True" Font-Names="Century Gothic" Font-Size="Large" Text="PALESTRE, CENTRI FITNESS" OnCheckedChanged="cbFitness_CheckedChanged" AutoPostBack="true" />
                <asp:CheckBoxList ID="cblFitness" runat="server" Font-Names="Century Gothic" Style="margin-left: 32px">
                    <asp:ListItem>VIRTUAL PROGRAM PERSONALIZZATO</asp:ListItem>
                    <asp:ListItem>RINNOVA ABBONAMENTO</asp:ListItem>
                    <asp:ListItem>PAGAMENTI IN APP</asp:ListItem>
                    <asp:ListItem>PRENOTA IL TUO PERSONAL TRAINER</asp:ListItem>
                    <asp:ListItem>PARTECIPA AD UN ALLENAMENTO</asp:ListItem>
                </asp:CheckBoxList>
                <asp:CheckBox ID="cbConcessionari" runat="server" Font-Bold="True" Font-Names="Century Gothic" Font-Size="Large" Text="CONCESSIONARI AUTO E MOTO" OnCheckedChanged="cbConcessionari_CheckedChanged" AutoPostBack="true" />
                <asp:CheckBoxList ID="cblConcessionari" runat="server" Font-Names="Century Gothic" Style="margin-left: 32px">
                    <asp:ListItem>PRESENTA IN MODO INTERATTIVO IL TUO USATO (MARCA, MODELLO, ANNO, ECC.)</asp:ListItem>
                    <asp:ListItem>SISTEMA DI PRENOTAZIONE SERVIZI (TEST DRIVE, TAGLIANDO, SCADENZE, ECC.)</asp:ListItem>
                    <asp:ListItem>SISTEMA DI NOLEGGIO AUTO</asp:ListItem>
                </asp:CheckBoxList>
                <asp:CheckBox ID="cbCentriCommerciali" runat="server" Font-Bold="True" Font-Names="Century Gothic" Font-Size="Large" Text="CENTRI, PARCHI COMMERCIALI" OnCheckedChanged="cbCentriCommerciali_CheckedChanged" AutoPostBack="true" />
                <asp:CheckBoxList ID="cblCentriCommerciali" runat="server" Font-Names="Century Gothic" Style="margin-left: 32px">
                    <asp:ListItem>MAPPA INTERATTIVA DEL CENTRO</asp:ListItem>
                    <asp:ListItem>BANNER SPONSORIZZAZIONE DEI NEGOZI</asp:ListItem>
                    <asp:ListItem>CREA I TUOI COUPON INTERATTIVI</asp:ListItem>
                    <asp:ListItem>OFFERTE VOLANTINO IN APP</asp:ListItem>
                </asp:CheckBoxList>
                <asp:CheckBox ID="cbMedico" runat="server" Font-Bold="True" Font-Names="Century Gothic" Font-Size="Large" Text="STUDI MEDICI, LABORATORI" OnCheckedChanged="cbMedico_CheckedChanged" AutoPostBack="true" />
                <asp:CheckBoxList ID="cblMedico" runat="server" Font-Names="Century Gothic" Style="margin-left: 32px">
                    <asp:ListItem>CONTATORI DEI CLIENTI IN ATTESA</asp:ListItem>
                    <asp:ListItem>COMUNICA I RISULTATI DELLE VISITE IN APP</asp:ListItem>
                    <asp:ListItem>CREA IL TUO SISTEMA DI BOOKING (SCEGLI IL MEDICO, IL GIORNO, L&#39;ORA E IL SERVIZIO)</asp:ListItem>
                </asp:CheckBoxList>
                <asp:CheckBox ID="cbFarmacia" runat="server" Font-Bold="True" Font-Names="Century Gothic" Font-Size="Large" Text="FARMACIE E PARAFARMACIE" OnCheckedChanged="cbFarmacia_CheckedChanged" AutoPostBack="true" />
                <asp:CheckBoxList ID="cblFarmacia" runat="server" Font-Names="Century Gothic" Style="margin-left: 32px">
                    <asp:ListItem>CATALOGO DIGITALE PRODOTTI FARMACEUTICI</asp:ListItem>
                    <asp:ListItem>PRENOTAZIONE PRODOTTI FARMACEUTICI IN APP</asp:ListItem>
                    <asp:ListItem>PAGAMENTO PRODOTTI FARMACEUTICI IN APP</asp:ListItem>
                    <asp:ListItem>AREA SPECIALE PER CATEGORIE DI UTENZE (CELIACI, ALLERGIE, ECC.)</asp:ListItem>
                </asp:CheckBoxList>
                <br />
            </asp:Panel>


            <br />


            <asp:Panel ID="pnlExtra" runat="server" BorderStyle="Solid">
                <asp:Panel ID="Panel6" runat="server" BackColor="#990000" Height="44px" Style="text-align: center">
                    <asp:Label ID="Label15" runat="server" Font-Names="Century Gothic" Font-Size="XX-Large" ForeColor="White" Style="text-align: center" Text="SERVIZI EXTRA" Font-Bold="True"></asp:Label>
                </asp:Panel>
                <br />
                <asp:Label ID="Label16" runat="server" Font-Bold="True" Font-Size="X-Large" Text="SITO WEB" Font-Names="Century Gothic"></asp:Label>
                <br />

                <asp:RadioButtonList ID="rblSitoWeb" runat="server" Font-Names="Century Gothic" Style="margin-left: 17px">
                    <asp:ListItem>STATICO</asp:ListItem>
                    <asp:ListItem>DINAMICO</asp:ListItem>
                </asp:RadioButtonList>
                <br />
                <asp:Label ID="Label17" runat="server" Font-Bold="True" Font-Names="Century Gothic" Font-Size="X-Large" Text="SISTEMA DI E-COMMERCE"></asp:Label>
                <br />
                <asp:RadioButtonList ID="rblEcommerce" runat="server" Font-Names="Century Gothic" Style="margin-left: 17px">
                    <asp:ListItem>BASIC</asp:ListItem>
                    <asp:ListItem>PLUS</asp:ListItem>
                    <asp:ListItem>AD HOC</asp:ListItem>
                </asp:RadioButtonList>
                <br />
                &nbsp;<asp:CheckBox ID="cbGraphicDesign" runat="server" Font-Bold="True" Font-Names="Century Gothic" Font-Size="X-Large" Text="GRAPHIC DESIGN" OnCheckedChanged="cbGraphicDesign_CheckedChanged" AutoPostBack="true" />
                &nbsp;<asp:Label ID="Label26" runat="server" Font-Bold="False" Font-Names="Century Gothic" Font-Size="Large" Text="(spuntare la casella per selezionare tutte le funzionalità)"></asp:Label>
                <asp:CheckBoxList ID="cblGraphicDesign" runat="server" Font-Names="Century Gothic" Style="margin-left: 17px">
                    <asp:ListItem>CORPORATE IDENTITY</asp:ListItem>
                    <asp:ListItem>SHOPPER &amp; BROCHURE/CATALOGHI</asp:ListItem>
                    <asp:ListItem>SUPPORTI CARTACEI</asp:ListItem>
                    <asp:ListItem>SUPPORTI RIGIDI</asp:ListItem>
                    <asp:ListItem>ADVERTISING</asp:ListItem>
                    <asp:ListItem>MARKETING STRATEGY</asp:ListItem>
                </asp:CheckBoxList>
                <br />
                <asp:Label ID="Label19" runat="server" Font-Bold="True" Font-Names="Century Gothic" Font-Size="X-Large" Text="PIANO EDITORIALE - GESTIONE SITO WEB"></asp:Label>
                <br />
                <asp:Label ID="Label20" runat="server" Font-Bold="False" Font-Names="Century Gothic" Font-Size="Large" Text="TIME PACK (importi mensili)"></asp:Label>
                <asp:RadioButtonList ID="rblPESitoWebTime" runat="server" Font-Names="Century Gothic" Style="margin-left: 17px">
                    <asp:ListItem>DAILY</asp:ListItem>
                    <asp:ListItem>THREE-DAYS</asp:ListItem>
                    <asp:ListItem>WEEKLY</asp:ListItem>
                    <asp:ListItem>BI-MONTHLY</asp:ListItem>
                    <asp:ListItem>MONTHLY</asp:ListItem>
                </asp:RadioButtonList>
                <br />
                <asp:Label ID="Label21" runat="server" Font-Bold="False" Font-Names="Century Gothic" Font-Size="Large" Text="CONTENT PACK (importi mensili)"></asp:Label>
                <asp:RadioButtonList ID="rblPESitoWebContent" runat="server" Font-Names="Century Gothic" Style="margin-left: 17px">
                    <asp:ListItem>ESSENTIAL</asp:ListItem>
                    <asp:ListItem>BASIC</asp:ListItem>
                    <asp:ListItem>ADVANCED</asp:ListItem>
                    <asp:ListItem>TOP</asp:ListItem>
                    <asp:ListItem>UNLIMITED</asp:ListItem>
                </asp:RadioButtonList>
                <br />
                <asp:Label ID="Label22" runat="server" Font-Bold="True" Font-Names="Century Gothic" Font-Size="X-Large" Text="PIANO EDITORIALE - GESTIONE CANALI SOCIAL"></asp:Label>
                <br />
                <asp:Label ID="Label23" runat="server" Font-Bold="False" Font-Names="Century Gothic" Font-Size="Large" Text="TIME PACK (importi mensili)"></asp:Label>
                <asp:RadioButtonList ID="rblPESocialTime" runat="server" Font-Names="Century Gothic" Style="margin-left: 17px">
                    <asp:ListItem>DAILY</asp:ListItem>
                    <asp:ListItem>THREE-DAYS</asp:ListItem>
                    <asp:ListItem>WEEKLY</asp:ListItem>
                    <asp:ListItem>BI-MONTHLY</asp:ListItem>
                    <asp:ListItem>MONTHLY</asp:ListItem>
                </asp:RadioButtonList>
                <br />
                <asp:Label ID="Label24" runat="server" Font-Bold="False" Font-Names="Century Gothic" Font-Size="Large" Text="CONTENT PACK (importi mensili)"></asp:Label>
                <asp:RadioButtonList ID="rblPESocialContent" runat="server" Font-Names="Century Gothic" Style="margin-left: 17px">
                    <asp:ListItem>ESSENTIAL</asp:ListItem>
                    <asp:ListItem>BASIC</asp:ListItem>
                    <asp:ListItem>ADVANCED</asp:ListItem>
                    <asp:ListItem>TOP</asp:ListItem>
                    <asp:ListItem>UNLIMITED</asp:ListItem>
                </asp:RadioButtonList>
                <br />
                <br />
            </asp:Panel>

            <br />
            <br />
            <asp:Button ID="btnTuttoInUno" runat="server" Font-Bold="True" Font-Names="Century Gothic" Font-Size="X-Large" Height="51px" OnClick="btnTuttoInUno_Click" Style="margin-left: 224px" Text="CARICA PACCHETTI TUTTO IN UNO" Width="437px" />
            <br />


            <asp:Panel ID="pnlTuttoInUno" runat="server" BorderStyle="Solid">
                <asp:Panel ID="Panel4" runat="server" BackColor="#990000" Height="44px" Style="text-align: center">
                    <asp:Label ID="Label4" runat="server" Font-Names="Century Gothic" Font-Size="XX-Large" ForeColor="White" Style="text-align: center" Text="#TUTTOINUNO" Font-Bold="True"></asp:Label>
                </asp:Panel>
                <br />
                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="X-Large" Text="PACCHETTI TUTTO IN UNO" Font-Names="Century Gothic"></asp:Label>
                <br />
                <asp:Label ID="Label30" runat="server" Font-Bold="False" Font-Names="Century Gothic" Font-Size="Large" Text="(sono selezionabili solo i pacchetti che corrispondono alle scelte effettuate in precedenza)"></asp:Label>
                <br />

                <asp:RadioButtonList ID="rblTuttoInUno" runat="server" Font-Names="Century Gothic" Style="margin-left: 17px">
                    <asp:ListItem>WEB</asp:ListItem>
                    <asp:ListItem>NETWORK</asp:ListItem>
                    <asp:ListItem>SHOP</asp:ListItem>
                    <asp:ListItem>E-NETWORK</asp:ListItem>
                    <asp:ListItem>PROFESSIONAL</asp:ListItem>
                    <asp:ListItem>COMPLETE</asp:ListItem>
                </asp:RadioButtonList>
                <br />
            </asp:Panel>
            <br />
            <asp:Panel ID="pnlNote" runat="server" Style="text-align: center" Height="160px">
                <asp:Label ID="lblNote" runat="server" Text="NOTE" Font-Names="Century Gothic" Font-Bold="True" Font-Size="Large"></asp:Label>
                <br />
                <asp:TextBox ID="txtNote" runat="server" Font-Names="Century Gothic" Height="126px" TextMode="MultiLine" Width="73%"></asp:TextBox>
            </asp:Panel>
            <br />
            <asp:Button ID="btnGeneraPreventivo" runat="server" Font-Bold="True" Font-Names="Century Gothic" Font-Size="X-Large" Height="51px" Style="margin-left: 288px" Text="GENERA PREVENTIVO" Width="312px" OnClick="btnGeneraPreventivo_Click" />
            <br />
            <br />
            <br />
            <asp:Panel ID="pnlVisualizzazione" runat="server">
                <asp:Image ID="Image1" runat="server" Height="164px" ImageUrl="~/Immagini/Sopra.png" Width="890px" />
                <br />
                <asp:Panel ID="Panel1" runat="server" Style="text-align: center">
                    <asp:GridView ID="GridView1" runat="server" Font-Names="Century Gothic" Style="margin-left: 320px" Width="252px" Visible="False">
                    </asp:GridView>
                </asp:Panel>
                <br />
                <br />
                <asp:Panel ID="Panel7" runat="server" BackColor="White" Style="text-align: center">
                    <asp:Label ID="lblPreventivo" runat="server" Font-Bold="True" Font-Size="X-Large" Font-Names="Century Gothic"></asp:Label>
                    <br />
                    <asp:Label ID="lblSconto" runat="server" Font-Bold="True" Font-Names="Century Gothic" Font-Size="X-Large"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="lblVediNote" runat="server" Font-Bold="False" Font-Names="Century Gothic" Font-Size="X-Large"></asp:Label>
                    <br />
                </asp:Panel>
                <asp:Image ID="Image2" runat="server" Height="176px" ImageUrl="~/Immagini/Sotto.png" Width="890px" />
            </asp:Panel>
            <br />
            
            <br />
            &nbsp;<br />
            <br />
        </div>
    </form>
    <p>
        &nbsp;
    </p>
</body>
</html>

