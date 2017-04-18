﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibreriaGestionaleAgente;
using Gestionale_AgentiDAO;
using System.IO;

namespace Gestionale_AgentiASP
{
    public partial class Contratti : System.Web.UI.Page
    {
        public static string nomeAllegato = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Agente.idSessione == -1)
            {
                Response.Redirect("~/LogIn.aspx");
            }

            hddAg.Value = Agente.idSessione.ToString();

            if (!IsPostBack)
            {
                try
                {
                    grdListaContratti.Columns[1].ItemStyle.Wrap = false;
                    lblErrore1.Visible = false;
                    lblErrore2.Visible = false;
                    pnlInserisciCliente.Visible = false;
                    ddlEsito.Visible = false;
                    lblEsito.Visible = false;
                    ddlEsito.Items.Add(new ListItem(" ", "-1"));
                    ddlEsito.Items.Add(new ListItem("Lavori Avviati", "0"));
                    ddlEsito.Items.Add(new ListItem("Lavori in Corso", "1"));
                    ddlEsito.Items.Add(new ListItem("Lavoro Ultimato", "2"));
                    ddlEsito.Items.Add(new ListItem("Lavoro Pubblicato", "3"));
                    ddlEsito.Items.Add(new ListItem("ATTENZIONE!", "4"));
                    BindGrid();
                    FillDdlClienti();
                    grdListaContratti.Columns[6].Visible = false;
                    grdListaContratti.Columns[7].Visible = false;
                    grdListaContratti.Columns[8].Visible = false;
                    btnUpdate.Visible = false;

                    if (int.Parse(hddAg.Value) == 1)
                    {
                        grdListaContratti.Columns[6].Visible = true;
                        ddlEsito.Visible = true;
                        lblEsito.Visible = true;
                        grdListaContratti.Columns[7].Visible = true;
                        grdListaContratti.Columns[8].Visible = true;

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
            pnlInserisciContratto.Visible = false;
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
                else if (FileUpload1.FileName == "")
                {
                    lblErrore1.Visible = true;
                    lblErrore1.Text = "ERRORE: Devi allegare il contratto";
                }
                else
                {
                    int idContratto = -1;
                    int clienteId = int.Parse(ddlCliente.SelectedItem.Value);
                    string nominativoCliente = ddlCliente.SelectedItem.Text;

                    Allega(hddAg.Value);

                    Contratto varContratto = new Contratto(idContratto, txtData.Text, clienteId, nominativoCliente, ddlEsito.SelectedItem.Text, txtNote.Text, 0, 0, nomeAllegato, int.Parse(hddAg.Value));
                    ContrattoDAO.InsertContratto(varContratto);

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

                    pnlInserisciContratto.Visible = true;
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

        protected void grdListaContratti_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "VediDettagli")
            {
                try
                {
                    pnlDettagliCliente.Visible = true;
                    Contratto tmpContratto = ContrattoDAO.GetContratto(int.Parse(e.CommandArgument.ToString()));
                    int idCliente = tmpContratto.ClienteId;
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
            else if (e.CommandName == "VediAllegato")
            {
                Contratto tmpContratto = ContrattoDAO.GetContratto(int.Parse(e.CommandArgument.ToString()));
                string YourURL = tmpContratto.UrlAllegato;
                Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('" + YourURL + "','_newtab');", true);
            }
            else if (e.CommandName == "Elimina")
            {
                Contratto tmpContratto = ContrattoDAO.GetContratto(int.Parse(e.CommandArgument.ToString()));
                if (tmpContratto.UrlAllegato != "")
                {
                    File.Delete(Server.MapPath("~/" + tmpContratto.UrlAllegato));
                    AllegatoDAO.DeleteAllegato(tmpContratto.UrlAllegato);
                }
                ContrattoDAO.DeleteContratto(tmpContratto);
                BindGrid();
            }
            else if (e.CommandName == "Modifica")
            {
                Contratto tmpContratto = ContrattoDAO.GetContratto(int.Parse(e.CommandArgument.ToString()));
                txtId.Text = tmpContratto.Id.ToString();
                txtData.Text = tmpContratto.Data;
                for (int i = 0; i < ddlCliente.Items.Count; i++)
                {
                    int idCliente = Int32.Parse(ddlCliente.Items[i].Value);
                    if (idCliente == tmpContratto.ClienteId)
                    {
                        ddlCliente.SelectedIndex = i;
                        break;
                    }
                }
                for (int i = 0; i < ddlEsito.Items.Count; i++)
                {
                    String Esito = ddlEsito.Items[i].Text;
                    if (Esito == tmpContratto.Esito)
                    {
                        ddlEsito.SelectedIndex = i;
                        break;
                    }
                }
                txtNote.Text = tmpContratto.Note;
                hddAgenteModifica.Value = tmpContratto.AgenteId.ToString();
                nomeAllegato = tmpContratto.UrlAllegato;
                btnInserisci.Visible = false;
                btnUpdate.Visible = true;
                btnCliente.Visible = false;
                btnModifica.Visible = true;
                btnEliminaCliente.Visible = true;
            }
        }

        protected void BindGrid()
        {
            List<Contratto> listaContratti = new List<Contratto>();
            listaContratti = ContrattoDAO.GetListContratti(int.Parse(hddAg.Value));
            grdListaContratti.DataSource = listaContratti;
            grdListaContratti.DataBind();
            PulisciTxtBox();
        }

        protected void PulisciTxtBox()
        {
            txtId.Text = null;
            txtData.Text = null;
            ddlCliente.SelectedValue = "-1";
            ddlEsito.SelectedValue = "-1";
            txtNote.Text = null;
            lblErrore1.Text = null;
            lblErrore2.Text = null;
            lblSuccesso.Visible = false;
            lblSuccesso.Text = "";
            FileUpload1.Visible = true;
            btnUpdate.Visible = false;
            btnInserisci.Visible = true;
            btnCliente.Visible = true;
            btnModifica.Visible = false;
            btnEliminaCliente.Visible = false;
            nomeAllegato = "";
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
            pnlInserisciContratto.Visible = true;
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
            pnlInserisciContratto.Visible = false;
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

                    pnlInserisciContratto.Visible = true;
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
                else
                {
                    if (!(FileUpload1.FileName == ""))
                    {
                        if (!(nomeAllegato == ""))
                        {
                            AllegatoDAO.DeleteAllegato(nomeAllegato);
                            File.Delete(Server.MapPath("~/" + nomeAllegato));
                        }
                    }
                    Allega(hddAgenteModifica.Value);
                    int clienteId = int.Parse(ddlCliente.SelectedItem.Value);
                    string nominativoCliente = ddlCliente.SelectedItem.Text;
                    string esito = ddlEsito.SelectedItem.Text;

                    Contratto varContratto = new Contratto(int.Parse(txtId.Text), txtData.Text, clienteId, nominativoCliente, esito, txtNote.Text, nomeAllegato, int.Parse(hddAgenteModifica.Value));
                    ContrattoDAO.UpdateContratto(varContratto);
                    BindGrid();
                }
            }

            catch (Exception ex)
            {
                lblErrore1.Visible = true;
                lblErrore1.Text = "ERRORE: \n" + ex.Message;
            }
        }

        protected void Allega(string idAg)
        {
            if (!(FileUpload1.FileName == ""))
            {
                if (IsPostBack)
                {
                    Boolean fileOK = false;
                    String path = Server.MapPath("~/UploadedDocuments/");
                    if (FileUpload1.HasFile)
                    {
                        String fileExtension =
                            System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
                        String[] allowedExtensions =
                            {".pdf" , ".jpg"};
                        for (int i = 0; i < allowedExtensions.Length; i++)
                        {
                            if (fileExtension == allowedExtensions[i])
                            {
                                fileOK = true;
                            }
                        }
                    }

                    if (fileOK)
                    {
                        try
                        {
                            string dataAttuale = DateTime.Now.ToString().Split(' ')[0];
                            string oraAttuale = DateTime.Now.ToString().Split(' ')[1];
                            string now = dataAttuale.Split('/')[0] + dataAttuale.Split('/')[1] + dataAttuale.Split('/')[2] + oraAttuale.Split(':')[0] + oraAttuale.Split(':')[1] + oraAttuale.Split(':')[2];
                            FileUpload1.PostedFile.SaveAs(path + idAg + "_" + now + "_" + FileUpload1.FileName);
                            int idAllegato = -1;
                            nomeAllegato = ("UploadedDocuments/") + idAg + "_" + now + "_" + FileUpload1.FileName;
                            Allegato tmpAllegato = new Allegato(idAllegato, nomeAllegato, FileUpload1.FileName, int.Parse(idAg));
                            AllegatoDAO.InsertAllegato(tmpAllegato);
                            FileUpload1.Visible = false;
                            lblSuccesso.Visible = true;
                            lblSuccesso.Text = "File caricato!";
                            lblErrore1.Visible = false;
                        }
                        catch (Exception ex)
                        {
                            lblErrore1.Visible = true;
                            lblErrore1.Text = "Errore durante il caricamento del file.";
                        }
                    }
                    else
                    {
                        lblErrore1.Visible = true;
                        lblErrore1.Text = "Impossibile accettare file di questo tipo. Inserisci un PDF!";
                    }
                }
            }
        }
    }
}