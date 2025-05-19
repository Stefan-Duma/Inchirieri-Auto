using InchirieriAuto_WindowsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework.Controls;

namespace InterfataUtilizator_WindowsForms
{
    public partial class MainForm: MetroForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void metroClienti_Click(object sender, EventArgs e)
        {
            FormClienti OptiuniClienti = new FormClienti();
            OptiuniClienti.Show();

        }
        private void metroMasini_Click(object sender, EventArgs e)
        {
            FormMasini OptiuniMasini = new FormMasini();
            OptiuniMasini.Show();
        }
        private void metroExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void metroGestiune_Click(object sender, EventArgs e)
        {
            FormGestiune gestiune = new FormGestiune();
            gestiune.Show();
        }
    }
}
