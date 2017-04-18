using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibreriaGestionaleAgente;
using Gestionale_AgentiDAO;

namespace Gestionale_AgentiASP
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Agente.idSessione == -1)
            {
                Response.Redirect("~/LogIn.aspx");
            }
            pnlAreeInteresse.Visible = true;                
            btnLogOut.Visible = true;
        }
    }
}