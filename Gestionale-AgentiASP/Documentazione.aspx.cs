using LibreriaGestionaleAgente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gestionale_AgentiASP
{
    public partial class Documentazione : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Agente.idSessione == -1)
            {
                Response.Redirect("~/LogIn.aspx");
            }            
        }

        protected void btnBrochure_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('" + "Documentation/Brochure.pdf" + "','_newtab');", true);
        }

        protected void btnCatalogo_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('" + "Documentation/CatalogoProdotti.pdf" + "','_newtab');", true);
        }

        protected void btnListinoPrezzi_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('" + "Documentation/ListinoPrezzi.pdf" + "','_newtab');", true);
        }

        protected void btnContrattoWitapp_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('" + "Documentation/ContrattoWitapp.pdf" + "','_newtab');", true);
        }

        protected void btnContrattoRW_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('" + "Documentation/ContrattoRentalWeb.pdf" + "','_newtab');", true);
        }

        protected void btnCalcoloRataRW_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('" + "Documentation/CalcoloRataRentalWeb.pdf" + "','_newtab');", true);
        }
    }
}