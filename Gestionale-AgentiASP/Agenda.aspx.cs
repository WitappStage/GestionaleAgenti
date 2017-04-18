using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using LibreriaGestionaleAgente;
using Gestionale_AgentiDAO;

namespace Gestionale_AgentiASP
{
    public partial class Agenda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Agente.idSessione == -1)
            {
                Response.Redirect("~/LogIn.aspx");
            }

            if (!IsPostBack)
            {
                try
                {
                    grdListaAppuntamenti.Columns[1].ItemStyle.Wrap = false;
                    lblErrore1.Visible = false;                    
                    lblErrore2.Visible = false;
                    pnlInserisciCliente.Visible = false;
                    hddAg.Value = Agente.idSessione.ToString();
                    BindGrid();
                    FillDdlClienti();
                    grdListaAppuntamenti.Columns[4].Visible = false;                                      

                    if (int.Parse(hddAg.Value) == 1)
                    {
                        grdListaAppuntamenti.Columns[4].Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    lblErrore1.Visible = true;
                    lblErrore1.Text = "ERRORE: \n" + ex.Message;
                }
            }
        }

        protected void btnCliente_Click(object sender, EventArgs e)
        {
            txtRagioneSociale.Text = null;
            txtSedeLegale.Text = null;
            txtPartitaIva.Text = null;
            txtCodiceFiscale.Text = null;
            txtEmail.Text = null;
            txtPec.Text = null;
            txtTelefono.Text = null;
            txtReferente.Text = null;
            txtRefTelefono.Text = null;
            txtRefEmail.Text = null;
            pnlInserisciCliente.Visible = true;
            pnlInserisciAppuntamento.Visible = false;
            lblErrore2.Visible = false;

        }

        protected void btnInserisci_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtData.Text == "")
                {
                    lblErrore1.Visible = true;
                    lblErrore1.Text = "ERRORE: Devi inserire una data valida";
                }
                else if (txtOrario.Text == "")
                {
                    lblErrore1.Visible = true;
                    lblErrore1.Text = "ERRORE: Devi inserire un orario valido";
                }
                else if (ddlCliente.SelectedIndex == 0)
                {
                    lblErrore1.Visible = true;
                    lblErrore1.Text = "ERRORE: Devi selezionare un cliente";
                }
                else
                {
                    int idAppuntamento = -1;
                    int clienteId = int.Parse(ddlCliente.SelectedItem.Value);
                    string nominativoCliente = ddlCliente.SelectedItem.Text;


                    Appuntamento varAppuntamento = new Appuntamento(idAppuntamento, DateTime.Parse(txtData.Text + " " + txtOrario.Text), clienteId, nominativoCliente, txtDescrizione.Text, int.Parse(hddAg.Value));

                    AppuntamentoDAO.InsertAppuntamento(varAppuntamento);

                    BindGrid();
                }                
            }
            catch (Exception ex)
            {
                lblErrore1.Visible = true;
                lblErrore1.Text = "ERRORE: \n" + ex.Message;
            }
        }

        protected void btnInserisci2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtRagioneSociale.Text == "")
                {
                    lblErrore2.Visible = true;
                    lblErrore2.Text = "ERRORE: Devi inserire la ragione sociale";
                }
                else if (txtSedeLegale.Text == "")
                {
                    lblErrore2.Visible = true;
                    lblErrore2.Text = "ERRORE: Devi inserire la sede legale";
                }
                else if (txtPartitaIva.Text == "")
                {
                    lblErrore2.Visible = true;
                    lblErrore2.Text = "ERRORE: Devi inserire la partita iva";
                }
                else if (txtPec.Text == "")
                {
                    lblErrore2.Visible = true;
                    lblErrore2.Text = "ERRORE: Devi inserire la pec";
                }
                else if (txtTelefono.Text == "")
                {
                    lblErrore2.Visible = true;
                    lblErrore2.Text = "ERRORE: Devi inserire il numero di telefono";
                }
                else if (txtReferente.Text == "")
                {
                    lblErrore2.Visible = true;
                    lblErrore2.Text = "ERRORE: Devi inserire un referente dell'azienda";
                }
                else
                {
                    int idCliente = -1;

                    Cliente varCliente = new Cliente(idCliente, txtRagioneSociale.Text, txtSedeLegale.Text, txtPartitaIva.Text, txtCodiceFiscale.Text, txtEmail.Text, txtPec.Text, txtTelefono.Text, txtReferente.Text, txtRefTelefono.Text, txtRefEmail.Text, int.Parse(hddAg.Value));

                    ClienteDAO.InsertCliente(varCliente);

                    pnlInserisciAppuntamento.Visible = true;
                    pnlInserisciCliente.Visible = false;

                    FillDdlClienti();
                }
            }
            catch (Exception ex)
            {
                lblErrore2.Visible = true;
                lblErrore2.Text = "ERRORE: \n" + ex.Message;
            }
        }

        protected void grdListaAppuntamenti_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "VediDettagli")
            {
                try
                {
                    pnlDettagliCliente.Visible = true;
                    Appuntamento tmpAppuntamento = AppuntamentoDAO.GetAppuntamento(int.Parse(e.CommandArgument.ToString()));
                    int idCliente = tmpAppuntamento.ClienteId;
                    Cliente tmpCliente = ClienteDAO.GetCliente(idCliente);
                    txtDettagliId.Text = tmpCliente.Id.ToString();
                    txtDettagliRagioneSociale.Text = tmpCliente.RagioneSociale;
                    txtDettagliSedeLegale.Text = tmpCliente.SedeLegale;
                    txtDettagliPartitaIva.Text = tmpCliente.PartitaIva;
                    txtDettagliCodiceFiscale.Text = tmpCliente.CodiceFiscale;
                    txtDettagliEmail.Text = tmpCliente.Email;
                    txtDettagliPec.Text = tmpCliente.Pec;
                    txtDettagliTelefono.Text = tmpCliente.Telefono;
                    txtDettagliReferente.Text = tmpCliente.Referente;
                    txtDettagliRefTelefono.Text = tmpCliente.RefTelefono;
                    txtDettagliRefEmail.Text = tmpCliente.RefEmail;
                }
                catch (Exception ex)
                {
                    lblErrore3.Visible = true;
                    lblErrore3.Text = "ERRORE: \n" + ex.Message;
                }
            }
            else if (e.CommandName == "Elimina")
            {
                Appuntamento tmpAppuntamento = AppuntamentoDAO.GetAppuntamento(int.Parse(e.CommandArgument.ToString()));                
                AppuntamentoDAO.DeleteAppuntamento(tmpAppuntamento);
                BindGrid();
            }
            else if (e.CommandName == "Modifica")
            {
                Appuntamento tmpAppuntamento = AppuntamentoDAO.GetAppuntamento(int.Parse(e.CommandArgument.ToString()));
                txtId.Text = tmpAppuntamento.Id.ToString();
                string data = tmpAppuntamento.Data.ToString().Split(' ')[0];
                txtData.Text = data.Split('/')[2] + "-" + data.Split('/')[1] + "-" + data.Split('/')[0];
                for (int i = 0; i < ddlCliente.Items.Count; i++)
                {
                    int idCliente = Int32.Parse(ddlCliente.Items[i].Value);
                    if (idCliente == tmpAppuntamento.ClienteId)
                    {
                        ddlCliente.SelectedIndex = i;
                        break;
                    }
                }
                txtOrario.Text = tmpAppuntamento.Data.ToString().Split(' ')[1];
                txtDescrizione.Text = tmpAppuntamento.Descrizione;
                hddAgenteModifica.Value = tmpAppuntamento.AgenteId.ToString();

                btnInserisci.Visible = false;
                btnUpdate.Visible = true;
                btnCliente.Visible = false;
                btnModifica.Visible = true;
                btnEliminaCliente.Visible = true;
            }
        }

        protected void BindGrid()
        {
            List<Appuntamento> listaAppuntamenti = new List<Appuntamento>();
            listaAppuntamenti = AppuntamentoDAO.GetListAppuntamenti(int.Parse(hddAg.Value));
            grdListaAppuntamenti.DataSource = listaAppuntamenti;
            grdListaAppuntamenti.DataBind();
            PulisciTxtBox();
            selezionaApp();
        }

        protected void PulisciTxtBox()
        {
            txtId.Text = null;
            txtData.Text = null;
            txtOrario.Text = null;
            ddlCliente.SelectedValue = "-1";
            txtDescrizione.Text = null;
            lblErrore1.Text = null;
            lblErrore2.Text = null;
            btnCliente.Visible = true;
            btnModifica.Visible = false;
            btnEliminaCliente.Visible = false;
            btnInserisci.Visible = true;
            btnUpdate.Visible = false;
        }

        protected void FillDdlClienti()
        {
            List<Cliente> listClienti = ClienteDAO.GetListClienti(int.Parse(hddAg.Value));

            ddlCliente.Items.Clear();
            ddlCliente.Items.Add(new ListItem("NESSUNO", "-1"));
            foreach (Cliente cliente in listClienti)
            {
                ddlCliente.Items.Add(new ListItem(cliente.RagioneSociale, cliente.Id.ToString()));
            }
            if (int.Parse(hddAg.Value) == 1)
            {
                for (int i = 1; i < ddlCliente.Items.Count; i++)
                {
                    int idCliente = int.Parse(ddlCliente.Items[i].Value);
                    int idAgente = (ClienteDAO.GetCliente(idCliente)).AgenteId;
                    Agente tmpAgente = AgenteDAO.GetAgente(idAgente);
                    string nomeAgente = (tmpAgente.Nome + " " + tmpAgente.Cognome);
                    ddlCliente.Items[i].Text += (" - (" + nomeAgente + ")");
                }
                //Agente.idSessione = 2002;
            }
            btnEliminaCliente.Visible = false;
            btnModifica.Visible = false;
            btnCliente.Visible = true;
        }        

        protected void btnAnnulla_Click(object sender, EventArgs e)
        {
            pnlInserisciCliente.Visible = false;
            pnlInserisciAppuntamento.Visible = true;
            hddId.Value = null;
            txtRagioneSociale.Text = null;
            txtSedeLegale.Text = null;
            txtPartitaIva.Text = null;
            txtCodiceFiscale.Text = null;
            txtEmail.Text = null;
            txtPec.Text = null;
            txtTelefono.Text = null;
            txtReferente.Text = null;
            txtRefTelefono.Text = null;
            txtRefEmail.Text = null;
            btnSalvaModifiche.Visible = false;
            btnCliente.Visible = true;
            btnModifica.Visible = false;
            btnEliminaCliente.Visible = false;
            btnInserisci2.Visible = true;
            lblErrore2.Visible = false;


            Label1.Text = "Inserisci Cliente";
        }

        protected void ddlCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Int32.Parse(ddlCliente.SelectedItem.Value) == -1)
            {
                btnModifica.Visible = false;
                btnEliminaCliente.Visible = false;
                btnCliente.Visible = true;
            }
            else
            {
                btnModifica.Visible = true;
                btnEliminaCliente.Visible = true;
                btnCliente.Visible = false;
            }

        }

        protected void btnModifica_Click(object sender, EventArgs e)
        {
            pnlInserisciCliente.Visible = true;
            pnlInserisciAppuntamento.Visible = false;
            btnInserisci2.Visible = false;
            btnSalvaModifiche.Visible = true;
            int idCliente = int.Parse(ddlCliente.SelectedItem.Value);
            Cliente tmpCliente = ClienteDAO.GetCliente(idCliente);
            hddId.Value = tmpCliente.Id.ToString();
            txtRagioneSociale.Text = tmpCliente.RagioneSociale;
            txtSedeLegale.Text = tmpCliente.SedeLegale;
            txtPartitaIva.Text = tmpCliente.PartitaIva;
            txtCodiceFiscale.Text = tmpCliente.CodiceFiscale;
            txtEmail.Text = tmpCliente.Email;
            txtPec.Text = tmpCliente.Pec;
            txtTelefono.Text = tmpCliente.Telefono;
            txtReferente.Text = tmpCliente.Referente;
            txtRefTelefono.Text = tmpCliente.RefTelefono;
            txtRefEmail.Text = tmpCliente.RefEmail;
            lblErrore2.Visible = false;


            Label1.Text = "Modifica Cliente";
        }

        protected void btnSalvaModifiche_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtRagioneSociale.Text == "")
                {
                    lblErrore2.Visible = true;
                    lblErrore2.Text = "ERRORE: Devi inserire la ragione sociale";
                }
                else if (txtSedeLegale.Text == "")
                {
                    lblErrore2.Visible = true;
                    lblErrore2.Text = "ERRORE: Devi inserire la sede legale";
                }
                else if (txtPartitaIva.Text == "")
                {
                    lblErrore2.Visible = true;
                    lblErrore2.Text = "ERRORE: Devi inserire la partita iva";
                }
                else if (txtPec.Text == "")
                {
                    lblErrore2.Visible = true;
                    lblErrore2.Text = "ERRORE: Devi inserire la pec";
                }
                else if (txtTelefono.Text == "")
                {
                    lblErrore2.Visible = true;
                    lblErrore2.Text = "ERRORE: Devi inserire il numero di telefono";
                }
                else if (txtReferente.Text == "")
                {
                    lblErrore2.Visible = true;
                    lblErrore2.Text = "ERRORE: Devi inserire un referente dell'azienda";
                }
                else
                {
                    int idCliente = int.Parse(hddId.Value);

                    Cliente varCliente = new Cliente(idCliente, txtRagioneSociale.Text, txtSedeLegale.Text, txtPartitaIva.Text, txtCodiceFiscale.Text, txtEmail.Text, txtPec.Text, txtTelefono.Text, txtReferente.Text, txtRefTelefono.Text, txtRefEmail.Text, int.Parse(hddAg.Value));

                    ClienteDAO.UpdateCliente(varCliente);

                    pnlInserisciAppuntamento.Visible = true;
                    pnlInserisciCliente.Visible = false;

                    FillDdlClienti();
                    btnModifica.Visible = false;
                    btnEliminaCliente.Visible = false;
                    btnSalvaModifiche.Visible = false;
                    btnInserisci2.Visible = true;
                    Label1.Text = "Inserisci Cliente";
                    btnCliente.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblErrore2.Visible = true;
                lblErrore2.Text = "ERRORE: \n" + ex.Message;
            }
        }

        protected void btnChiudiDettagli_Click(object sender, EventArgs e)
        {
            pnlDettagliCliente.Visible = false;
        }

        protected void btnEliminaCliente_Click(object sender, EventArgs e)
        {
            try
            {
                int idCliente = int.Parse(ddlCliente.SelectedItem.Value);
                ClienteDAO.DeleteCliente(idCliente);
                FillDdlClienti();                
            }
            catch (Exception ex)
            {
                lblErrore1.Visible = true;
                lblErrore1.Text = "ERRORE: \n" + ex.Message;
            }
        }

        protected void Calendario_SelectionChanged(object sender, EventArgs e)
        {
            int agenteId = int.Parse(hddAg.Value);
            DateTime dataSel = Calendario.SelectedDate;
            List<Appuntamento> listaAppuntamenti = AppuntamentoDAO.GetListAppuntamenti(agenteId, dataSel);
            grdListaAppuntamenti.DataSource = listaAppuntamenti;
            grdListaAppuntamenti.DataBind();
        }

        protected void btnVediTutti_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void selezionaApp ()
        {
            List<Appuntamento> listaApp = AppuntamentoDAO.GetListAppuntamenti(int.Parse(hddAg.Value));
            Calendario.SelectedDates.Remove(Calendario.SelectedDate);
            foreach (Appuntamento app in listaApp)
            {
                Calendario.SelectedDates.Add(app.Data);
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {            
            try
            {
                if (txtData.Text == "")
                {
                    lblErrore1.Visible = true;
                    lblErrore1.Text = "ERRORE: Devi inserire una data valida";
                }
                else if (txtOrario.Text == "")
                {
                    lblErrore1.Visible = true;
                    lblErrore1.Text = "ERRORE: Devi inserire un orario valido";
                }
                else if (ddlCliente.SelectedIndex == 0)
                {
                    lblErrore1.Visible = true;
                    lblErrore1.Text = "ERRORE: Devi selezionare un cliente";
                }
                else
                {
                    int clienteId = int.Parse(ddlCliente.SelectedItem.Value);
                    string nominativoCliente = ddlCliente.SelectedItem.Text;
                    Appuntamento varAppuntamento = new Appuntamento(int.Parse(txtId.Text), DateTime.Parse(txtData.Text + " " + txtOrario.Text), clienteId, nominativoCliente, txtDescrizione.Text, int.Parse(hddAgenteModifica.Value));
                    AppuntamentoDAO.UpdateAppuntamento(varAppuntamento);
                    BindGrid();
                }                
            }
            catch (Exception ex)
            {
                lblErrore1.Visible = true;
                lblErrore1.Text = "ERRORE: Non tutti i campi sono compilati correttamente.";
            }            
        }
    }
}