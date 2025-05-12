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
        private Client ClientGasit;
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
                    MessageBox.Show("Toate campurile sunt obligatorii!", "Invalid");
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
                if (cln.Nume.ToUpper() == txtNume.Text.ToUpper() && cln.Prenume.ToUpper() == txtPrenume.Text.ToUpper() && cln.Email.ToUpper() == txtEmail.Text.ToUpper())
                {
                    ClientGasit = cln;
                    richTextBoxClientInfo.Text = $"Clientul a fost gasit:\n" +
                                    $"Nume: {cln.Nume}\n" +
                                    $"Prenume: {cln.Prenume}\n" +
                                    $"Email: {cln.Email}\n" +
                                    $"Telefon: {cln.Nr_Telefon}\n" +
                                    $"Perioada: {cln.Perioada} zile\n" +
                                    $"ID Vehicul: {cln.Id_Vehicul}";
                    txtNume.Text = "";
                    txtPrenume.Text = "";
                    txtEmail.Text = "";
                    return;
                }
            }
            MessageBox.Show("Clientul nu a fost gasit!", "Eroare de cautare");
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            if (ClientGasit == null)
            {
                MessageBox.Show("Clientul nu a fost selectat. Folositi optiunea de cautare inainte de modificare.",
                                                    "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            List<Client> clienti = AdminClienti.GetClients();
            for (int i = 0; i < clienti.Count; i++)
            {
                if (clienti[i] == ClientGasit)
                {
                    if (!string.IsNullOrWhiteSpace(txtNume.Text)) ClientGasit.Nume = txtNume.Text;
                    if (!string.IsNullOrWhiteSpace(txtPrenume.Text)) ClientGasit.Prenume = txtPrenume.Text;
                    if (!string.IsNullOrWhiteSpace(txtEmail.Text)) ClientGasit.Email = txtEmail.Text;
                    if (!string.IsNullOrWhiteSpace(txtTelefon.Text)) ClientGasit.Nr_Telefon = txtTelefon.Text;
                    if (!string.IsNullOrWhiteSpace(txtPerioada.Text)) ClientGasit.Perioada = int.Parse(txtPerioada.Text);
                    if (!string.IsNullOrWhiteSpace(txtId.Text)) ClientGasit.Id_Vehicul = int.Parse(txtId.Text);
                    break;
                }
            }
            AdminClienti.AddClientiFisier();
            MessageBox.Show("Clientul a fost modificat", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            richTextBoxClientInfo.Text = "";
            txtNume.Text = "";
            txtPrenume.Text = "";
            txtEmail.Text = "";
            txtTelefon.Text = "";
            txtPerioada.Text = "";
            txtId.Text = "";
        }
    }
}
