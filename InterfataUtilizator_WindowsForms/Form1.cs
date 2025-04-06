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

        private const int LUNGIME_ELEMENT = 150;
        private const int PAS_X = 20;
        private const int PAS_Y = 20;
        private const int LEFT_MARGIN = 120;

        private int LabelIndex = 0;

        private TextBox txtNume;
        private TextBox txtPrenume;
        private TextBox txtEmail;
        private TextBox txtTelefon;
        private TextBox txtPerioada;
        private TextBox txtIdVehicul;

        private Button btnAdauga;

        private List<Label> lblClient_Nume;
        private List<Label> lblClient_Prenume;
        private List<Label> lblClient_Email;
        private List<Label> lblClient_Telefon;
        private List<Label> lblClient_Perioada;
        private List<Label> lblClient_IDVehicul;

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

            //Nume
            Label lblAddNume = new Label();
            lblAddNume.Width = LUNGIME_ELEMENT;
            lblAddNume.Text = "Nume";
            lblAddNume.TextAlign = ContentAlignment.MiddleCenter;
            lblAddNume.Left = PAS_X;
            lblAddNume.Top = PAS_Y;
            this.Controls.Add(lblAddNume);
            
            txtNume = new TextBox();
            txtNume.Width = LUNGIME_ELEMENT;
            txtNume.Left = PAS_X;
            txtNume.Top = 2*PAS_Y;
            this.Controls.Add(txtNume);
            
            //Prenume
            Label lblAddPrenume = new Label();
            lblAddPrenume.Width = LUNGIME_ELEMENT;
            lblAddPrenume.Text = "Prenume";
            lblAddPrenume.TextAlign = ContentAlignment.MiddleCenter;
            lblAddPrenume.Left = PAS_X;
            lblAddPrenume.Top = 3*PAS_Y;
            this.Controls.Add(lblAddPrenume);

            txtPrenume = new TextBox();
            txtPrenume.Width = LUNGIME_ELEMENT;
            txtPrenume.Left = PAS_X;
            txtPrenume.Top = 4 * PAS_Y;
            this.Controls.Add(txtPrenume);

            //Email
            Label lblAddEmail = new Label();
            lblAddEmail.Width = LUNGIME_ELEMENT;
            lblAddEmail.Text = "Email";
            lblAddEmail.TextAlign = ContentAlignment.MiddleCenter;
            lblAddEmail.Left = PAS_X;
            lblAddEmail.Top = 5 * PAS_Y;
            this.Controls.Add(lblAddEmail);

            txtEmail = new TextBox();
            txtEmail.Width = LUNGIME_ELEMENT;
            txtEmail.Left = PAS_X;
            txtEmail.Top = 6 * PAS_Y;
            this.Controls.Add(txtEmail);

            //Telefon
            Label lblAddTelefon = new Label();
            lblAddTelefon.Width = LUNGIME_ELEMENT;
            lblAddTelefon.Text = "Telefon";
            lblAddTelefon.TextAlign = ContentAlignment.MiddleCenter;
            lblAddTelefon.Left = PAS_X;
            lblAddTelefon.Top = 7 * PAS_Y;
            this.Controls.Add(lblAddTelefon);

            txtTelefon = new TextBox();
            txtTelefon.Width = LUNGIME_ELEMENT;
            txtTelefon.Left = PAS_X;
            txtTelefon.Top = 8 * PAS_Y;
            this.Controls.Add(txtTelefon);

            //Perioada
            Label lblAddPerioada = new Label();
            lblAddPerioada.Width = LUNGIME_ELEMENT;
            lblAddPerioada.Text = "Perioada";
            lblAddPerioada.TextAlign = ContentAlignment.MiddleCenter;
            lblAddPerioada.Left = PAS_X;
            lblAddPerioada.Top = 9 * PAS_Y;
            this.Controls.Add(lblAddPerioada);

            txtPerioada = new TextBox();
            txtPerioada.Width = LUNGIME_ELEMENT;
            txtPerioada.Left = PAS_X;
            txtPerioada.Top = 10 * PAS_Y;
            this.Controls.Add(txtPerioada);

            //Id Vehicul
            Label lblAddIdVehicul = new Label();
            lblAddIdVehicul.Width = LUNGIME_ELEMENT;
            lblAddIdVehicul.Text = "Id Vehicul";
            lblAddIdVehicul.TextAlign = ContentAlignment.MiddleCenter;
            lblAddIdVehicul.Left = PAS_X;
            lblAddIdVehicul.Top = 11 * PAS_Y;
            this.Controls.Add(lblAddIdVehicul);

            txtIdVehicul = new TextBox();
            txtIdVehicul.Width = LUNGIME_ELEMENT;
            txtIdVehicul.Left = PAS_X;
            txtIdVehicul.Top = 12 * PAS_Y;
            this.Controls.Add(txtIdVehicul);


            //Buton
            btnAdauga = new Button();
            btnAdauga.Text = "Adauga";
            btnAdauga.Width = LUNGIME_ELEMENT;
            btnAdauga.Left = PAS_X;
            btnAdauga.Top = 14 * PAS_Y;
            btnAdauga.Click += OnClick;
            this.Controls.Add(btnAdauga);

            //Labels pentru afisarea datelor salvate

            Label lblNume = new Label();
            lblNume.Width = LUNGIME_ELEMENT;
            lblNume.Text = "Nume";
            lblNume.TextAlign = ContentAlignment.MiddleCenter;
            lblNume.Left = LEFT_MARGIN + PAS_X;
            lblNume.Top = PAS_Y;
            this.Controls.Add(lblNume);

            Label lblPrenume = new Label();
            lblPrenume.Width = LUNGIME_ELEMENT;
            lblPrenume.Text = "Prenume";
            lblPrenume.TextAlign = ContentAlignment.MiddleCenter;
            lblPrenume.Left = LEFT_MARGIN + LUNGIME_ELEMENT + PAS_X;
            lblPrenume.Top = PAS_Y;
            this.Controls.Add(lblPrenume);

            Label lblEmail = new Label();
            lblEmail.Width = LUNGIME_ELEMENT;
            lblEmail.Text = "Email";
            lblEmail.TextAlign = ContentAlignment.MiddleCenter;
            lblEmail.Left = LEFT_MARGIN + 2 * LUNGIME_ELEMENT + PAS_X;
            lblEmail.Top = PAS_Y;
            this.Controls.Add(lblEmail);

            Label lblNrTelefon = new Label();
            lblNrTelefon.Width = LUNGIME_ELEMENT;
            lblNrTelefon.Text = "Nr. Telefon";
            lblNrTelefon.TextAlign = ContentAlignment.MiddleCenter;
            lblNrTelefon.Left = LEFT_MARGIN + 3 * LUNGIME_ELEMENT + PAS_X;
            lblNrTelefon.Top = PAS_Y;
            this.Controls.Add(lblNrTelefon);

            Label lblPerioada = new Label();
            lblPerioada.Width = LUNGIME_ELEMENT;
            lblPerioada.Text = "Perioada";
            lblPerioada.TextAlign = ContentAlignment.MiddleCenter;
            lblPerioada.Left = LEFT_MARGIN + 4 * LUNGIME_ELEMENT + PAS_X;
            lblPerioada.Top = PAS_Y;
            this.Controls.Add(lblPerioada);

            Label lblIdVehicul = new Label();
            lblIdVehicul.Width = LUNGIME_ELEMENT;
            lblIdVehicul.Text = "ID Vehicul Inchiriat";
            lblIdVehicul.TextAlign = ContentAlignment.MiddleCenter;
            lblIdVehicul.Left = LEFT_MARGIN + 5 * LUNGIME_ELEMENT + PAS_X;
            lblIdVehicul.Top = PAS_Y;
            this.Controls.Add(lblIdVehicul);

            this.Load += Form1_Load;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
               AfiseazaClienti();
        }
        private void OnClick(object sender, EventArgs e)
        {
            char Sep = ';';
            string Linie = $"{txtNume.Text}{Sep}{txtPrenume.Text}{Sep}{txtEmail.Text}{Sep}" +
                           $"{txtTelefon.Text}{Sep}{txtPerioada.Text}{Sep}{txtIdVehicul.Text}{Sep}";
            Client ClientNou = new Client(Linie);
            AdminClienti.AddClientFisier(ClientNou);

            txtNume.Text = "";
            txtPrenume.Text = "";
            txtEmail.Text = "";
            txtTelefon.Text = "";
            txtPerioada.Text = "";
            txtIdVehicul.Text = "";

            AfiseazaClient(ClientNou, LabelIndex);
            LabelIndex++;
        }
        private void AfiseazaClient(Client Cln, int i)
        {
            lblClient_Nume.Add(new Label());
            lblClient_Nume[i].Width = LUNGIME_ELEMENT;
            lblClient_Nume[i].Text = Cln.Nume;
            lblClient_Nume[i].Left = LEFT_MARGIN + PAS_X;
            lblClient_Nume[i].Top = (i + 2) * PAS_Y;
            lblClient_Nume[i].TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(lblClient_Nume[i]);

            lblClient_Prenume.Add(new Label());
            lblClient_Prenume[i].Width = LUNGIME_ELEMENT;
            lblClient_Prenume[i].Text = Cln.Prenume;
            lblClient_Prenume[i].Left = LEFT_MARGIN + LUNGIME_ELEMENT + PAS_X;
            lblClient_Prenume[i].Top = (i + 2) * PAS_Y;
            lblClient_Prenume[i].TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(lblClient_Prenume[i]);

            lblClient_Email.Add(new Label());
            lblClient_Email[i].Width = LUNGIME_ELEMENT;
            lblClient_Email[i].Text = Cln.Email;
            lblClient_Email[i].Left = LEFT_MARGIN + 2 * LUNGIME_ELEMENT + PAS_X;
            lblClient_Email[i].Top = (i + 2) * PAS_Y;
            lblClient_Email[i].TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(lblClient_Email[i]);

            lblClient_Telefon.Add(new Label());
            lblClient_Telefon[i].Width = LUNGIME_ELEMENT;
            lblClient_Telefon[i].Text = Cln.Nr_Telefon;
            lblClient_Telefon[i].Left = LEFT_MARGIN + 3 * LUNGIME_ELEMENT + PAS_X;
            lblClient_Telefon[i].Top = (i + 2) * PAS_Y;
            lblClient_Telefon[i].TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(lblClient_Telefon[i]);

            lblClient_Perioada.Add(new Label());
            lblClient_Perioada[i].Width = LUNGIME_ELEMENT;
            lblClient_Perioada[i].Text = Cln.Perioada.ToString();
            lblClient_Perioada[i].Left = LEFT_MARGIN + 4 * LUNGIME_ELEMENT + PAS_X;
            lblClient_Perioada[i].Top = (i + 2) * PAS_Y;
            lblClient_Perioada[i].TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(lblClient_Perioada[i]);

            lblClient_IDVehicul.Add(new Label());
            lblClient_IDVehicul[i].Width = LUNGIME_ELEMENT;
            lblClient_IDVehicul[i].Text = Cln.Id_Vehicul.ToString();
            lblClient_IDVehicul[i].Left = LEFT_MARGIN + 5 * LUNGIME_ELEMENT + PAS_X;
            lblClient_IDVehicul[i].Top = (i + 2) * PAS_Y;
            lblClient_IDVehicul[i].TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(lblClient_IDVehicul[i]);
        }
        private void AfiseazaClienti()
        { 
            AdminClienti.GetClientiFisier();
            List<Client> Clienti = AdminClienti.GetClients();
            
            lblClient_Nume = new List<Label>();
            lblClient_Prenume = new List<Label>();
            lblClient_Email = new List<Label>();
            lblClient_Telefon = new List<Label>();
            lblClient_Perioada = new List<Label>();
            lblClient_IDVehicul = new List<Label>();
            
            int i = 0;
            foreach (Client Cln in Clienti)
            {
                if (i < Clienti.Count)
                {
                    AfiseazaClient(Cln, i);
                    i++;
                }
            }
            LabelIndex = i;
        }
    }
}