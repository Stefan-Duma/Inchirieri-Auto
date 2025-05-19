using Administrator;
using ClaseBaza;
using MetroFramework.Controls;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Windows.Forms;
namespace InterfataUtilizator_WindowsForms
{
    public partial class FormClienti : MetroForm
    {
        private const int NUME = 0;
        private const int PRENUME = 1;
        private const int EMAIL = 2;
        private const int TELEFON = 3;
        private AdministratorClienti_FisierText AdminClienti;
        private Client ClientGasit;
        public FormClienti()
        {
            InitializeComponent();
            string FisierClienti = ConfigurationManager.AppSettings["FisierClienti"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = locatieFisierSolutie + "\\" + FisierClienti;
            AdminClienti = new AdministratorClienti_FisierText(caleCompletaFisier);

            listClienti.View = View.Details;
            listClienti.Columns.Add("Nume", 150);
            listClienti.Columns.Add("Prenume", 150);
            listClienti.Columns.Add("Email", 200);
            listClienti.Columns.Add("Telefon", 100);
            RefreshList();
        }

        private void btnAdauga_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control is MetroTextBox metroTextBox && string.IsNullOrWhiteSpace(metroTextBox.Text))
                {
                    MessageBox.Show("Toate campurile sunt obligatorii!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            char Sep = ';';
            string Linie = $"{txtNume.Text}{Sep}{txtPrenume.Text}{Sep}{txtEmail.Text}{Sep}" +
                           $"{txtTelefon.Text}{Sep}";
            Client ClientNou = new Client(Linie);
            AdminClienti.AddClientFisier(ClientNou);
            listClienti.Items.Add(new ListViewItem(new[] { ClientNou.Nume, ClientNou.Prenume, ClientNou.Email, ClientNou.Nr_Telefon }));
            ClearValues();
        }

        private void btnCautare_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNume.Text) || string.IsNullOrWhiteSpace(txtPrenume.Text))
            {
                MessageBox.Show("Sunt obligatorii campurile: Nume si Prenume", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            AdminClienti.GetClientiFisier();
            foreach(Client cln in AdminClienti.GetClients())
            {
                if (cln.Nume.ToUpper() == txtNume.Text.ToUpper() && cln.Prenume.ToUpper() == txtPrenume.Text.ToUpper())
                {
                    ClientGasit = cln;
                    txtNume.Text = cln.Nume;
                    txtPrenume.Text = cln.Prenume;
                    txtEmail.Text = cln.Email;
                    txtTelefon.Text = cln.Nr_Telefon;
                    MessageBox.Show("Clientul a fost gasit!\nAcum puteti realiza operatia de modificare sau stergere!", "Cautare finalizata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            MessageBox.Show("Clientul nu a fost gasit!", "Eroare de cautare", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void RefreshList()
        {
            AdminClienti.GetClientiFisier();
            listClienti.Items.Clear();
            foreach (Client cln in AdminClienti.GetClients())
            {
                listClienti.Items.Add(new ListViewItem(new[] { cln.Nume, cln.Prenume, cln.Email, cln.Nr_Telefon }));
            }
        }
        private void ClearValues()
        {
            txtNume.Text = "";
            txtPrenume.Text = "";
            txtEmail.Text = "";
            txtTelefon.Text = "";
            ClientGasit = null;
        }
        private void btnModificare_Click(object sender, EventArgs e)
        {
            if (ClientGasit == null)
            {
                MessageBox.Show("Clientul nu a fost selectat. Folositi optiunea de cautare inainte de modificare.",
                                                    "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            foreach (Client client in AdminClienti.GetClients())
            {
                if (client == ClientGasit)
                {
                    if (!string.IsNullOrWhiteSpace(txtNume.Text)) ClientGasit.Nume = txtNume.Text;
                    if (!string.IsNullOrWhiteSpace(txtPrenume.Text)) ClientGasit.Prenume = txtPrenume.Text;
                    if (!string.IsNullOrWhiteSpace(txtEmail.Text)) ClientGasit.Email = txtEmail.Text;
                    if (!string.IsNullOrWhiteSpace(txtTelefon.Text)) ClientGasit.Nr_Telefon = txtTelefon.Text;
                    break;
                }
            }
            AdminClienti.AddClientiFisier();
            MessageBox.Show("Clientul a fost modificat!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearValues();
            RefreshList();
        }

        private void btnStergere_Click(object sender, EventArgs e)
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
                    clienti.RemoveAt(i);
                    break;
                }
            }
            AdminClienti.AddClientiFisier();
            MessageBox.Show("Clientul a fost eliminat cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearValues();
            RefreshList();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearValues();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
