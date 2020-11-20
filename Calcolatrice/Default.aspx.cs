using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Timers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Calcolatrice
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnMostraMemoria.Enabled = false; //gestione interfaccia
                btnCancellaMemoria.Enabled = false; //gestione interfaccia
                el1 = double.NaN;
                el2 = double.NaN;
                el2Back = double.NaN;
                op = null;
                opBack = null;
                risultato = double.NaN;
                Session["el1"] = el1;
                Session["el2"] = el2;
                Session["el2Back"] = el2Back;
                Session["op"] = op;
                Session["opBack"] = opBack;
                Session["risultato"] = risultato;
                Session["mem"] = null;
                Session["c"] = c;
            }
        }

        string op;
        string opBack;
        double el1;
        double el2;
        double el2Back;
        double risultato;
        double mem;
        int c = 0;

        /// <summary>
        /// metodo per il calcolo
        /// </summary>
        /// <param name="operatoreMetodo">operatore utilizzato</param>
        /// <param name="perc">se si tratta del calcolo percentuale</param>
        protected void CalcoliPulsanti(string operatoreMetodo, bool perc)
        {
            //Manca la gestione nel caso l'utente facesse per esempio 5 + / * 7

            Session["c"] = (int)Session["c"] + 1;
            bool div0 = false;

            if (double.IsNaN((double)Session["el1"]))
            {
                el1 = double.Parse(txtEl.Text);
                Session["el1"] = el1;
            }
            else if ((int)Session["c"] > 1)
            {
                Session["el2"] = double.Parse(txtEl.Text);
                switch ((string)Session["op"])
                {
                    case "+":
                        Session["risultato"] = (double)Session["el1"] + (double)Session["el2"];
                        break;
                    case "-":
                        Session["risultato"] = (double)Session["el1"] - (double)Session["el2"];
                        break;
                    case "*":
                        Session["risultato"] = (double)Session["el1"] * (double)Session["el2"];
                        break;
                    case "/":
                        if ((double)Session["el2"] == 0)
                            div0 = true;
                        else
                            Session["risultato"] = (double)Session["el1"] / (double)Session["el2"];
                        break;
                }
                el1 = (double)Session["risultato"];
                el2 = double.NaN;
                Session["el1"] = el1;
                Session["el2"] = el2;
                if (div0)
                    txtEl.Text = "ERRORE DIVISIONE PER 0";
                else
                {
                    lblRisultato.Text = Session["risultato"].ToString();
                }
            }
            if (perc)
            {
                btnMeno.BackColor = default; //gestione interfaccia
                btnPer.BackColor = default; //gestione interfaccia
                btnDiviso.BackColor = default; //gestione interfaccia
                btnPiu.BackColor = default; //gestione interfaccia
                txtEl.Text = Session["risultato"].ToString();
            }
            else
                txtEl.Text = "";
            op = operatoreMetodo;
            Session["op"] = op;
        }

        protected void btn0_Click(object sender, EventArgs e)
        {
            txtEl.Text += '0'; //scrive numero nella textbox
        }

        protected void btn1_Click(object sender, EventArgs e)
        {
            txtEl.Text += '1'; //scrive numero nella textbox
        }

        protected void btn2_Click(object sender, EventArgs e)
        {
            txtEl.Text += '2'; //scrive numero nella textbox
        }

        protected void btn3_Click(object sender, EventArgs e)
        {
            txtEl.Text += '3'; //scrive numero nella textbox
        }

        protected void btn4_Click(object sender, EventArgs e)
        {
            txtEl.Text += '4'; //scrive numero nella textbox
        }

        protected void btn5_Click(object sender, EventArgs e)
        {
            txtEl.Text += '5'; //scrive numero nella textbox
        }

        protected void btn6_Click(object sender, EventArgs e)
        {
            txtEl.Text += '6'; //scrive numero nella textbox
        }

        protected void btn7_Click(object sender, EventArgs e)
        {
            txtEl.Text += '7'; //scrive numero nella textbox
        }

        protected void btn8_Click(object sender, EventArgs e)
        {
            txtEl.Text += '8'; //scrive numero nella textbox
        }

        protected void btn9_Click(object sender, EventArgs e)
        {
            txtEl.Text += '9'; //scrive numero nella textbox
        }

        protected void btnVirgola_Click(object sender, EventArgs e)
        {
            txtEl.Text += ','; //scrive virgola nella textbox
        }

        protected void btnPiu_Click(object sender, EventArgs e)
        {
            if (txtEl.Text != "")
            {
                btnMeno.BackColor = default; //gestione interfaccia
                btnPer.BackColor = default; //gestione interfaccia
                btnDiviso.BackColor = default; //gestione interfaccia
                btnPiu.BackColor = Color.Red; //gestione interfaccia

                CalcoliPulsanti("+", false);
            }
        }

        protected void btnMeno_Click(object sender, EventArgs e)
        {
            if (txtEl.Text != "")
            {
                btnPiu.BackColor = default; //gestione interfaccia
                btnPer.BackColor = default; //gestione interfaccia
                btnDiviso.BackColor = default; //gestione interfaccia
                btnMeno.BackColor = Color.Red; //gestione interfaccia

                CalcoliPulsanti("-", false);
            }
        }

        protected void btnPer_Click(object sender, EventArgs e)
        {
            if (txtEl.Text != "")
            {
                btnMeno.BackColor = default; //gestione interfaccia
                btnPiu.BackColor = default; //gestione interfaccia
                btnDiviso.BackColor = default; //gestione interfaccia
                btnPer.BackColor = Color.Red; //gestione interfaccia

                CalcoliPulsanti("*", false);
            }
        }

        protected void btnDiviso_Click(object sender, EventArgs e)
        {
            if (txtEl.Text != "")
            {
                btnMeno.BackColor = default; //gestione interfaccia
                btnPer.BackColor = default; //gestione interfaccia
                btnPiu.BackColor = default; //gestione interfaccia
                btnDiviso.BackColor = Color.Red; //gestione interfaccia

                CalcoliPulsanti("/", false);
            }
        }

        protected void btnUguale_Click(object sender, EventArgs e)
        {
            if (txtEl.Text != "")
            {
                if (Session["op"] != null)
                {
                    c = 0;
                    Session["c"] = c;
                    btnMeno.BackColor = default; //gestione interfaccia
                    btnPer.BackColor = default; //gestione interfaccia
                    btnDiviso.BackColor = default; //gestione interfaccia
                    btnPiu.BackColor = default; //gestione interfaccia
                    bool div0 = false;
                    el2 = double.Parse(txtEl.Text);
                    el2Back = el2;
                    Session["el2"] = el2;
                    Session["el2Back"] = el2Back;
                    switch ((string)Session["op"])
                    {
                        case "+":
                            Session["risultato"] = (double)Session["el1"] + el2;
                            break;
                        case "-":
                            Session["risultato"] = (double)Session["el1"] - el2;
                            break;
                        case "*":
                            Session["risultato"] = (double)Session["el1"] * el2;
                            break;
                        case "/":
                            if (el2 == 0)
                                div0 = true;
                            else
                                Session["risultato"] = (double)Session["el1"] / el2;
                            break;
                    }
                    if (div0)
                    {
                        el1 = double.NaN;
                        el2 = double.NaN;
                        risultato = double.NaN;
                        Session["el1"] = el1;
                        Session["el2"] = el2;
                        Session["risultato"] = risultato;
                        lblRisultato.Text = "ERRORE DIVISIONE PER 0";
                        txtEl.Text = "";
                    }
                    else
                    {
                        el1 = (double)Session["risultato"];
                        el2 = double.NaN;
                        Session["el1"] = el1;
                        Session["el2"] = el2;
                        lblRisultato.Text = Session["risultato"].ToString();
                        txtEl.Text = Session["risultato"].ToString();
                    }
                    div0 = false;
                    Session["opBack"] = Session["op"];
                    op = null;
                    Session["op"] = op;
                }
                else if (Session["op"] == null && Session["opBack"] != null)
                {
                    c = 0;
                    Session["c"] = c;
                    switch (Session["opBack"].ToString())
                    {
                        case "+":
                            Session["risultato"] = double.Parse(txtEl.Text) + (double)Session["el2Back"];
                            break;
                        case "-":
                            Session["risultato"] = double.Parse(txtEl.Text) - (double)Session["el2Back"];
                            break;
                        case "*":
                            Session["risultato"] = double.Parse(txtEl.Text) * (double)Session["el2Back"];
                            break;
                        case "/":
                            Session["risultato"] = double.Parse(txtEl.Text) / (double)Session["el2Back"];
                            break;
                    }
                    el1 = (double)Session["risultato"];
                    el2 = double.NaN;
                    Session["el1"] = el1;
                    Session["el2"] = el2;
                    lblRisultato.Text = Session["risultato"].ToString();
                    txtEl.Text = Session["risultato"].ToString();
                }
            }
            else if (!double.IsNaN((double)Session["el1"]))
            {
                switch ((string)Session["op"])
                {
                    case "+":
                        Session["risultato"] = (double)Session["el1"] + (double)Session["el1"];
                        break;
                    case "-":
                        Session["risultato"] = (double)Session["el1"] - (double)Session["el1"];
                        break;
                    case "*":
                        Session["risultato"] = (double)Session["el1"] * (double)Session["el1"];
                        break;
                    case "/":
                        Session["risultato"] = (double)Session["el1"] / (double)Session["el1"];
                        break;
                }
                el1 = (double)Session["risultato"];
                el2 = double.NaN;
                Session["el1"] = el1;
                Session["el2"] = el2;
                lblRisultato.Text = Session["risultato"].ToString();
                txtEl.Text = Session["risultato"].ToString();
            }
        }

        protected void btnCancella_Click(object sender, EventArgs e)
        {
            txtEl.Text = "";
        }

        protected void btnCancellaTutto_Click(object sender, EventArgs e)
        {
            btnMeno.BackColor = default; //gestione interfaccia
            btnPer.BackColor = default; //gestione interfaccia
            btnDiviso.BackColor = default; //gestione interfaccia
            btnPiu.BackColor = default; //gestione interfaccia
            txtEl.Text = "";
            lblRisultato.Text = "";

            el1 = double.NaN;
            el2 = double.NaN;
            op = null;
            Session["el1"] = el1;
            Session["el2"] = el2;
            Session["el2Back"] = el2;
            Session["op"] = op;
            Session["opBack"] = op;
        }

        protected void btnCambioSegno_Click(object sender, EventArgs e)
        {
            string el = txtEl.Text;
            if (!txtEl.Text.Contains("-"))
                txtEl.Text = "-" + el;
            else
                txtEl.Text = txtEl.Text.Replace("-", "");
        }

        protected void btnFratta_Click(object sender, EventArgs e)
        {
            if (txtEl.Text != "0")
            {
                txtEl.Text = (1 / double.Parse(txtEl.Text)).ToString();
                lblRisultato.Text = txtEl.Text;
            }
            else
            {
                el1 = double.NaN;
                el2 = double.NaN;
                risultato = double.NaN;
                Session["el1"] = el1;
                Session["el2"] = el2;
                Session["risultato"] = risultato;
                lblRisultato.Text = "ERRORE DIVISIONE PER 0";
                txtEl.Text = "";
            }
        }

        protected void btnRadice_Click(object sender, EventArgs e)
        {
            if (txtEl.Text != "")
            {
                if (double.Parse(txtEl.Text) > 0)
                {
                    txtEl.Text = Math.Sqrt(double.Parse(txtEl.Text)).ToString();
                    lblRisultato.Text = txtEl.Text;
                }
                else
                {
                    el1 = double.NaN;
                    el2 = double.NaN;
                    risultato = double.NaN;
                    Session["el1"] = el1;
                    Session["el2"] = el2;
                    Session["risultato"] = risultato;
                    lblRisultato.Text = "ERRORE ARGOMENTO RADICE NEGATIVO";
                    txtEl.Text = "";
                }
            }
        }

        protected void btnPercentuale_Click(object sender, EventArgs e)
        {
            if (txtEl.Text != "")
            {
                if (Session["op"] != null)
                {
                    double perc;
                    if (Session["op"].ToString() != "*" && Session["op"].ToString() != "/")
                    {
                        perc = double.Parse(txtEl.Text);
                        perc = ((double)Session["el1"] / 100) * perc;
                        txtEl.Text = perc.ToString();
                        CalcoliPulsanti(op, true);
                    }
                    else if (Session["op"].ToString() == "*")
                    {
                        perc = double.Parse(txtEl.Text) / 100;
                        txtEl.Text = perc.ToString();
                        Session["el2"] = perc;
                        Session["op"] = "*";
                    }
                    else if (Session["op"].ToString() == "/")
                    {
                        perc = double.Parse(txtEl.Text) / 100;
                        txtEl.Text = perc.ToString();
                        Session["el2"] = perc;
                        Session["op"] = "/";
                    }
                    btnMeno.BackColor = default; //gestione interfaccia
                    btnPer.BackColor = default; //gestione interfaccia
                    btnDiviso.BackColor = default; //gestione interfaccia
                    btnPiu.BackColor = default; //gestione interfaccia
                }
            }
        }

        protected void btnPotenza_Click(object sender, EventArgs e)
        {
            if (txtEl.Text != "")
            {
                txtEl.Text = Math.Pow(double.Parse(txtEl.Text), 2).ToString();
            }
        }

        protected void btnSalvaInMemoria_Click(object sender, EventArgs e)
        {
            if (txtEl.Text != "")
            {
                Session["mem"] = double.Parse(txtEl.Text);
                btnMostraMemoria.Enabled = true; //gestione interfaccia
                btnCancellaMemoria.Enabled = true; //gestione interfaccia
            }
        }

        protected void btnMostraMemoria_Click(object sender, EventArgs e)
        {
            txtEl.Text = Session["mem"].ToString();
        }

        protected void btnCancellaMemoria_Click(object sender, EventArgs e)
        {
            Session["mem"] = null;
            btnMostraMemoria.Enabled = false; //gestione interfaccia
            btnCancellaMemoria.Enabled = false; //gestione interfaccia
        }

        protected void btnAggiungiMemoria_Click(object sender, EventArgs e)
        {
            if (Session["mem"] == null)
            {
                Session["mem"] = 0;
            }
            Session["mem"] = (double)Session["mem"] + double.Parse(txtEl.Text);
        }

        protected void btnSottrazioneMemoria_Click(object sender, EventArgs e)
        {
            if (Session["mem"] == null)
            {
                Session["mem"] = 0;
            }
            Session["mem"] = (double)Session["mem"] - double.Parse(txtEl.Text);
        }

        protected void btnCancCarattere_Click(object sender, EventArgs e)
        {
            string nText = "";
            for(int i = 0; i < txtEl.Text.Length -1; i++)
            {
                nText += txtEl.Text[i];
            }
            txtEl.Text = nText;
        }
    }
}