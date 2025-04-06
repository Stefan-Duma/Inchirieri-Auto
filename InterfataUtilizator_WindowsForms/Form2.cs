using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Configuration;
using ClaseBaza;
using Administrator;

namespace InchirieriAuto_WindowsForms
{
    public partial class Form2 : Form
    {
        private const int LUNGIME_FORMA = 800;
        private const int LATIME_FORMA = 400;

        private const int LUNGIME_ELEMENT = 125;
        private const int PAS_X = 20;
        private const int PAS_Y = 20;
        private const int LEFT_MARGIN = 120;

        private int LabelIndex = 0;

        private TextBox txtModel;
        private TextBox txtAnAparitie;
        private TextBox txtTaxa;
        private TextBox txtStoc;
        private ComboBox cboCuloare;

        private Button btnAdaugaMasina;

        private List<Label> lblMasina_Model;
        private List<Label> lblMasina_AnAparitie;
        private List<Label> lblMasina_Taxa;
        private List<Label> lblMasina_Stoc;
        private List<Label> lblMasina_Id;
        private List<Label> lblMasina_Culoare;

        private AdministratorMasini_FisierText AdminMasini;

        public Form2()
        {
            InitializeComponent();
            this.Size = new Size(LUNGIME_FORMA, LATIME_FORMA);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Masini";
            this.Font = new Font("Arial", 9, FontStyle.Bold);
            this.BackColor = Color.FromArgb(51, 51, 51);
            this.ForeColor = Color.Gold;

            string FisierMasini = ConfigurationManager.AppSettings["FisierMasini"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = locatieFisierSolutie + "\\" + FisierMasini;
            AdminMasini = new AdministratorMasini_FisierText(caleCompletaFisier);

            //Model
            Label lblAddModel = new Label();
            lblAddModel.Width = LUNGIME_ELEMENT;
            lblAddModel.Text = "Model";
            lblAddModel.TextAlign = ContentAlignment.MiddleCenter;
            lblAddModel.Left = PAS_X;
            lblAddModel.Top = PAS_Y;
            this.Controls.Add(lblAddModel);

            txtModel = new TextBox();
            txtModel.Width = LUNGIME_ELEMENT;
            txtModel.Left = PAS_X;
            txtModel.Top = 2 * PAS_Y;
            this.Controls.Add(txtModel);

            //An Aparitie
            Label lblAddAnAparitie = new Label();
            lblAddAnAparitie.Width = LUNGIME_ELEMENT;
            lblAddAnAparitie.Text = "An Aparitie";
            lblAddAnAparitie.TextAlign = ContentAlignment.MiddleCenter;
            lblAddAnAparitie.Left = PAS_X;
            lblAddAnAparitie.Top = 3 * PAS_Y;
            this.Controls.Add(lblAddAnAparitie);

            txtAnAparitie = new TextBox();
            txtAnAparitie.Width = LUNGIME_ELEMENT;
            txtAnAparitie.Left = PAS_X;
            txtAnAparitie.Top = 4 * PAS_Y;
            this.Controls.Add(txtAnAparitie);

            //Taxa
            Label lblAddTaxa = new Label();
            lblAddTaxa.Width = LUNGIME_ELEMENT;
            lblAddTaxa.Text = "Taxa";
            lblAddTaxa.TextAlign = ContentAlignment.MiddleCenter;
            lblAddTaxa.Left = PAS_X;
            lblAddTaxa.Top = 5 * PAS_Y;
            this.Controls.Add(lblAddTaxa);

            txtTaxa = new TextBox();
            txtTaxa.Width = LUNGIME_ELEMENT;
            txtTaxa.Left = PAS_X;
            txtTaxa.Top = 6 * PAS_Y;
            this.Controls.Add(txtTaxa);

            //Stoc
            Label lblAddStoc = new Label();
            lblAddStoc.Width = LUNGIME_ELEMENT;
            lblAddStoc.Text = "Stoc";
            lblAddStoc.TextAlign = ContentAlignment.MiddleCenter;
            lblAddStoc.Left = PAS_X;
            lblAddStoc.Top = 7 * PAS_Y;
            this.Controls.Add(lblAddStoc);

            txtStoc = new TextBox();
            txtStoc.Width = LUNGIME_ELEMENT;
            txtStoc.Left = PAS_X;
            txtStoc.Top = 8 * PAS_Y;
            this.Controls.Add(txtStoc);

            //Culoare
            Label lblAddCuloare = new Label();
            lblAddCuloare.Width = LUNGIME_ELEMENT;
            lblAddCuloare.Text = "Culoare";
            lblAddCuloare.TextAlign = ContentAlignment.MiddleCenter;
            lblAddCuloare.Left = PAS_X;
            lblAddCuloare.Top = 9 * PAS_Y;
            this.Controls.Add(lblAddCuloare);

            cboCuloare = new ComboBox();
            cboCuloare.Width = LUNGIME_ELEMENT;
            cboCuloare.Left = PAS_X;
            cboCuloare.Top = 10 * PAS_Y;
            cboCuloare.DataSource = Enum.GetValues(typeof(Culoare));
            this.Controls.Add(cboCuloare);

            btnAdaugaMasina = new Button();
            btnAdaugaMasina.Text = "Adauga";
            btnAdaugaMasina.Width = LUNGIME_ELEMENT;
            btnAdaugaMasina.Left = PAS_X;
            btnAdaugaMasina.Top = 12 * PAS_Y;
            btnAdaugaMasina.Click += OnClick;
            this.Controls.Add(btnAdaugaMasina);

            Label lblModel = new Label();
            lblModel.Width = LUNGIME_ELEMENT;
            lblModel.Text = "Model";
            lblModel.TextAlign = ContentAlignment.MiddleCenter;
            lblModel.Left = LEFT_MARGIN + PAS_X;
            lblModel.Top = PAS_Y;
            this.Controls.Add(lblModel);

            Label lblAnAparitie = new Label();
            lblAnAparitie.Width = LUNGIME_ELEMENT;
            lblAnAparitie.Text = "An Aparitie";
            lblAnAparitie.TextAlign = ContentAlignment.MiddleCenter;
            lblAnAparitie.Left = LEFT_MARGIN + LUNGIME_ELEMENT + PAS_X;
            lblAnAparitie.Top = PAS_Y;
            this.Controls.Add(lblAnAparitie);

            Label lblTaxa = new Label();
            lblTaxa.Width = LUNGIME_ELEMENT;
            lblTaxa.Text = "Taxa";
            lblTaxa.TextAlign = ContentAlignment.MiddleCenter;
            lblTaxa.Left = LEFT_MARGIN + 2 * LUNGIME_ELEMENT + PAS_X;
            lblTaxa.Top = PAS_Y;
            this.Controls.Add(lblTaxa);

            Label lblStoc = new Label();
            lblStoc.Width = LUNGIME_ELEMENT;
            lblStoc.Text = "Stoc";
            lblStoc.TextAlign = ContentAlignment.MiddleCenter;
            lblStoc.Left = LEFT_MARGIN + 3 * LUNGIME_ELEMENT + PAS_X;
            lblStoc.Top = PAS_Y;
            this.Controls.Add(lblStoc);

            Label lblId = new Label();
            lblId.Width = LUNGIME_ELEMENT;
            lblId.Text = "ID";
            lblId.TextAlign = ContentAlignment.MiddleCenter;
            lblId.Left = LEFT_MARGIN + 4 * LUNGIME_ELEMENT + PAS_X;
            lblId.Top = PAS_Y;
            this.Controls.Add(lblId);

            Label lblCuloare = new Label();
            lblCuloare.Width = LUNGIME_ELEMENT;
            lblCuloare.Text = "Culoare";
            lblCuloare.TextAlign = ContentAlignment.MiddleCenter;
            lblCuloare.Left = LEFT_MARGIN + 5 * LUNGIME_ELEMENT + PAS_X;
            lblCuloare.Top = PAS_Y;
            this.Controls.Add(lblCuloare);

            Label lblOptiuni = new Label();
            lblOptiuni.Width = LUNGIME_ELEMENT;
            lblOptiuni.Text = "Optiuni";
            lblOptiuni.TextAlign = ContentAlignment.MiddleCenter;
            lblOptiuni.Left = LEFT_MARGIN + 6 * LUNGIME_ELEMENT + PAS_X;
            lblOptiuni.Top = PAS_Y;
            this.Controls.Add(lblOptiuni);

            this.Load += Form2_Load;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            AfiseazaMasini();
        }
        private void OnClick(object sender, EventArgs e)
        {
            char Sep = ';';
            int LastId = AdministratorMasini_FisierText.GetLastId();
            Console.WriteLine(LastId);
            
            string Linie = $"{LastId}{Sep}{txtModel.Text}{Sep}{txtAnAparitie.Text}{Sep}{txtTaxa.Text}{Sep}" +
                           $"{txtStoc.Text}{Sep}{ (int.Parse(txtStoc.Text) > 0? "true" : "false") }{Sep}{cboCuloare.Text}{Sep}{Optiuni.Nimic}";
            
            Masina MasinaNoua = new Masina(Linie);
            AdminMasini.AddMasinaFisier(MasinaNoua);
            txtModel.Text = "";
            txtAnAparitie.Text = "";
            txtTaxa.Text = "";
            txtStoc.Text = "";
            cboCuloare.Text = "";

            AfiseazaMasina(MasinaNoua, LabelIndex);
            LabelIndex++;
        }

        private void AfiseazaMasina(Masina Mn, int i)
        {
            lblMasina_Model.Add(new Label());
            lblMasina_Model[i].Width = LUNGIME_ELEMENT;
            lblMasina_Model[i].Text = Mn.Model;
            lblMasina_Model[i].Left = LEFT_MARGIN + PAS_X;
            lblMasina_Model[i].Top = (i + 2) * PAS_Y;
            lblMasina_Model[i].TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(lblMasina_Model[i]);

            lblMasina_AnAparitie.Add(new Label());
            lblMasina_AnAparitie[i].Width = LUNGIME_ELEMENT;
            lblMasina_AnAparitie[i].Text = Mn.An_Aparitie.ToString();
            lblMasina_AnAparitie[i].Left = LEFT_MARGIN + LUNGIME_ELEMENT + PAS_X;
            lblMasina_AnAparitie[i].Top = (i + 2) * PAS_Y;
            lblMasina_AnAparitie[i].TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(lblMasina_AnAparitie[i]);

            lblMasina_Taxa.Add(new Label());
            lblMasina_Taxa[i].Width = LUNGIME_ELEMENT;
            lblMasina_Taxa[i].Text = Mn.Taxa.ToString() + " RON";
            lblMasina_Taxa[i].Left = LEFT_MARGIN + 2 * LUNGIME_ELEMENT + PAS_X;
            lblMasina_Taxa[i].Top = (i + 2) * PAS_Y;
            lblMasina_Taxa[i].TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(lblMasina_Taxa[i]);

            lblMasina_Stoc.Add(new Label());
            lblMasina_Stoc[i].Width = LUNGIME_ELEMENT;
            lblMasina_Stoc[i].Text = Mn.Stoc.ToString();
            lblMasina_Stoc[i].Left = LEFT_MARGIN + 3 * LUNGIME_ELEMENT + PAS_X;
            lblMasina_Stoc[i].Top = (i + 2) * PAS_Y;
            lblMasina_Stoc[i].TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(lblMasina_Stoc[i]);

            lblMasina_Id.Add(new Label());
            lblMasina_Id[i].Width = LUNGIME_ELEMENT;
            lblMasina_Id[i].Text = Mn.Id.ToString();
            lblMasina_Id[i].Left = LEFT_MARGIN + 4 * LUNGIME_ELEMENT + PAS_X;
            lblMasina_Id[i].Top = (i + 2) * PAS_Y;
            lblMasina_Id[i].TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(lblMasina_Id[i]);

            lblMasina_Culoare.Add(new Label());
            lblMasina_Culoare[i].Width = LUNGIME_ELEMENT;
            lblMasina_Culoare[i].Text = Mn.Culoare_Masina.ToString();
            lblMasina_Culoare[i].Left = LEFT_MARGIN + 5 * LUNGIME_ELEMENT + PAS_X;
            lblMasina_Culoare[i].Top = (i + 2) * PAS_Y;
            lblMasina_Culoare[i].TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(lblMasina_Culoare[i]);
        }
        private void AfiseazaMasini()
        {
            AdminMasini.GetMasiniFisier();
            List<Masina> Masini = AdminMasini.GetMasini();

            lblMasina_Model = new List<Label>();
            lblMasina_AnAparitie = new List<Label>();
            lblMasina_Taxa = new List<Label>();
            lblMasina_Stoc = new List<Label>();
            lblMasina_Id = new List<Label>();
            lblMasina_Culoare = new List<Label>();

            int i = 0;
            foreach (Masina Mn in Masini)
            {
                if (i < Masini.Count)
                {
                    AfiseazaMasina(Mn, i);
                    i++;
                }
            }
            LabelIndex = i;
        }
    }
}
