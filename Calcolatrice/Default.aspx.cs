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
    //Perugini Giammarco

    //PRIMA DI ANALIZZARE IL CODICE E' PRESENTE UN README ALL'INTERNO DELLA STESSA CARTELLA DELLA SOLUZIONE
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
                Session["mem"] = double.NaN;
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
                switch ((string)Session["op"]) //analizzo il contenuto dell'operatore
                {
                    case "+":
                        Session["risultato"] = (double)Session["el1"] + (double)Session["el2"]; //addizione
                        break;
                    case "-":
                        Session["risultato"] = (double)Session["el1"] - (double)Session["el2"]; //sottrazione
                        break;
                    case "*":
                        Session["risultato"] = (double)Session["el1"] * (double)Session["el2"]; //moltiplicazione
                        break;
                    case "/":
                        if ((double)Session["el2"] == 0) //caso divisione per 0
                            div0 = true;
                        else
                            Session["risultato"] = (double)Session["el1"] / (double)Session["el2"]; //divisione
                        break;
                }
                el1 = (double)Session["risultato"];
                el2 = double.NaN;
                Session["el1"] = el1;
                Session["el2"] = el2;
                if (div0)
                    txtEl.Text = "ERRORE DIVISIONE PER 0"; //comunico errore
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
            if (txtEl.Text != "")
            {
                if (!txtEl.Text.Contains(","))
                    txtEl.Text += ','; //scrive virgola nella textbox
            }
            else
                txtEl.Text = "0,";
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
            else if (txtEl.Text == "" && !double.IsNaN((double)Session["el1"]))
            {
                btnMeno.BackColor = default; //gestione interfaccia
                btnPer.BackColor = default; //gestione interfaccia
                btnDiviso.BackColor = default; //gestione interfaccia
                btnPiu.BackColor = Color.Red; //gestione interfaccia

                Session["op"] = "+";
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
            else if (txtEl.Text == "" && !double.IsNaN((double)Session["el1"]))
            {
                btnPiu.BackColor = default; //gestione interfaccia
                btnPer.BackColor = default; //gestione interfaccia
                btnDiviso.BackColor = default; //gestione interfaccia
                btnMeno.BackColor = Color.Red; //gestione interfaccia

                Session["op"] = "-";
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
            else if (txtEl.Text == "" && !double.IsNaN((double)Session["el1"]))
            {
                btnMeno.BackColor = default; //gestione interfaccia
                btnPiu.BackColor = default; //gestione interfaccia
                btnDiviso.BackColor = default; //gestione interfaccia
                btnPer.BackColor = Color.Red; //gestione interfaccia

                Session["op"] = "*";
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
            else if (txtEl.Text == "" && !double.IsNaN((double)Session["el1"]))
            {
                btnMeno.BackColor = default; //gestione interfaccia
                btnPer.BackColor = default; //gestione interfaccia
                btnPiu.BackColor = default; //gestione interfaccia
                btnDiviso.BackColor = Color.Red; //gestione interfaccia

                Session["op"] = "/";
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
                    switch ((string)Session["op"]) //analizzo l'operatore
                    {
                        case "+":
                            Session["risultato"] = (double)Session["el1"] + el2; //addizione
                            break;
                        case "-":
                            Session["risultato"] = (double)Session["el1"] - el2; //sottrazione
                            break;
                        case "*":
                            Session["risultato"] = (double)Session["el1"] * el2; //moltiplicazione
                            break;
                        case "/":
                            if (el2 == 0) //caso divisione per 0
                                div0 = true;
                            else
                                Session["risultato"] = (double)Session["el1"] / el2; //divisione
                            break;
                    }
                    if (div0)
                    {
                        el1 = double.NaN; //reimposto le varibili
                        el2 = double.NaN; //reimposto le varibili
                        risultato = double.NaN; //reimposto le varibili
                        Session["el1"] = el1;
                        Session["el2"] = el2;
                        Session["risultato"] = risultato;
                        lblRisultato.Text = "ERRORE DIVISIONE PER 0"; //comunico errore
                        txtEl.Text = "";
                    }
                    else
                    {
                        el1 = (double)Session["risultato"];
                        el2 = double.NaN; //reimposto le varibili
                        Session["el1"] = el1;
                        Session["el2"] = el2; //reimposto le varibili
                        lblRisultato.Text = Session["risultato"].ToString();
                        txtEl.Text = Session["risultato"].ToString(); //risultato nella textbox
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
                    switch (Session["opBack"].ToString()) //analizzo l'operatore
                    {
                        case "+":
                            Session["risultato"] = double.Parse(txtEl.Text) + (double)Session["el2Back"]; //addizione
                            break;
                        case "-":
                            Session["risultato"] = double.Parse(txtEl.Text) - (double)Session["el2Back"]; //sottrazione
                            break;
                        case "*":
                            Session["risultato"] = double.Parse(txtEl.Text) * (double)Session["el2Back"]; //moltiplicazione
                            break;
                        case "/":
                            Session["risultato"] = double.Parse(txtEl.Text) / (double)Session["el2Back"]; //divisione
                            break;
                    }
                    el1 = (double)Session["risultato"];
                    el2 = double.NaN; //reimposto le varibili
                    Session["el1"] = el1;
                    Session["el2"] = el2; //reimposto le varibili
                    lblRisultato.Text = Session["risultato"].ToString();
                    txtEl.Text = Session["risultato"].ToString(); //risultato nella textbox
                }
            }
            else if (!double.IsNaN((double)Session["el1"]))
            {
                switch ((string)Session["op"]) //analizzo l'operatore
                {
                    case "+":
                        Session["risultato"] = (double)Session["el1"] + (double)Session["el1"]; //addizione
                        break;
                    case "-":
                        Session["risultato"] = (double)Session["el1"] - (double)Session["el1"]; //sottrazione
                        break;
                    case "*":
                        Session["risultato"] = (double)Session["el1"] * (double)Session["el1"]; //moltiplicazione
                        break;
                    case "/":
                        Session["risultato"] = (double)Session["el1"] / (double)Session["el1"]; //divisione
                        break;
                }
                el1 = (double)Session["risultato"];
                el2 = double.NaN; //reimposto le varibili
                Session["el1"] = el1;
                Session["el2"] = el2; //reimposto le varibili
                lblRisultato.Text = Session["risultato"].ToString();
                txtEl.Text = Session["risultato"].ToString(); //risultato nella textbox
            }
        }

        protected void btnCancella_Click(object sender, EventArgs e)
        {
            txtEl.Text = ""; //svuoto la textbox
        }

        protected void btnCancellaTutto_Click(object sender, EventArgs e)
        {
            btnMeno.BackColor = default; //gestione interfaccia
            btnPer.BackColor = default; //gestione interfaccia
            btnDiviso.BackColor = default; //gestione interfaccia
            btnPiu.BackColor = default; //gestione interfaccia
            txtEl.Text = "";
            lblRisultato.Text = "";

            el1 = double.NaN; //reimposto le varibili
            el2 = double.NaN; //reimposto le varibili
            op = null; //reimposto le varibili
            Session["el1"] = el1; //reimposto le varibili
            Session["el2"] = el2; //reimposto le varibili
            Session["el2Back"] = el2; //reimposto le varibili
            Session["op"] = op; //reimposto le varibili
            Session["opBack"] = op; //reimposto le varibili
        }

        protected void btnCambioSegno_Click(object sender, EventArgs e)
        {
            if (txtEl.Text != "")
            {
                string el = txtEl.Text;
                if (!txtEl.Text.Contains("-"))
                    txtEl.Text = "-" + el; //cambio segno
                else
                    txtEl.Text = txtEl.Text.Replace("-", "");
            }
        }

        protected void btnFratta_Click(object sender, EventArgs e)
        {
            if (txtEl.Text != "")
            {
                if (txtEl.Text != "0")
                {
                    txtEl.Text = (1 / double.Parse(txtEl.Text)).ToString(); //frazione
                    lblRisultato.Text = txtEl.Text; //risultato nella textbox
                }
                else
                {
                    el1 = double.NaN; //reimposto le varibili
                    el2 = double.NaN; //reimposto le varibili
                    risultato = double.NaN; //reimposto le varibili
                    Session["el1"] = el1; //reimposto le varibili
                    Session["el2"] = el2; //reimposto le varibili
                    Session["risultato"] = risultato; //reimposto le varibili
                    lblRisultato.Text = "ERRORE DIVISIONE PER 0"; //comunico l'errore
                    txtEl.Text = ""; //svuoto la textbox
                }
            }
        }

        protected void btnRadice_Click(object sender, EventArgs e)
        {
            if (txtEl.Text != "")
            {
                if (double.Parse(txtEl.Text) > 0)
                {
                    txtEl.Text = Math.Sqrt(double.Parse(txtEl.Text)).ToString(); //radice
                    lblRisultato.Text = txtEl.Text; //risultato nella textbox
                }
                else
                {
                    el1 = double.NaN; //reimposto le varibili
                    el2 = double.NaN; //reimposto le varibili
                    risultato = double.NaN; //reimposto le varibili
                    Session["el1"] = el1; //reimposto le varibili
                    Session["el2"] = el2; //reimposto le varibili
                    Session["risultato"] = risultato; //reimposto le varibili
                    lblRisultato.Text = "ERRORE ARGOMENTO RADICE NEGATIVO"; //comunico l'errore
                    txtEl.Text = ""; //svuoto la textbox
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
                        perc = double.Parse(txtEl.Text); //valore per il calcolo della percentuale
                        perc = ((double)Session["el1"] / 100) * perc; //calcolo della percentuale
                        txtEl.Text = perc.ToString(); //risultato nella textbox
                        Session["el2"] = perc;
                        switch(Session["op"].ToString())
                        {
                            case "+":
                                Session["op"] = "+"; //imposto operatore
                                break;
                            case "-":
                                Session["op"] = "-"; //imposto operatore
                                break;
                        }
                    }
                    else if (Session["op"].ToString() == "*")
                    {
                        perc = double.Parse(txtEl.Text) / 100; //calcolo della percentuale
                        txtEl.Text = perc.ToString(); //risultato nella textbox
                        Session["el2"] = perc;
                        Session["op"] = "*";
                    }
                    else if (Session["op"].ToString() == "/")
                    {
                        perc = double.Parse(txtEl.Text) / 100; //calcolo della percentuale
                        txtEl.Text = perc.ToString(); //risultato nella textbox
                        Session["el2"] = perc;
                        Session["op"] = "/";
                    }
                    btnMeno.BackColor = default; //gestione interfaccia
                    btnPer.BackColor = default; //gestione interfaccia
                    btnDiviso.BackColor = default; //gestione interfaccia
                    btnPiu.BackColor = default; //gestione interfaccia
                }
                else
                {
                    double x = double.Parse(txtEl.Text);
                    txtEl.Text = (x / 100).ToString();
                }
            }
        }

        protected void btnPotenza_Click(object sender, EventArgs e)
        {
            if (txtEl.Text != "")
            {
                txtEl.Text = Math.Pow(double.Parse(txtEl.Text), 2).ToString(); //potenza
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
            txtEl.Text = Session["mem"].ToString(); //mostro il valore nella memoria
        }

        protected void btnCancellaMemoria_Click(object sender, EventArgs e)
        {
            Session["mem"] = null;
            btnMostraMemoria.Enabled = false; //gestione interfaccia
            btnCancellaMemoria.Enabled = false; //gestione interfaccia
        }

        protected void btnAggiungiMemoria_Click(object sender, EventArgs e)
        {
            if (txtEl.Text != "")
            {
                if (double.IsNaN((double)Session["mem"]))
                {
                    Session["mem"] = 0.0;
                }
                Session["mem"] = (double)Session["mem"] + double.Parse(txtEl.Text); //addizione
                btnMostraMemoria.Enabled = true; //gestione interfaccia
                btnCancellaMemoria.Enabled = true; //gestione interfaccia
            }
        }

        protected void btnSottrazioneMemoria_Click(object sender, EventArgs e)
        {
            if (txtEl.Text != "")
            {
                if (double.IsNaN((double)Session["mem"]))
                {
                    Session["mem"] = 0.0;
                }
                Session["mem"] = (double)Session["mem"] - double.Parse(txtEl.Text); //sottrazione
                btnMostraMemoria.Enabled = true; //gestione interfaccia
                btnCancellaMemoria.Enabled = true; //gestione interfaccia
            }
        }

        protected void btnCancCarattere_Click(object sender, EventArgs e)
        {
            string nText = "";
            for(int i = 0; i < txtEl.Text.Length -1; i++)
            {
                nText += txtEl.Text[i]; //memorizzo la stringa eliminando l'ultimo carattere
            }
            txtEl.Text = nText; //elemento con il carattere eliminato nella textbox
        }
    }
}