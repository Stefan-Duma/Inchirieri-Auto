using System;
using System.Drawing;
using System.IO;
using System.Linq;
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

        private const int LUNGIME_ELEMENT = 150;
        private const int PAS_X = 20;
        private const int PAS_Y = 20;

        private Label[] lblMasina_Model;
        private Label[] lblMasina_AnAparitie;
        private Label[] lblMasina_Taxa;
        private Label[] lblMasina_Stoc;
        private Label[] lblMasina_InStoc;
        private Label[] lblMasina_Id;
        private Label[] lblMasina_Culoare;
        private Label[] lblMasina_Optiuni;

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

            Label lblModel = new Label();
            lblModel.Width = LUNGIME_ELEMENT;
            lblModel.Text = "Model";
            lblModel.TextAlign = ContentAlignment.MiddleCenter;
            lblModel.Left = PAS_X;
            lblModel.Top = PAS_Y;
            this.Controls.Add(lblModel);

            Label lblAnAparitie = new Label();
            lblAnAparitie.Width = LUNGIME_ELEMENT;
            lblAnAparitie.Text = "An Aparitie";
            lblAnAparitie.TextAlign = ContentAlignment.MiddleCenter;
            lblAnAparitie.Left = LUNGIME_ELEMENT + PAS_X;
            lblAnAparitie.Top = PAS_Y;
            this.Controls.Add(lblAnAparitie);

            Label lblTaxa = new Label();
            lblTaxa.Width = LUNGIME_ELEMENT;
            lblTaxa.Text = "Taxa";
            lblTaxa.TextAlign = ContentAlignment.MiddleCenter;
            lblTaxa.Left = 2 * LUNGIME_ELEMENT + PAS_X;
            lblTaxa.Top = PAS_Y;
            this.Controls.Add(lblTaxa);

            Label lblStoc = new Label();
            lblStoc.Width = LUNGIME_ELEMENT;
            lblStoc.Text = "Stoc";
            lblStoc.TextAlign = ContentAlignment.MiddleCenter;
            lblStoc.Left = 3 * LUNGIME_ELEMENT + PAS_X;
            lblStoc.Top = PAS_Y;
            this.Controls.Add(lblStoc);


            Label lblId = new Label();
            lblId.Width = LUNGIME_ELEMENT;
            lblId.Text = "ID";
            lblId.TextAlign = ContentAlignment.MiddleCenter;
            lblId.Left = 4 * LUNGIME_ELEMENT + PAS_X;
            lblId.Top = PAS_Y;
            this.Controls.Add(lblId);

            Label lblCuloare = new Label();
            lblCuloare.Width = LUNGIME_ELEMENT;
            lblCuloare.Text = "Culoare";
            lblCuloare.TextAlign = ContentAlignment.MiddleCenter;
            lblCuloare.Left = 5 * LUNGIME_ELEMENT + PAS_X;
            lblCuloare.Top = PAS_Y;
            this.Controls.Add(lblCuloare);

            Label lblOptiuni = new Label();
            lblOptiuni.Width = LUNGIME_ELEMENT;
            lblOptiuni.Text = "Optiuni";
            lblOptiuni.TextAlign = ContentAlignment.MiddleCenter;
            lblOptiuni.Left = 6 * LUNGIME_ELEMENT + PAS_X;
            lblOptiuni.Top = PAS_Y;
            this.Controls.Add(lblOptiuni);

            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AfiseazaMasini();
        }

        private void AfiseazaMasini()
        {
            AdminMasini.GetMasiniFisier();
            Masina[] Masini = AdminMasini.GetMasini();
            int Nr = AdminMasini.GetNrMasini();
            lblMasina_Model = new Label[Nr];
            lblMasina_AnAparitie = new Label[Nr];
            lblMasina_Taxa = new Label[Nr];
            lblMasina_Stoc = new Label[Nr];
            lblMasina_Id = new Label[Nr];
            lblMasina_Culoare = new Label[Nr];
            lblMasina_Optiuni = new Label[Nr];

            int i = 0;
            foreach (Masina Mn in Masini)
            {
                if (i < Nr && Mn != null)
                {
                    lblMasina_Model[i] = new Label();
                    lblMasina_Model[i].Width = LUNGIME_ELEMENT;
                    lblMasina_Model[i].Text = Mn.Model;
                    lblMasina_Model[i].Left = PAS_X;
                    lblMasina_Model[i].Top = (i + 2) * PAS_Y;
                    lblMasina_Model[i].TextAlign = ContentAlignment.MiddleCenter;
                    this.Controls.Add(lblMasina_Model[i]);

                    lblMasina_AnAparitie[i] = new Label();
                    lblMasina_AnAparitie[i].Width = LUNGIME_ELEMENT;
                    lblMasina_AnAparitie[i].Text = Mn.An_Aparitie.ToString();
                    lblMasina_AnAparitie[i].Left = LUNGIME_ELEMENT + PAS_X;
                    lblMasina_AnAparitie[i].Top = (i + 2) * PAS_Y;
                    lblMasina_AnAparitie[i].TextAlign = ContentAlignment.MiddleCenter;
                    this.Controls.Add(lblMasina_AnAparitie[i]);

                    lblMasina_Taxa[i] = new Label();
                    lblMasina_Taxa[i].Width = LUNGIME_ELEMENT;
                    lblMasina_Taxa[i].Text = Mn.Taxa.ToString() + " RON";
                    lblMasina_Taxa[i].Left = 2 * LUNGIME_ELEMENT + PAS_X;
                    lblMasina_Taxa[i].Top = (i + 2) * PAS_Y;
                    lblMasina_Taxa[i].TextAlign = ContentAlignment.MiddleCenter;
                    this.Controls.Add(lblMasina_Taxa[i]);

                    lblMasina_Stoc[i] = new Label();
                    lblMasina_Stoc[i].Width = LUNGIME_ELEMENT;
                    lblMasina_Stoc[i].Text = Mn.Stoc.ToString();
                    lblMasina_Stoc[i].Left = 3 * LUNGIME_ELEMENT + PAS_X;
                    lblMasina_Stoc[i].Top = (i + 2) * PAS_Y;
                    lblMasina_Stoc[i].TextAlign = ContentAlignment.MiddleCenter;
                    this.Controls.Add(lblMasina_Stoc[i]);

                    lblMasina_Id[i] = new Label();
                    lblMasina_Id[i].Width = LUNGIME_ELEMENT;
                    lblMasina_Id[i].Text = Mn.Id.ToString();
                    lblMasina_Id[i].Left = 4 * LUNGIME_ELEMENT + PAS_X;
                    lblMasina_Id[i].Top = (i + 2) * PAS_Y;
                    lblMasina_Id[i].TextAlign = ContentAlignment.MiddleCenter;
                    this.Controls.Add(lblMasina_Id[i]);

                    lblMasina_Culoare[i] = new Label();
                    lblMasina_Culoare[i].Width = LUNGIME_ELEMENT;
                    lblMasina_Culoare[i].Text = Mn.Culoare_Masina.ToString();
                    lblMasina_Culoare[i].Left = 5 * LUNGIME_ELEMENT + PAS_X;
                    lblMasina_Culoare[i].Top = (i + 2) * PAS_Y;
                    lblMasina_Culoare[i].TextAlign = ContentAlignment.MiddleCenter;
                    this.Controls.Add(lblMasina_Culoare[i]);

                    lblMasina_Optiuni[i] = new Label();
                    lblMasina_Optiuni[i].Width = LUNGIME_ELEMENT;
                    lblMasina_Optiuni[i].Text = string.Join(", ", Mn.Optiuni_Masina);
                    lblMasina_Optiuni[i].Left = 6 * LUNGIME_ELEMENT + PAS_X;
                    lblMasina_Optiuni[i].Top = (i + 2) * PAS_Y;
                    lblMasina_Optiuni[i].TextAlign = ContentAlignment.MiddleCenter;
                    this.Controls.Add(lblMasina_Optiuni[i]);
                    
                    i++;
                }
            }
        }
    }
}
