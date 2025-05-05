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

namespace InterfataUtilizator_WindowsForms
{
    public partial class FormMasini: MetroForm
    {
        private AdministratorMasini_FisierText AdminMasini;
        public FormMasini()
        {
            InitializeComponent();
            string FisierMasini = ConfigurationManager.AppSettings["FisierMasini"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = locatieFisierSolutie + "\\" + FisierMasini;
            AdminMasini = new AdministratorMasini_FisierText(caleCompletaFisier);
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
            int LastId = AdministratorMasini_FisierText.GetLastId();
            Console.WriteLine(LastId);

            string Linie = $"{LastId}{Sep}{txtModel.Text}{Sep}{txtAnAparitie.Text}{Sep}{txtTaxa.Text}{Sep}" +
                           $"{txtStoc.Text}{Sep}{(int.Parse(txtStoc.Text) > 0 ? "true" : "false")}{Sep}{Culoare.Alb}{Sep}{Optiuni.Nimic}";

            Masina MasinaNoua = new Masina(Linie);
            AdminMasini.AddMasinaFisier(MasinaNoua);
            txtModel.Text = "";
            txtAnAparitie.Text = "";
            txtTaxa.Text = "";
            txtStoc.Text = "";

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtModel.Text) && string.IsNullOrWhiteSpace(txtAnAparitie.Text))
            {
                MessageBox.Show("Pentru cautare modelul si anul aparitiei sunt obligatorii!");
                return;
            }
            AdminMasini.GetMasiniFisier();

            foreach(Masina Mn in AdminMasini.GetMasini())
            {
                if (Mn.Model == txtModel.Text && Mn.An_Aparitie == int.Parse(txtAnAparitie.Text))
                {
                    MessageBox.Show($"Masina a fost gasita:\n" +
                                    $"ID: {Mn.Id}\n" +
                                    $"Model: {Mn.Model}\n" +
                                    $"An aparitie: {Mn.An_Aparitie}\n" +
                                    $"Taxa: {Mn.Taxa}\n" +
                                    $"Stoc: {Mn.Stoc}\n", "Masina gasita");
                    return;
                }
            }
        }
    }
}
