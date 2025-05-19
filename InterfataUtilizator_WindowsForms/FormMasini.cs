using Administrator;
using ClaseBaza;
using MetroFramework.Controls;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace InterfataUtilizator_WindowsForms
{
    public partial class FormMasini: MetroForm
    {
        private AdministratorMasini_FisierText AdminMasini;
        private Masina MasinaGasita;
        private CheckBox[] checkOptiuni;
        private RadioButton[] radioCulori;
        private MetroTextBox[] txtCampuri;
        public FormMasini()
        {
            InitializeComponent();
            string FisierMasini = ConfigurationManager.AppSettings["FisierMasini"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = locatieFisierSolutie + "\\" + FisierMasini;
            AdminMasini = new AdministratorMasini_FisierText(caleCompletaFisier);
            MasinaGasita = null;

            checkOptiuni = new CheckBox[] {checkAerConditionat, checkNavigatie, checkCutieAutomata, checkScaune,
                                          checkSenzori, checkCamere360, checkJante, checkPilotAutomat};
            radioCulori = new RadioButton[] { radioAlb, radioNegru, radioRosu, radioAlbastru,
                                              radioVerde, radioGri, radioGalben, radioPortocaliu };
            txtCampuri = new MetroTextBox[] { txtModel, txtAnAparitie, txtTaxa, txtStoc };

            listMasini.View = View.Details;
            listMasini.Columns.Add("ID", 50);
            listMasini.Columns.Add("Model", 150);
            listMasini.Columns.Add("An", 75);
            listMasini.Columns.Add("Taxa", 50);
            listMasini.Columns.Add("Stoc", 50); 
            listMasini.Columns.Add("Culoare", 80);
            listMasini.Columns.Add("Optiuni", 650);
            RefreshList();
        }
        private void RefreshList()
        {
            AdminMasini.GetMasiniFisier();
            listMasini.Items.Clear();
            foreach(Masina Mn in AdminMasini.GetMasini())
            {
                AddMasina(Mn);
            }
        }
        private void ClearValues()
        {
            txtModel.Text = "";
            txtAnAparitie.Text = "";
            txtTaxa.Text = "";
            txtStoc.Text = "";
            foreach (RadioButton radio in radioCulori)
            {
                if (radio.Checked)
                {
                    radio.Checked = false;
                    break;
                }
            }
            foreach (CheckBox checkOptiune in checkOptiuni)
            {
                if (checkOptiune.Checked)
                {
                    checkOptiune.Checked = false;
                }
            }
            MasinaGasita = null;
        }
        private void AddMasina(Masina MasinaNoua)
        {
            listMasini.Items.Add(new ListViewItem(new[] {MasinaNoua.Id.ToString(), MasinaNoua.Model, MasinaNoua.An_Aparitie.ToString(), MasinaNoua.Taxa.ToString(),
                                                        MasinaNoua.Stoc.ToString(), MasinaNoua.Culoare_Masina.ToString(), MasinaNoua.Optiuni_Masina.ToString() }));
        }
        private void btnAdauga_Click(object sender, EventArgs e)
        {
            Culoare CuloareMasina = Culoare.Alb;
            Optiuni OptiuniMasina = Optiuni.Nimic;
            foreach (MetroTextBox Camp in txtCampuri)
            {
                if (string.IsNullOrWhiteSpace(Camp.Text))
                {
                    MessageBox.Show("Toate campurile sunt obligatorii!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            foreach (RadioButton radio in radioCulori)
            { 
                if (radio.Checked)
                {
                    CuloareMasina = (Culoare)Enum.Parse(typeof(Culoare), radio.Text);
                    break;
                }
            }
            foreach(CheckBox checkOptiune in checkOptiuni)
            { 
                if(checkOptiune.Checked)
                {
                    OptiuniMasina |= (Optiuni)Enum.Parse(typeof(Optiuni), checkOptiune.Text);
                }
            }
            char Sep = ';';
            int LastId = AdministratorMasini_FisierText.GetLastId();

            string Linie = $"{LastId}{Sep}{txtModel.Text}{Sep}{txtAnAparitie.Text}{Sep}{txtTaxa.Text}{Sep}" +
                           $"{txtStoc.Text}{Sep}{(int.Parse(txtStoc.Text) > 0 ? "true" : "false")}{Sep}{CuloareMasina}{Sep}{OptiuniMasina}";

            Masina MasinaNoua = new Masina(Linie);
            AdminMasini.AddMasinaFisier(MasinaNoua);
            AddMasina(MasinaNoua);
            ClearValues();

        }

        private void btnCautare_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtModel.Text) && string.IsNullOrWhiteSpace(txtAnAparitie.Text))
            {
                MessageBox.Show("Pentru cautare modelul si anul aparitiei sunt obligatorii!", 
                                "Eroare de cautare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            AdminMasini.GetMasiniFisier();

            foreach(Masina Mn in AdminMasini.GetMasini())
            {
                if (Mn.Model.ToUpper() == txtModel.Text.ToUpper() && Mn.An_Aparitie == int.Parse(txtAnAparitie.Text))
                {
                    
                    MessageBox.Show("Masina a fost gasita cu succes!\nAcum puteti efectua operatia de modificare sau stergere",
                                    "Succes!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtModel.Text = Mn.Model;
                    txtAnAparitie.Text = Mn.An_Aparitie.ToString();
                    txtTaxa.Text = Mn.Taxa.ToString();
                    txtStoc.Text = Mn.Stoc.ToString();
                    string strOptiuni = Mn.Optiuni_Masina.ToString();
                    string[] optiuni = strOptiuni.Split(',').Select(optiune => optiune.Trim()).ToArray();
                    foreach (CheckBox optiune in checkOptiuni)
                    {
                        foreach (string strOptiune in optiuni)
                        {
                            if (optiune.Text == strOptiune) optiune.Checked = true;
                        }
                    }
                    foreach (MetroRadioButton culoare in radioCulori)
                    {
                        if (culoare.Text == Mn.Culoare_Masina.ToString())
                        { 
                            culoare.Checked = true;
                            break;
                        }
                    }
                    MasinaGasita = Mn;
                    return;
                }
            }
            MessageBox.Show("Masina nu a fost gasita", "Eroare de cautare");
        }

        private void btnModificare_Click(object sender, EventArgs e)
        {
            if(MasinaGasita == null)
            {
                MessageBox.Show("Masina nu a fost selectata.\nUtilizati operatia de cautare pentru a putea modifica o masina!",
                    "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            foreach (Masina Mn in AdminMasini.GetMasini())
            {
                if (Mn == MasinaGasita)
                {
                    if (!string.IsNullOrWhiteSpace(txtModel.Text)) MasinaGasita.Model = txtModel.Text;
                    if (!string.IsNullOrWhiteSpace(txtAnAparitie.Text)) MasinaGasita.An_Aparitie = int.Parse(txtAnAparitie.Text);
                    if (!string.IsNullOrWhiteSpace(txtTaxa.Text)) MasinaGasita.Taxa = int.Parse(txtTaxa.Text);
                    if (!string.IsNullOrWhiteSpace(txtStoc.Text)) MasinaGasita.Stoc = int.Parse(txtStoc.Text);
                    foreach (RadioButton radio in radioCulori)
                    {
                        if (radio.Checked)
                        {
                            MasinaGasita.Culoare_Masina = (Culoare)Enum.Parse(typeof(Culoare), radio.Text);
                            break;
                        }
                    }
                    foreach (CheckBox checkOptiune in checkOptiuni)
                    {
                        if (checkOptiune.Checked)
                        {
                            MasinaGasita.Optiuni_Masina |= (Optiuni)Enum.Parse(typeof(Optiuni), checkOptiune.Text);
                        }
                    }
                    break;
                }
            }
            AdminMasini.AddMasiniFisier();
            MessageBox.Show("Masina a fost modificata!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RefreshList();
            ClearValues();
        }

        private void btnStergere_Click(object sender, EventArgs e)
        {
            if (MasinaGasita == null)
            {
                MessageBox.Show("Masina nu a fost selectata.\nUtilizati operatia de cautare pentru a putea sterge masina!",
                    "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            List<Masina> Masini = AdminMasini.GetMasini();
            for (int i = 0; i < Masini.Count; i++)
            {
                if (Masini[i] == MasinaGasita)
                {
                    Masini.RemoveAt(i);
                    break;
                }
            }
            AdminMasini.AddMasiniFisier();
            MessageBox.Show("Masina a fost eliminata cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RefreshList();
            ClearValues();
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
