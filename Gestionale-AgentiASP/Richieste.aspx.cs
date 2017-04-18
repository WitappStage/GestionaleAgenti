using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibreriaGestionaleAgente;
using Gestionale_AgentiDAO;
using Gestionale_AgentiASP;
using System.Windows.Forms;

namespace Gestionale_AgentiASP
{
    public partial class Richieste : System.Web.UI.Page
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
                    grdListaRichieste.Columns[0].ItemStyle.Wrap = false;
                    grdListaRichieste.Columns[1].ItemStyle.Wrap = false;
                    grdListaRichieste.Columns[2].ItemStyle.Wrap = false;
                    grdListaRichieste.Columns[3].ItemStyle.Wrap = false;
                    grdListaRichieste.Columns[5].ItemStyle.Wrap = false;
                    grdListaRichieste.Columns[6].ItemStyle.Wrap = false;
                    grdListaRichieste.Columns[7].ItemStyle.Wrap = false;

                    lblErrore1.Visible = false;
                    lblErrore2.Visible = false;
                    pnlInserisciCliente.Visible = false;
                    hddAg.Value = Agente.idSessione.ToString();
                    BindGrid();
                    FillDdlClienti();
                    grdListaRichieste.Columns[5].Visible = false;
                    grdListaRichieste.Columns[6].Visible = false;
                    grdListaRichieste.Columns[7].Visible = false;
                    btnUpdate.Visible = false;


                    if (int.Parse(hddAg.Value) == 1)
                    {
                        grdListaRichieste.Columns[5].Visible = true;
                        grdListaRichieste.Columns[6].Visible = true;
                        grdListaRichieste.Columns[7].Visible = true;
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
            pnlInserisciRichiesta.Visible = false;
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
                else if (ddlCliente.SelectedIndex == 0)
                {
                    lblErrore1.Visible = true;
                    lblErrore1.Text = "ERRORE: Devi selezionare un cliente";
                }
                else if (txtSettore.Text == "")
                {
                    lblErrore1.Visible = true;
                    lblErrore1.Text = "ERRORE: Devi inserire il settore dell'azienda";
                }
                else if (txtNote.Text == "")
                {
                    lblErrore1.Visible = true;
                    lblErrore1.Text = "ERRORE: Devi specificare la richiesta";
                }
                else
                {
                    int idRichiesta = -1;
                    int clienteId = int.Parse(ddlCliente.SelectedItem.Value);
                    string nominativoCliente = ddlCliente.SelectedItem.Text;

                    Richiesta varRichiesta = new Richiesta(idRichiesta, txtData.Text, clienteId, nominativoCliente, txtSettore.Text, txtNote.Text, int.Parse(hddAg.Value));

                    RichiestaDAO.InsertRichiesta(varRichiesta);

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

                    pnlInserisciRichiesta.Visible = true;
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

        protected void grdListaRichieste_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "VediDettagli")
            {
                try
                {
                    pnlDettagliCliente.Visible = true;
                    Richiesta tmpRichiesta = RichiestaDAO.GetRichiesta(int.Parse(e.CommandArgument.ToString()));
                    int idCliente = tmpRichiesta.ClienteId;
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
                Richiesta tmpRichiesta = RichiestaDAO.GetRichiesta(int.Parse(e.CommandArgument.ToString()));
                RichiestaDAO.DeleteRichiesta(tmpRichiesta);
                BindGrid();
            }
            else if (e.CommandName == "Modifica")
            {
                Richiesta tmpRichiesta = RichiestaDAO.GetRichiesta(int.Parse(e.CommandArgument.ToString()));
                txtId.Text = tmpRichiesta.Id.ToString();
                txtData.Text = tmpRichiesta.Data;
                for (int i = 0; i < ddlCliente.Items.Count; i++)
                {
                    int idCliente = Int32.Parse(ddlCliente.Items[i].Value);
                    if (idCliente == tmpRichiesta.ClienteId)
                    {
                        ddlCliente.SelectedIndex = i;
                        break;
                    }
                }
                txtSettore.Text = tmpRichiesta.Settore;
                txtNote.Text = tmpRichiesta.Note;
                hddAgenteModifica.Value = tmpRichiesta.AgenteId.ToString();                
                btnInserisci.Visible = false;
                btnUpdate.Visible = true;
                btnCliente.Visible = false;
                btnModifica.Visible = true;
                btnEliminaCliente.Visible = true;
            }
        }

        protected void BindGrid()
        {
            List<Richiesta> listaRichieste = new List<Richiesta>();
            listaRichieste = RichiestaDAO.GetListRichieste(int.Parse(hddAg.Value));
            grdListaRichieste.DataSource = listaRichieste;
            grdListaRichieste.DataBind();
            PulisciTxtBox();
        }

        protected void PulisciTxtBox()
        {
            txtId.Text = null;
            txtData.Text = null;
            ddlCliente.SelectedValue = "-1";
            txtNote.Text = null;
            txtSettore.Text = null;
            lblErrore1.Text = null;
            lblErrore2.Text = null;
            btnUpdate.Visible = false;
            btnCliente.Visible = true;
            btnModifica.Visible = false;
            btnEliminaCliente.Visible = false;
            btnInserisci.Visible = true;
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
            pnlInserisciRichiesta.Visible = true;
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
            btnInserisci2.Visible = true;

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
            pnlInserisciRichiesta.Visible = false;
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

                    pnlInserisciRichiesta.Visible = true;
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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtData.Text == "")
                {
                    lblErrore1.Visible = true;
                    lblErrore1.Text = "ERRORE: Devi inserire una data valida";
                }
                else if (ddlCliente.SelectedIndex == 0)
                {
                    lblErrore1.Visible = true;
                    lblErrore1.Text = "ERRORE: Devi selezionare un cliente";
                }
                else if (txtSettore.Text == "")
                {
                    lblErrore1.Visible = true;
                    lblErrore1.Text = "ERRORE: Devi inserire il settore dell'azienda";
                }
                else if (txtNote.Text == "")
                {
                    lblErrore1.Visible = true;
                    lblErrore1.Text = "ERRORE: Devi specificare la richiesta";
                }
                else
                {
                    int clienteId = int.Parse(ddlCliente.SelectedItem.Value);
                    string nominativoCliente = ddlCliente.SelectedItem.Text;
                    Richiesta varRichiesta = new Richiesta(int.Parse(txtId.Text), txtData.Text, clienteId, nominativoCliente, txtSettore.Text, txtNote.Text, int.Parse(hddAgenteModifica.Value));
                    RichiestaDAO.UpdateRichiesta(varRichiesta);
                    BindGrid();
                }                
            }
            catch (Exception ex)
            {
                lblErrore1.Visible = true;
                lblErrore1.Text = "ERRORE: \n" + ex.Message;
            }
        }
    }
}