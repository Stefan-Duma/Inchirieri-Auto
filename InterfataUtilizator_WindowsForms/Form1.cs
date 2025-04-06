using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using ClaseBaza;
using Administrator;
using System.IO;


namespace InchirieriAuto_WindowsForms
{
    public partial class Form1 : Form
    {
        private const int LUNGIME_FORMA = 800;
        private const int LATIME_FORMA = 400;

        private const int LUNGIME_ELEMENT = 125;
        private const int PAS_X = 20;
        private const int PAS_Y = 20;

        private Label[] lblClient_Nume;
        private Label[] lblClient_Prenume;
        private Label[] lblClient_Email;
        private Label[] lblClient_Telefon;
        private Label[] lblClient_Perioada;
        private Label[] lblClient_IDVehicul;

        private AdministratorClienti_FisierText AdminClienti;
        public Form1()
        {
            InitializeComponent();

            this.Size = new Size(LUNGIME_FORMA, LATIME_FORMA);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Clienti";
            this.Font = new Font("Arial", 9, FontStyle.Bold);
            this.BackColor = Color.FromArgb(51, 51, 51); //#333333
            this.ForeColor = Color.Gold;

            string FisierClienti = ConfigurationManager.AppSettings["FisierClienti"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = locatieFisierSolutie + "\\" + FisierClienti;
            AdminClienti = new AdministratorClienti_FisierText(caleCompletaFisier);

            Label lblNume = new Label();
            lblNume.Width = LUNGIME_ELEMENT;
            lblNume.Text = "Nume";
            lblNume.TextAlign = ContentAlignment.MiddleCenter;
            lblNume.Left = PAS_X;
            lblNume.Top = PAS_Y;
            this.Controls.Add(lblNume);

            Label lblPrenume = new Label();
            lblPrenume.Width = LUNGIME_ELEMENT;
            lblPrenume.Text = "Prenume";
            lblPrenume.TextAlign = ContentAlignment.MiddleCenter;
            lblPrenume.Left = LUNGIME_ELEMENT + PAS_X;
            lblPrenume.Top = PAS_Y;
            this.Controls.Add(lblPrenume);

            Label lblEmail = new Label();
            lblEmail.Width = LUNGIME_ELEMENT;
            lblEmail.Text = "Email";
            lblEmail.TextAlign = ContentAlignment.MiddleCenter;
            lblEmail.Left = 2 * LUNGIME_ELEMENT + PAS_X;
            lblEmail.Top = PAS_Y;
            this.Controls.Add(lblEmail);

            Label lblNrTelefon = new Label();
            lblNrTelefon.Width = LUNGIME_ELEMENT;
            lblNrTelefon.Text = "Nr. Telefon";
            lblNrTelefon.TextAlign = ContentAlignment.MiddleCenter;
            lblNrTelefon.Left = 3 * LUNGIME_ELEMENT + PAS_X;
            lblNrTelefon.Top = PAS_Y;
            this.Controls.Add(lblNrTelefon);

            Label lblPerioada = new Label();
            lblPerioada.Width = LUNGIME_ELEMENT;
            lblPerioada.Text = "Perioada";
            lblPerioada.TextAlign = ContentAlignment.MiddleCenter;
            lblPerioada.Left = 4 * LUNGIME_ELEMENT + PAS_X;
            lblPerioada.Top = PAS_Y;
            this.Controls.Add(lblPerioada);

            Label lblIdVehicul = new Label();
            lblIdVehicul.Width = LUNGIME_ELEMENT;
            lblIdVehicul.Text = "ID Vehicul Inchiriat";
            lblIdVehicul.TextAlign = ContentAlignment.MiddleCenter;
            lblIdVehicul.Left = 5 * LUNGIME_ELEMENT + PAS_X;
            lblIdVehicul.Top = PAS_Y;
            this.Controls.Add(lblIdVehicul);

            this.Load += Form1_Load;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
               AfiseazaClienti();
        }
        private void AfiseazaClienti()
        {
            AdminClienti.GetClientiFisier();
            Client[] Clienti = AdminClienti.GetClients();
            int Nr = AdminClienti.GetNrClienti();
            int i = 0;
            lblClient_Nume = new Label[Nr];
            lblClient_Prenume = new Label[Nr];
            lblClient_Email = new Label[Nr];
            lblClient_Telefon = new Label[Nr];
            lblClient_Perioada = new Label[Nr];
            lblClient_IDVehicul = new Label[Nr];

            foreach (Client Cln in Clienti)
            {
                if (i < Nr)
                { 
                    lblClient_Nume[i] = new Label();
                    lblClient_Nume[i].Width = LUNGIME_ELEMENT;
                    lblClient_Nume[i].Text = Cln.Nume;
                    lblClient_Nume[i].Left = PAS_X;
                    lblClient_Nume[i].Top = (i + 2) * PAS_Y;
                    lblClient_Nume[i].TextAlign = ContentAlignment.MiddleCenter;
                    this.Controls.Add(lblClient_Nume[i]);

                    lblClient_Prenume[i] = new Label();
                    lblClient_Prenume[i].Width = LUNGIME_ELEMENT;
                    lblClient_Prenume[i].Text = Cln.Prenume;
                    lblClient_Prenume[i].Left = LUNGIME_ELEMENT + PAS_X;
                    lblClient_Prenume[i].Top = (i + 2) * PAS_Y;
                    lblClient_Prenume[i].TextAlign = ContentAlignment.MiddleCenter;
                    this.Controls.Add(lblClient_Prenume[i]);

                    lblClient_Email[i] = new Label();
                    lblClient_Email[i].Width = LUNGIME_ELEMENT;
                    lblClient_Email[i].Text = Cln.Email;
                    lblClient_Email[i].Left = 2 * LUNGIME_ELEMENT + PAS_X;
                    lblClient_Email[i].Top = (i + 2) * PAS_Y;
                    lblClient_Email[i].TextAlign = ContentAlignment.MiddleCenter;
                    this.Controls.Add(lblClient_Email[i]);

                    lblClient_Telefon[i] = new Label();
                    lblClient_Telefon[i].Width = LUNGIME_ELEMENT;
                    lblClient_Telefon[i].Text = Cln.Nr_Telefon;
                    lblClient_Telefon[i].Left = 3 * LUNGIME_ELEMENT + PAS_X;
                    lblClient_Telefon[i].Top = (i + 2) * PAS_Y;
                    lblClient_Telefon[i].TextAlign = ContentAlignment.MiddleCenter;
                    this.Controls.Add(lblClient_Telefon[i]);

                    lblClient_Perioada[i] = new Label();
                    lblClient_Perioada[i].Width = LUNGIME_ELEMENT;
                    lblClient_Perioada[i].Text = Cln.Perioada.ToString();
                    lblClient_Perioada[i].Left = 4 * LUNGIME_ELEMENT + PAS_X;
                    lblClient_Perioada[i].Top = (i + 2) * PAS_Y;
                    lblClient_Perioada[i].TextAlign = ContentAlignment.MiddleCenter;
                    this.Controls.Add(lblClient_Perioada[i]);

                    lblClient_IDVehicul[i] = new Label();
                    lblClient_IDVehicul[i].Width = LUNGIME_ELEMENT;
                    lblClient_IDVehicul[i].Text = Cln.Id_Vehicul.ToString();
                    lblClient_IDVehicul[i].Left = 5 * LUNGIME_ELEMENT + PAS_X;
                    lblClient_IDVehicul[i].Top = (i + 2) * PAS_Y;
                    lblClient_IDVehicul[i].TextAlign = ContentAlignment.MiddleCenter;
                    this.Controls.Add(lblClient_IDVehicul[i]);
                    i++;
                }
            }
        }
    }
}