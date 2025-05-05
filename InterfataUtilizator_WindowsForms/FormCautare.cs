using Administrator;
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

namespace InterfataUtilizator_WindowsForms
{
    public partial class FormCautare: Form
    {
        AdministratorClienti_FisierText admin;
        public FormCautare()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Optiuni cautare";
            this.Font = new Font("Arial", 9, FontStyle.Bold);
            this.BackColor = Color.FromArgb(51, 51, 51);
            this.ForeColor = Color.Gold;
            button1.BackColor = Color.FromArgb(51, 51, 51);
            button1.ForeColor = Color.Gold;
            button2.BackColor = Color.FromArgb(51, 51, 51);
            button2.ForeColor = Color.Gold;
            button3.BackColor = Color.FromArgb(51, 51, 51);
            button3.ForeColor = Color.Gold;

            string FisierClienti = ConfigurationManager.AppSettings["FisierClienti"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = locatieFisierSolutie + "\\" + FisierClienti;
            admin = new AdministratorClienti_FisierText(caleCompletaFisier);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
