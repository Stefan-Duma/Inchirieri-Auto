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
            Culoare CuloareMasina = Culoare.Alb;
            Optiuni OptiuniMasina = Optiuni.Nimic;
            foreach (Control control in this.Controls)
            {
                if (control is MetroTextBox metroTextBox && string.IsNullOrWhiteSpace(metroTextBox.Text))
                {
                    MessageBox.Show("Toate campurile sunt obligatorii!", "Invalid");
                    return;
                }
                if(control is MetroRadioButton metroRadio && metroRadio.Checked)
                {
                    CuloareMasina = (Culoare)Enum.Parse(typeof(Culoare), metroRadio.Text);
                }
                if(control is MetroCheckBox metroCheck && metroCheck.Checked)
                {
                    OptiuniMasina |= (Optiuni)Enum.Parse(typeof(Optiuni), metroCheck.Text);
                }
            }
            char Sep = ';';
            int LastId = AdministratorMasini_FisierText.GetLastId();
            Console.WriteLine(LastId);

            string Linie = $"{LastId}{Sep}{txtModel.Text}{Sep}{txtAnAparitie.Text}{Sep}{txtTaxa.Text}{Sep}" +
                           $"{txtStoc.Text}{Sep}{(int.Parse(txtStoc.Text) > 0 ? "true" : "false")}{Sep}{CuloareMasina}{Sep}{OptiuniMasina}";

            Masina MasinaNoua = new Masina(Linie);
            AdminMasini.AddMasinaFisier(MasinaNoua);
            txtModel.Text = "";
            txtAnAparitie.Text = "";
            txtTaxa.Text = "";
            txtStoc.Text = "";
            foreach (Control control in this.Controls)
            {
                if (control is MetroCheckBox metroCheck && metroCheck.Checked)
                {
                    metroCheck.Checked = false;
                }
                if (control is MetroRadioButton metroRadio && metroRadio.Checked)
                {
                    metroRadio.Checked = false;
                }
            }

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtModel.Text) && string.IsNullOrWhiteSpace(txtAnAparitie.Text))
            {
                MessageBox.Show("Pentru cautare modelul si anul aparitiei sunt obligatorii!", "Eroare de cautare");
                return;
            }
            AdminMasini.GetMasiniFisier();

            foreach(Masina Mn in AdminMasini.GetMasini())
            {
                if (Mn.Model == txtModel.Text && Mn.An_Aparitie == int.Parse(txtAnAparitie.Text))
                {
                    MessageBox.Show($"ID: {Mn.Id}\n" +
                                    $"Model: {Mn.Model}\n" +
                                    $"An aparitie: {Mn.An_Aparitie}\n" +
                                    $"Taxa: {Mn.Taxa}\n" +
                                    $"Stoc: {Mn.Stoc}\n" +
                                    $"Culoare: {Mn.Culoare_Masina}\n" +
                                    $"Optiuni: {Mn.Optiuni_Masina}", "Masina gasita");
                    return;
                }
            }
            MessageBox.Show("Masina nu a fost gasita", "Eroare de cautare");
        }
    }
}
