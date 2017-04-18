using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Gestionale_AgentiDAO;
using System.Data.SQLite;
using LibreriaGestionaleAgente;

namespace Gestionale_AgentiASP
{
    public partial class CreazioneDB : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Gestionale_AgentiDAO.CreazioneDB.CreaDB();         

            CreazioneTabelle.CreaTabellaAgenti();
            CreazioneTabelle.CreaTabellaAllegati();
            CreazioneTabelle.CreaTabellaAppuntamenti();
            CreazioneTabelle.CreaTabellaClienti();
            CreazioneTabelle.CreaTabellaContratti();
            CreazioneTabelle.CreaTabellaFatture();
            CreazioneTabelle.CreaTabellaOfferte();
            CreazioneTabelle.CreaTabellaRichieste();

            CreazioneTabelle.CreaIndiciUnivociClienti();

            PopolaAgenti.InserisciAdmin();
            PopolaAgenti.InserisciUtenteProva();




            //Agente ag = AgenteDAO.GetAgente(1);
            //Label1.Text = ag.Nome + ag.Cognome + ag.Email;
            //List<Agente> l = AgenteDAO.GetListAgenti();
            //Agente ag = l[3];
            //Label1.Text = "->" + ag.Id + "<-" + ag.Nome + ag.Cognome;

        }
    }
}