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
    public partial class Preventivo : System.Web.UI.Page
    {
        public static decimal tmpPreventivo = 0;
        public static decimal tmpMensile = 0;
        public static int CosaMostrare = 0;      

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Agente.idSessione == -1)
            {
                Response.Redirect("~/LogIn.aspx");
            }

            rblTuttoInUno.Items[0].Attributes.CssStyle.Add("visibility", "hidden");
            rblTuttoInUno.Items[1].Attributes.CssStyle.Add("visibility", "hidden");
            rblTuttoInUno.Items[2].Attributes.CssStyle.Add("visibility", "hidden");
            rblTuttoInUno.Items[3].Attributes.CssStyle.Add("visibility", "hidden");
            rblTuttoInUno.Items[4].Attributes.CssStyle.Add("visibility", "hidden");
            rblTuttoInUno.Items[5].Attributes.CssStyle.Add("visibility", "hidden");

            pnlScelta.Visible = true;
            pnlApp.Visible = false;
            pnlExtra.Visible = false;
            pnlTuttoInUno.Visible = false;
            btnTuttoInUno.Visible = false;
            btnGeneraPreventivo.Visible = false;
            lblPreventivo.Visible = false;
            GridView1.Visible = false;
            pnlVisualizzazione.Visible = false;
            pnlNote.Visible = false;

            rblTuttoInUno.Items[0].Enabled = false;
            rblTuttoInUno.Items[1].Enabled = false;
            rblTuttoInUno.Items[2].Enabled = false;
            rblTuttoInUno.Items[3].Enabled = false;
            rblTuttoInUno.Items[4].Enabled = false;
            rblTuttoInUno.Items[5].Enabled = false;

            cbBasic.Checked = true;
            cbBasic.Enabled = false;
            btnTuttoInUno.Text = "CARICA PACCHETTI TUTTO IN UNO";

            if (CosaMostrare == 1)
            {
                pnlScelta.Visible = false;
                pnlApp.Visible = true;
                btnGeneraPreventivo.Visible = true;
                pnlNote.Visible = true;
            }
            else if (CosaMostrare == 2)
            {
                pnlScelta.Visible = false;
                pnlExtra.Visible = true;
                cbBasic.Checked = false;
                btnGeneraPreventivo.Visible = true;
                pnlNote.Visible = true;
            }
            else if (CosaMostrare == 3)
            {
                pnlScelta.Visible = false;
                pnlApp.Visible = true;
                pnlExtra.Visible = true;
                btnTuttoInUno.Visible = true;
                btnGeneraPreventivo.Visible = true;
                pnlNote.Visible = true;
            }
        }

        protected void cbPlus_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPlus.Checked == true)
            {
                cblPlus.Items[0].Selected = true;
                cblPlus.Items[1].Selected = true;
                cblPlus.Items[2].Selected = true;
                cblPlus.Items[3].Selected = true;
                cblPlus.Items[4].Selected = true;
                cblPlus.Items[5].Selected = true;
                cblPlus.Items[6].Selected = true;
                cblPlus.Items[7].Selected = true;
            }
            else if (cbPlus.Checked == false)
            {
                cblPlus.Items[0].Selected = false;
                cblPlus.Items[1].Selected = false;
                cblPlus.Items[2].Selected = false;
                cblPlus.Items[3].Selected = false;
                cblPlus.Items[4].Selected = false;
                cblPlus.Items[5].Selected = false;
                cblPlus.Items[6].Selected = false;
                cblPlus.Items[7].Selected = false;
            }
        }

        protected void cbRistorazione_CheckedChanged(object sender, EventArgs e)
        {
            if (cbRistorazione.Checked == true)
            {
                cblRistorazione.Items[0].Selected = true;
                cblRistorazione.Items[1].Selected = true;
                cblRistorazione.Items[2].Selected = true;
                cblRistorazione.Items[3].Selected = true;
            }
            else if (cbRistorazione.Checked == false)
            {
                cblRistorazione.Items[0].Selected = false;
                cblRistorazione.Items[1].Selected = false;
                cblRistorazione.Items[2].Selected = false;
                cblRistorazione.Items[3].Selected = false;
            }
        }

        protected void cbHotel_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHotel.Checked == true)
            {
                cblHotel.Items[0].Selected = true;
                cblHotel.Items[1].Selected = true;
                cblHotel.Items[2].Selected = true;
            }
            else if (cbHotel.Checked == false)
            {
                cblHotel.Items[0].Selected = false;
                cblHotel.Items[1].Selected = false;
                cblHotel.Items[2].Selected = false;
            }
        }

        protected void cbCampeggi_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCampeggi.Checked == true)
            {
                cblCampeggi.Items[0].Selected = true;
                cblCampeggi.Items[1].Selected = true;
                cblCampeggi.Items[2].Selected = true;
            }
            else if (cbCampeggi.Checked == false)
            {
                cblCampeggi.Items[0].Selected = false;
                cblCampeggi.Items[1].Selected = false;
                cblCampeggi.Items[2].Selected = false;
            }
        }

        protected void cbImmobiliare_CheckedChanged(object sender, EventArgs e)
        {
            if (cbImmobiliare.Checked == true)
            {
                cblImmobiliare.Items[0].Selected = true;
                cblImmobiliare.Items[1].Selected = true;
                cblImmobiliare.Items[2].Selected = true;
            }
            else if (cbImmobiliare.Checked == false)
            {
                cblImmobiliare.Items[0].Selected = false;
                cblImmobiliare.Items[1].Selected = false;
                cblImmobiliare.Items[2].Selected = false;
            }
        }

        protected void cbParrucchieri_CheckedChanged(object sender, EventArgs e)
        {
            if (cbParrucchieri.Checked == true)
            {
                cblParrucchieri.Items[0].Selected = true;
                cblParrucchieri.Items[1].Selected = true;
                cblParrucchieri.Items[2].Selected = true;
                cblParrucchieri.Items[3].Selected = true;
                cblParrucchieri.Items[4].Selected = true;
            }
            else if (cbParrucchieri.Checked == false)
            {
                cblParrucchieri.Items[0].Selected = false;
                cblParrucchieri.Items[1].Selected = false;
                cblParrucchieri.Items[2].Selected = false;
                cblParrucchieri.Items[3].Selected = false;
                cblParrucchieri.Items[4].Selected = false;
            }
        }

        protected void cbBenessere_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBenessere.Checked == true)
            {
                cblBenessere.Items[0].Selected = true;
                cblBenessere.Items[1].Selected = true;
                cblBenessere.Items[2].Selected = true;
                cblBenessere.Items[3].Selected = true;
                cblBenessere.Items[4].Selected = true;
            }
            else if (cbBenessere.Checked == false)
            {
                cblBenessere.Items[0].Selected = false;
                cblBenessere.Items[1].Selected = false;
                cblBenessere.Items[2].Selected = false;
                cblBenessere.Items[3].Selected = false;
                cblBenessere.Items[4].Selected = false;
            }
        }

        protected void cbFitness_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFitness.Checked == true)
            {
                cblFitness.Items[0].Selected = true;
                cblFitness.Items[1].Selected = true;
                cblFitness.Items[2].Selected = true;
                cblFitness.Items[3].Selected = true;
                cblFitness.Items[4].Selected = true;
            }
            else if (cbFitness.Checked == false)
            {
                cblFitness.Items[0].Selected = false;
                cblFitness.Items[1].Selected = false;
                cblFitness.Items[2].Selected = false;
                cblFitness.Items[3].Selected = false;
                cblFitness.Items[4].Selected = false;
            }
        }

        protected void cbConcessionari_CheckedChanged(object sender, EventArgs e)
        {
            if (cbConcessionari.Checked == true)
            {
                cblConcessionari.Items[0].Selected = true;
                cblConcessionari.Items[1].Selected = true;
                cblConcessionari.Items[2].Selected = true;
            }
            else if (cbConcessionari.Checked == false)
            {
                cblConcessionari.Items[0].Selected = false;
                cblConcessionari.Items[1].Selected = false;
                cblConcessionari.Items[2].Selected = false;
            }
        }

        protected void cbCentriCommerciali_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCentriCommerciali.Checked == true)
            {
                cblCentriCommerciali.Items[0].Selected = true;
                cblCentriCommerciali.Items[1].Selected = true;
                cblCentriCommerciali.Items[2].Selected = true;
                cblCentriCommerciali.Items[3].Selected = true;
            }
            else if (cbCentriCommerciali.Checked == false)
            {
                cblCentriCommerciali.Items[0].Selected = false;
                cblCentriCommerciali.Items[1].Selected = false;
                cblCentriCommerciali.Items[2].Selected = false;
                cblCentriCommerciali.Items[3].Selected = false;
            }
        }

        protected void cbMedico_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMedico.Checked == true)
            {
                cblMedico.Items[0].Selected = true;
                cblMedico.Items[1].Selected = true;
                cblMedico.Items[2].Selected = true;
            }
            else if (cbMedico.Checked == false)
            {
                cblMedico.Items[0].Selected = false;
                cblMedico.Items[1].Selected = false;
                cblMedico.Items[2].Selected = false;
            }
        }

        protected void cbFarmacia_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFarmacia.Checked == true)
            {
                cblFarmacia.Items[0].Selected = true;
                cblFarmacia.Items[1].Selected = true;
                cblFarmacia.Items[2].Selected = true;
                cblFarmacia.Items[3].Selected = true;
            }
            else if (cbFarmacia.Checked == false)
            {
                cblFarmacia.Items[0].Selected = false;
                cblFarmacia.Items[1].Selected = false;
                cblFarmacia.Items[2].Selected = false;
                cblFarmacia.Items[3].Selected = false;
            }
        }

        protected void cbGraphicDesign_CheckedChanged(object sender, EventArgs e)
        {
            if (cbGraphicDesign.Checked == true)
            {
                cblGraphicDesign.Items[0].Selected = true;
                cblGraphicDesign.Items[1].Selected = true;
                cblGraphicDesign.Items[2].Selected = true;
                cblGraphicDesign.Items[3].Selected = true;
                cblGraphicDesign.Items[4].Selected = true;
                cblGraphicDesign.Items[5].Selected = true;
            }
            else if (cbGraphicDesign.Checked == false)
            {
                cblGraphicDesign.Items[0].Selected = false;
                cblGraphicDesign.Items[1].Selected = false;
                cblGraphicDesign.Items[2].Selected = false;
                cblGraphicDesign.Items[3].Selected = false;
                cblGraphicDesign.Items[4].Selected = false;
                cblGraphicDesign.Items[5].Selected = false;
            }
        }

        protected void btnGeneraPreventivo_Click(object sender, EventArgs e)
        {
            tmpPreventivo = 0;
            tmpMensile = 0;
            List<string> listaProdotti = new List<string>();

            if (cbBasic.Checked == true)
            {
                tmpPreventivo = tmpPreventivo + 1790;
                listaProdotti.Add(cbBasic.Text + " - 1790€");
            }

            if (cblPlus.Items[0].Selected == true)
            {
                tmpPreventivo = tmpPreventivo + 700;
                listaProdotti.Add(cblPlus.Items[0].Text + " - 700€");
            }
            if (cblPlus.Items[1].Selected == true)
            {
                tmpPreventivo = tmpPreventivo + 600;
                listaProdotti.Add(cblPlus.Items[1].Text + " - 600€");
            }
            if (cblPlus.Items[2].Selected == true)
            {
                tmpPreventivo = tmpPreventivo + 250;
                listaProdotti.Add(cblPlus.Items[2].Text + " - 250€");
            }
            if (cblPlus.Items[3].Selected == true)
            {
                tmpPreventivo = tmpPreventivo + 200;
                listaProdotti.Add(cblPlus.Items[3].Text + " - 200€");
            }
            if (cblPlus.Items[4].Selected == true)
            {
                tmpPreventivo = tmpPreventivo + 230;
                listaProdotti.Add(cblPlus.Items[4].Text + " - 230€");
            }
            if (cblPlus.Items[5].Selected == true)
            {
                tmpPreventivo = tmpPreventivo + 250;
                listaProdotti.Add(cblPlus.Items[5].Text + " - 250€");
            }
            if (cblPlus.Items[6].Selected == true)
            {
                tmpPreventivo = tmpPreventivo + 2000;
                listaProdotti.Add(cblPlus.Items[6].Text + " - 2000€");
            }
            if (cblPlus.Items[7].Selected == true)
            {
                tmpPreventivo = tmpPreventivo + 2000;
                listaProdotti.Add(cblPlus.Items[7].Text + " - 2000€");
            }


            if (cblPlus.Items[0].Selected == false && (cblRistorazione.Items[0].Selected == true || cblRistorazione.Items[1].Selected == true))
            {
                tmpPreventivo = tmpPreventivo + 700;
                listaProdotti.Add(cblRistorazione.Items[0].Text + "/" + cblRistorazione.Items[1].Text + " - 700€");
            }
            if (cblRistorazione.Items[2].Selected == true)
            {
                tmpPreventivo = tmpPreventivo + 150;
                listaProdotti.Add(cblRistorazione.Items[2].Text + " - 150€");
            }
            if (cblRistorazione.Items[3].Selected == true)
            {
                tmpPreventivo = tmpPreventivo + 150;
                listaProdotti.Add(cblRistorazione.Items[3].Text + " - 150€");
            }


            if (cblPlus.Items[0].Selected == false && (cblHotel.Items[0].Selected == true || cblHotel.Items[2].Selected == true))
            {
                tmpPreventivo = tmpPreventivo + 700;
                listaProdotti.Add(cblHotel.Items[0].Text + "/" + cblHotel.Items[2].Text + " - 700€");
            }
            if (cblHotel.Items[1].Selected == true)
            {
                tmpPreventivo = tmpPreventivo + 250;
                listaProdotti.Add(cblHotel.Items[1].Text + " - 250€");
            }


            if (cblPlus.Items[0].Selected == false && (cblCampeggi.Items[0].Selected == true || cblCampeggi.Items[1].Selected == true || cblCampeggi.Items[2].Selected == true))
            {
                tmpPreventivo = tmpPreventivo + 700;
                listaProdotti.Add(cblCampeggi.Items[0].Text + "/" + cblCampeggi.Items[1].Text + "/" + cblCampeggi.Items[2].Text + " - 700€");
            }


            if (cblImmobiliare.Items[0].Selected == true)
            {
                tmpPreventivo = tmpPreventivo + 500;
                listaProdotti.Add(cblImmobiliare.Items[0].Text + " - 500€");
            }
            if (cblImmobiliare.Items[1].Selected == true)
            {
                tmpPreventivo = tmpPreventivo + 400;
                listaProdotti.Add(cblImmobiliare.Items[1].Text + " - 400€");
            }
            if (cblImmobiliare.Items[2].Selected == true)
            {
                tmpPreventivo = tmpPreventivo + 300;
                listaProdotti.Add(cblImmobiliare.Items[2].Text + " - 300€");
            }


            if (cblParrucchieri.Items[0].Selected == true)
            {
                tmpPreventivo = tmpPreventivo + 250;
                listaProdotti.Add(cblParrucchieri.Items[0].Text + " - 250€");
            }
            if (cblParrucchieri.Items[1].Selected == true)
            {
                tmpPreventivo = tmpPreventivo + 100;
                listaProdotti.Add(cblParrucchieri.Items[1].Text + " - 100€");
            }
            if (cblParrucchieri.Items[2].Selected == true)
            {
                tmpPreventivo = tmpPreventivo + 200;
                listaProdotti.Add(cblParrucchieri.Items[2].Text + " - 200€");
            }
            if (cblParrucchieri.Items[3].Selected == true)
            {
                tmpPreventivo = tmpPreventivo + 150;
                listaProdotti.Add(cblParrucchieri.Items[3].Text + " - 150€");
            }
            if (cblPlus.Items[0].Selected == false && cblParrucchieri.Items[4].Selected == true)
            {
                tmpPreventivo = tmpPreventivo + 700;
                listaProdotti.Add(cblParrucchieri.Items[4].Text + " - 700€");
            }


            if (cblBenessere.Items[0].Selected == true)
            {
                tmpPreventivo = tmpPreventivo + 250;
                listaProdotti.Add(cblBenessere.Items[0].Text + " - 250€");
            }
            if (cblBenessere.Items[1].Selected == true)
            {
                tmpPreventivo = tmpPreventivo + 100;
                listaProdotti.Add(cblBenessere.Items[1].Text + " - 100€");
            }
            if (cblBenessere.Items[2].Selected == true)
            {
                tmpPreventivo = tmpPreventivo + 200;
                listaProdotti.Add(cblBenessere.Items[2].Text + " - 200€");
            }
            if (cblBenessere.Items[3].Selected == true)
            {
                tmpPreventivo = tmpPreventivo + 150;
                listaProdotti.Add(cblBenessere.Items[3].Text + " - 150€");
            }
            if (cblPlus.Items[0].Selected == false && cblBenessere.Items[4].Selected == true)
            {
                tmpPreventivo = tmpPreventivo + 700;
                listaProdotti.Add(cblBenessere.Items[4].Text + " - 700€");
            }


            if (cblFitness.Items[0].Selected == true)
            {
                tmpPreventivo = tmpPreventivo + 400;
                listaProdotti.Add(cblFitness.Items[0].Text + " - 400€");
            }
            if (cblFitness.Items[1].Selected == true)
            {
                tmpPreventivo = tmpPreventivo + 150;
                listaProdotti.Add(cblFitness.Items[1].Text + " - 150€");
            }
            if (cblFitness.Items[2].Selected == true)
            {
                tmpPreventivo = tmpPreventivo + 200;
                listaProdotti.Add(cblFitness.Items[2].Text + " - 200€");
            }
            if (cblPlus.Items[0].Selected == false && (cblFitness.Items[3].Selected == true || cblFitness.Items[4].Selected == true))
            {
                tmpPreventivo = tmpPreventivo + 700;
                listaProdotti.Add(cblFitness.Items[3].Text + "/" + cblFitness.Items[4].Text + " - 700€");
            }


            if (cblConcessionari.Items[0].Selected == true)
            {
                tmpPreventivo = tmpPreventivo + 500;
                listaProdotti.Add(cblFitness.Items[0].Text + " - 500€");
            }
            if (cblConcessionari.Items[1].Selected == true)
            {
                tmpPreventivo = tmpPreventivo + 400;
                listaProdotti.Add(cblFitness.Items[1].Text + " - 400€");
            }
            if (cblConcessionari.Items[2].Selected == true)
            {
                tmpPreventivo = tmpPreventivo + 300;
                listaProdotti.Add(cblFitness.Items[2].Text + " - 300€");
            }


            if (cblCentriCommerciali.Items[0].Selected == true)
            {
                tmpPreventivo = tmpPreventivo + 1500;
                listaProdotti.Add(cblCentriCommerciali.Items[0].Text + " - 1500€");
            }
            if (cblCentriCommerciali.Items[1].Selected == true)
            {
                tmpPreventivo = tmpPreventivo + 100;
                listaProdotti.Add(cblCentriCommerciali.Items[1].Text + " - 100€");
            }
            if (cblCentriCommerciali.Items[2].Selected == true)
            {
                tmpPreventivo = tmpPreventivo + 150;
                listaProdotti.Add(cblCentriCommerciali.Items[2].Text + " - 150€");
            }
            if (cblCentriCommerciali.Items[3].Selected == true)
            {
                tmpPreventivo = tmpPreventivo + 100;
                listaProdotti.Add(cblCentriCommerciali.Items[3].Text + " - 100€");
            }


            if (cblMedico.Items[0].Selected == true)
            {
                tmpPreventivo = tmpPreventivo + 250;
                listaProdotti.Add(cblMedico.Items[0].Text + " - 250€");
            }
            if (cblMedico.Items[1].Selected == true)
            {
                tmpPreventivo = tmpPreventivo + 200;
                listaProdotti.Add(cblMedico.Items[1].Text + " - 200€");
            }
            if (cblPlus.Items[0].Selected == false && cblFitness.Items[2].Selected == true)
            {
                tmpPreventivo = tmpPreventivo + 700;
                listaProdotti.Add(cblMedico.Items[2].Text + " - 700€");
            }


            if (cblFarmacia.Items[0].Selected == true)
            {
                tmpPreventivo = tmpPreventivo + 250;
                listaProdotti.Add(cblFarmacia.Items[0].Text + " - 250€");
            }
            if (cblFarmacia.Items[1].Selected == true)
            {
                tmpPreventivo = tmpPreventivo + 100;
                listaProdotti.Add(cblFarmacia.Items[1].Text + " - 100€");
            }
            if (cblFarmacia.Items[2].Selected == true)
            {
                tmpPreventivo = tmpPreventivo + 200;
                listaProdotti.Add(cblFarmacia.Items[2].Text + " - 200€");
            }
            if (cblFarmacia.Items[3].Selected == true)
            {
                tmpPreventivo = tmpPreventivo + 300;
                listaProdotti.Add(cblFarmacia.Items[3].Text + " - 300€");
            }


            if (rblSitoWeb.Items[0].Selected == true)
            {
                tmpPreventivo = tmpPreventivo + 600;
                listaProdotti.Add(rblSitoWeb.Items[0].Text + " - 600€");
            }
            if (rblSitoWeb.Items[1].Selected == true)
            {
                tmpPreventivo = tmpPreventivo + 900;
                listaProdotti.Add(rblSitoWeb.Items[1].Text + " - 900€");
            }


            if (rblEcommerce.Items[0].Selected == true)
            {
                tmpPreventivo = tmpPreventivo + 2500;
                listaProdotti.Add(rblEcommerce.Items[0].Text + " - 2500€");
            }
            if (rblEcommerce.Items[1].Selected == true)
            {
                tmpPreventivo = tmpPreventivo + 3500;
                listaProdotti.Add(rblEcommerce.Items[1].Text + " - 3500€");
            }
            if (rblEcommerce.Items[2].Selected == true)
            {
                tmpPreventivo = tmpPreventivo + 5000;
                listaProdotti.Add(rblEcommerce.Items[2].Text + " - 5000€");
            }


            if (cblGraphicDesign.Items[0].Selected == true)
            {
                tmpPreventivo = tmpPreventivo + 1500;
                listaProdotti.Add(cblGraphicDesign.Items[0].Text + " - 1500€");
            }
            if (cblGraphicDesign.Items[1].Selected == true)
            {
                tmpPreventivo = tmpPreventivo + 2500;
                listaProdotti.Add(cblGraphicDesign.Items[1].Text + " - 2500€");
            }
            if (cblGraphicDesign.Items[2].Selected == true)
            {
                tmpPreventivo = tmpPreventivo + 1200;
                listaProdotti.Add(cblGraphicDesign.Items[2].Text + " - 1200€");
            }
            if (cblGraphicDesign.Items[3].Selected == true)
            {
                tmpPreventivo = tmpPreventivo + 1500;
                listaProdotti.Add(cblGraphicDesign.Items[3].Text + " - 1500€");
            }
            if (cblGraphicDesign.Items[4].Selected == true)
            {
                tmpPreventivo = tmpPreventivo + 1500;
                listaProdotti.Add(cblGraphicDesign.Items[4].Text + " - 1500€");
            }
            if (cblGraphicDesign.Items[5].Selected == true)
            {
                tmpPreventivo = tmpPreventivo + 2500;
                listaProdotti.Add(cblGraphicDesign.Items[5].Text + " - 2500€");
            }


            if (rblPESitoWebTime.Items[0].Selected == true)
            {
                tmpMensile = tmpMensile + 1600;
                listaProdotti.Add(rblPESitoWebTime.Items[0].Text + " - 1600€/Mese");
            }
            if (rblPESitoWebTime.Items[1].Selected == true)
            {
                tmpMensile = tmpMensile + 960;
                listaProdotti.Add(rblPESitoWebTime.Items[1].Text + " - 960€/Mese");
            }
            if (rblPESitoWebTime.Items[2].Selected == true)
            {
                tmpMensile = tmpMensile + 320;
                listaProdotti.Add(rblPESitoWebTime.Items[2].Text + " - 320€/Mese");
            }
            if (rblPESitoWebTime.Items[3].Selected == true)
            {
                tmpMensile = tmpMensile + 160;
                listaProdotti.Add(rblPESitoWebTime.Items[3].Text + " - 160€/Mese");
            }
            if (rblPESitoWebTime.Items[4].Selected == true)
            {
                tmpMensile = tmpMensile + 80;
                listaProdotti.Add(rblPESitoWebTime.Items[4].Text + " - 80€/Mese");
            }

            if (rblPESitoWebContent.Items[0].Selected == true)
            {
                tmpMensile = tmpMensile + 320;
                listaProdotti.Add(rblPESitoWebContent.Items[0].Text + " - 320€/Mese");
            }
            if (rblPESitoWebContent.Items[1].Selected == true)
            {
                tmpMensile = tmpMensile + 640;
                listaProdotti.Add(rblPESitoWebContent.Items[1].Text + " - 640€/Mese");
            }
            if (rblPESitoWebContent.Items[2].Selected == true)
            {
                tmpMensile = tmpMensile + 1280;
                listaProdotti.Add(rblPESitoWebContent.Items[2].Text + " - 1280€/Mese");
            }
            if (rblPESitoWebContent.Items[3].Selected == true)
            {
                tmpMensile = tmpMensile + 2560;
                listaProdotti.Add(rblPESitoWebContent.Items[3].Text + " - 2560€/Mese");
            }
            if (rblPESitoWebContent.Items[4].Selected == true)
            {
                tmpMensile = tmpMensile + 4000;
                listaProdotti.Add(rblPESitoWebContent.Items[4].Text + " - 4000€/Mese");
            }


            if (rblPESocialTime.Items[0].Selected == true)
            {
                tmpMensile = tmpMensile + 1600;
                listaProdotti.Add(rblPESocialTime.Items[0].Text + " - 1600€/Mese");
            }
            if (rblPESocialTime.Items[1].Selected == true)
            {
                tmpMensile = tmpMensile + 960;
                listaProdotti.Add(rblPESocialTime.Items[1].Text + " - 960€/Mese");
            }
            if (rblPESocialTime.Items[2].Selected == true)
            {
                tmpMensile = tmpMensile + 320;
                listaProdotti.Add(rblPESocialTime.Items[2].Text + " - 320€/Mese");
            }
            if (rblPESocialTime.Items[3].Selected == true)
            {
                tmpMensile = tmpMensile + 160;
                listaProdotti.Add(rblPESocialTime.Items[3].Text + " - 160€/Mese");
            }
            if (rblPESocialTime.Items[4].Selected == true)
            {
                tmpMensile = tmpMensile + 80;
                listaProdotti.Add(rblPESocialTime.Items[4].Text + " - 80€/Mese");
            }

            if (rblPESocialContent.Items[0].Selected == true)
            {
                tmpMensile = tmpMensile + 320;
                listaProdotti.Add(rblPESocialContent.Items[0].Text + " - 320€/Mese");
            }
            if (rblPESocialContent.Items[1].Selected == true)
            {
                tmpMensile = tmpMensile + 640;
                listaProdotti.Add(rblPESocialContent.Items[1].Text + " - 640€/Mese");
            }
            if (rblPESocialContent.Items[2].Selected == true)
            {
                tmpMensile = tmpMensile + 1280;
                listaProdotti.Add(rblPESocialContent.Items[2].Text + " - 1280€/Mese");
            }
            if (rblPESocialContent.Items[3].Selected == true)
            {
                tmpMensile = tmpMensile + 2560;
                listaProdotti.Add(rblPESocialContent.Items[3].Text + " - 2560€/Mese");
            }
            if (rblPESocialContent.Items[4].Selected == true)
            {
                tmpMensile = tmpMensile + 4000;
                listaProdotti.Add(rblPESocialContent.Items[4].Text + " - 4000€/Mese");
            }

            if (rblSitoWeb.Items[0].Selected == true)
            {
                rblTuttoInUno.Items[0].Selected = false;
            }
            if (rblTuttoInUno.Items[0].Selected == true || rblTuttoInUno.Items[1].Selected == true || rblTuttoInUno.Items[2].Selected == true || rblTuttoInUno.Items[3].Selected == true || rblTuttoInUno.Items[4].Selected == true || rblTuttoInUno.Items[5].Selected == true)
            {
                tmpPreventivo = tmpPreventivo - tmpPreventivo * (25 / 100);
                tmpMensile = tmpMensile - tmpMensile * (25 / 100);
            }

            pnlVisualizzazione.Visible = true;
            lblPreventivo.Visible = true;
            lblPreventivo.Text = "Preventivo: " + tmpPreventivo + "€";

            if (rblPESocialContent.Items[0].Selected == true || rblPESocialContent.Items[1].Selected == true || rblPESocialContent.Items[2].Selected == true || rblPESocialContent.Items[3].Selected == true || rblPESocialContent.Items[4].Selected == true || rblPESocialTime.Items[0].Selected == true || rblPESocialTime.Items[1].Selected == true || rblPESocialTime.Items[2].Selected == true || rblPESocialTime.Items[3].Selected == true || rblPESocialTime.Items[4].Selected == true || rblPESitoWebContent.Items[0].Selected == true || rblPESitoWebContent.Items[1].Selected == true || rblPESitoWebContent.Items[2].Selected == true || rblPESitoWebContent.Items[3].Selected == true || rblPESitoWebContent.Items[4].Selected == true || rblPESitoWebTime.Items[0].Selected == true || rblPESitoWebTime.Items[1].Selected == true || rblPESitoWebTime.Items[2].Selected == true || rblPESitoWebTime.Items[3].Selected == true || rblPESitoWebTime.Items[4].Selected == true)
            {
                lblPreventivo.Text = lblPreventivo.Text + " + Piano Editoriale: " + tmpMensile + "€/Mese";
            }

            if (rblTuttoInUno.Items[0].Selected == true || rblTuttoInUno.Items[1].Selected == true || rblTuttoInUno.Items[2].Selected == true || rblTuttoInUno.Items[3].Selected == true || rblTuttoInUno.Items[4].Selected == true || rblTuttoInUno.Items[5].Selected == true)
            {
                lblSconto.Text = lblSconto.Text + " (Sconto del 25% incluso)";
            }

            GridView1.DataSource = listaProdotti;
            GridView1.DataBind();
            GridView1.HeaderRow.Cells[0].Text = "Prodotti Selezionati";

            lblVediNote.Text = "NOTE: " + txtNote.Text;

            if (txtNote.Text == "")
            {
                lblVediNote.Visible = false;
            }

            GridView1.Visible = true;
            pnlScelta.Visible = false;
            pnlExtra.Visible = false;
            pnlApp.Visible = false;
            pnlTuttoInUno.Visible = false;
            btnTuttoInUno.Visible = false;
            btnGeneraPreventivo.Visible = false;

            pnlNote.Visible = false;


        }

        protected void btnTuttoInUno_Click(object sender, EventArgs e)
        {            
            pnlTuttoInUno.Visible = true;
            btnTuttoInUno.Text = "RICARICA PACCHETTI TUTTO IN UNO";

            if (rblSitoWeb.Items[0].Selected == true)
            {
                rblTuttoInUno.Items[0].Selected = false;
            }
            if (cbBasic.Checked == true)
            {
                if (rblSitoWeb.Items[1].Selected == true && (rblPESitoWebContent.Items[0].Selected == true || rblPESitoWebContent.Items[1].Selected == true || rblPESitoWebContent.Items[2].Selected == true || rblPESitoWebContent.Items[3].Selected == true || rblPESitoWebContent.Items[4].Selected == true || rblPESitoWebTime.Items[0].Selected == true || rblPESitoWebTime.Items[1].Selected == true || rblPESitoWebTime.Items[2].Selected == true || rblPESitoWebTime.Items[3].Selected == true || rblPESitoWebTime.Items[4].Selected == true))
                {
                    rblTuttoInUno.Items[0].Enabled = true;
                    rblTuttoInUno.Items[0].Attributes.CssStyle.Add("visibility", "visible");
                    if (rblPESocialContent.Items[0].Selected == true || rblPESocialContent.Items[1].Selected == true || rblPESocialContent.Items[2].Selected == true || rblPESocialContent.Items[3].Selected == true || rblPESocialContent.Items[4].Selected == true || rblPESocialTime.Items[0].Selected == true || rblPESocialTime.Items[1].Selected == true || rblPESocialTime.Items[2].Selected == true || rblPESocialTime.Items[3].Selected == true || rblPESocialTime.Items[4].Selected == true)
                    {
                        rblTuttoInUno.Items[1].Enabled = true;
                        rblTuttoInUno.Items[1].Attributes.CssStyle.Add("visibility", "visible");

                        if (rblEcommerce.Items[0].Selected == true || rblEcommerce.Items[1].Selected == true || rblEcommerce.Items[2].Selected == true)
                        {
                            rblTuttoInUno.Items[3].Enabled = true;
                            rblTuttoInUno.Items[3].Attributes.CssStyle.Add("visibility", "visible");
                        }

                        if (cblGraphicDesign.Items[0].Selected == true || cblGraphicDesign.Items[1].Selected == true || cblGraphicDesign.Items[2].Selected == true || cblGraphicDesign.Items[3].Selected == true || cblGraphicDesign.Items[4].Selected == true || cblGraphicDesign.Items[5].Selected == true )
                        {
                            rblTuttoInUno.Items[4].Enabled = true;
                            rblTuttoInUno.Items[4].Attributes.CssStyle.Add("visibility", "visible");


                            if (rblEcommerce.Items[0].Selected == true || rblEcommerce.Items[1].Selected == true || rblEcommerce.Items[2].Selected == true)
                            {
                                rblTuttoInUno.Items[5].Enabled = true;
                                rblTuttoInUno.Items[5].Attributes.CssStyle.Add("visibility", "visible");

                            }
                        }
                    }

                    if (rblEcommerce.Items[0].Selected == true || rblEcommerce.Items[1].Selected == true || rblEcommerce.Items[2].Selected == true)
                    {
                        rblTuttoInUno.Items[2].Enabled = true;
                        rblTuttoInUno.Items[2].Attributes.CssStyle.Add("visibility", "visible");

                    }
                }

            }
        }

        protected void btnSceltaApp_Click(object sender, EventArgs e)
        {
            CosaMostrare = 1;
            pnlScelta.Visible = false;
            pnlApp.Visible = true;
            btnGeneraPreventivo.Visible = true;
            pnlNote.Visible = true;
        }

        protected void btnSceltaExtra_Click(object sender, EventArgs e)
        {
            CosaMostrare = 2;
            pnlScelta.Visible = false;
            pnlExtra.Visible = true;
            cbBasic.Checked = false;
            btnGeneraPreventivo.Visible = true;
            pnlNote.Visible = true;
        }

        protected void btnSceltaEntrambi_Click(object sender, EventArgs e)
        {
            CosaMostrare = 3;
            pnlScelta.Visible = false;
            pnlApp.Visible = true;
            pnlExtra.Visible = true;
            btnTuttoInUno.Visible = true;
            btnGeneraPreventivo.Visible = true;
            pnlNote.Visible = true;
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            CosaMostrare = 0;
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
    }
}