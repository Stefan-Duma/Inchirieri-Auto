using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Administrator;
using ClaseBaza;
using MetroFramework.Controls;
using MetroFramework.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
namespace InterfataUtilizator_WindowsForms
{
    public partial class FormClienti : MetroForm
    {
        private PictureBox backgroundPictureBox;
        private AdministratorClienti_FisierText AdminClienti;
        public FormClienti()
        {
            InitializeComponent();
            string FisierClienti = ConfigurationManager.AppSettings["FisierClienti"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = locatieFisierSolutie + "\\" + FisierClienti;
            AdminClienti = new AdministratorClienti_FisierText(caleCompletaFisier);

            //Image bgImage = Image.FromFile("C:\\Users\\Stefan\\source\\repos\\InchirieriAuto\\BackgroundImages\\OptiuniClienti.jpeg");

            //backgroundPictureBox = new PictureBox();
            //backgroundPictureBox.Dock = DockStyle.Fill;
            //backgroundPictureBox.Image = bgImage;
            //backgroundPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

            //this.Controls.Add(backgroundPictureBox);

            //backgroundPictureBox.SendToBack();
            //this.DoubleBuffered = true;
            //metroLabel1.BackColor = Color.Transparent;
            //metroLabel1.Parent = backgroundPictureBox;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control is MetroTextBox metroTextBox && string.IsNullOrWhiteSpace(metroTextBox.Text))
                {
                    MessageBox.Show("Toate campurile sunt obligatorii!");
                    return;
                }
            }
            char Sep = ';';
            string Linie = $"{txtNume.Text}{Sep}{txtPrenume.Text}{Sep}{txtEmail.Text}{Sep}" +
                           $"{txtTelefon.Text} {Sep} {txtPerioada.Text} {Sep} {txtId.Text}{Sep}";
            Client ClientNou = new Client(Linie);
            AdminClienti.AddClientFisier(ClientNou);

            txtNume.Text = "";
            txtPrenume.Text = "";
            txtEmail.Text = "";
            txtTelefon.Text = "";
            txtPerioada.Text = "";
            txtId.Text = "";
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNume.Text) || string.IsNullOrWhiteSpace(txtPrenume.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Sunt obligatorii campurile: Nume, Prenume si Email", "Invalid");
                return;
            }
            AdminClienti.GetClientiFisier();
            foreach(Client cln in AdminClienti.GetClients())
            {
                if (cln.Nume == txtNume.Text && cln.Prenume == txtPrenume.Text && cln.Email == txtEmail.Text)
                {
                    MessageBox.Show($"Clientul a fost gasit:\n" +
                                    $"Nume: {cln.Nume}\n" +
                                    $"Prenume: {cln.Prenume}\n" +
                                    $"Email: {cln.Email}\n" +
                                    $"Telefon: {cln.Nr_Telefon}\n" +
                                    $"Perioada: {cln.Perioada} zile\n" +
                                    $"ID Vehicul: {cln.Id_Vehicul}", "Client gasit");
                    txtNume.Text = "";
                    txtPrenume.Text = "";
                    txtEmail.Text = "";
                    return;
                }
            }
            MessageBox.Show("Clientul nu a fost gasit!", "Eroare de cautare");
        }
    }
}
