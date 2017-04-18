using Gestionale_AgentiDAO;
using LibreriaGestionaleAgente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gestionale_AgentiASP
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Agente.idSessione = -1;
            lblErrore.Visible = false;
            pnlLogin.Visible = true;
        }

        protected void btnAccedi_Click(object sender, EventArgs e)
        {
            try
            {
                bool Verifica = AgenteDAO.VerificaLogin(txtUsername.Text, txtPassword.Text);

                if (Verifica == true)
                {
                    Response.Redirect("~/Default.aspx");
                }
                else
                {
                    lblErrore.Visible = true;
                    lblErrore.Text = "Dati inseriti non corretti";
                }
            }
            catch (Exception ex)
            {
                lblErrore.Visible = true;
                lblErrore.Text = "ERRORE: \n" + ex.Message;
            }
        }
    }
}