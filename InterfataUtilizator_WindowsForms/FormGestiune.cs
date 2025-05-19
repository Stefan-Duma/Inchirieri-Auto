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
using MetroFramework.Forms;

namespace InterfataUtilizator_WindowsForms
{
    public partial class FormGestiune: MetroForm
    {
        private AdministratorClienti_FisierText AdminClienti;
        private AdministratorMasini_FisierText AdminMasini;
        public FormGestiune()
        {
            InitializeComponent();
            string FisierClienti = ConfigurationManager.AppSettings["FisierClienti"];
            string FisierMasini = ConfigurationManager.AppSettings["FisierMasini"];
            string FisierGestiune = ConfigurationManager.AppSettings["FisierGestiune"];

            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;

            string caleFisierClienti = locatieFisierSolutie + "\\" + FisierClienti;
            string caleFisierMasini = locatieFisierSolutie + "\\" + FisierMasini;
            string caleFisierGestiune = locatieFisierSolutie + "\\" + FisierGestiune;
            AdminClienti = new AdministratorClienti_FisierText(caleFisierClienti);
            AdminMasini = new AdministratorMasini_FisierText(caleFisierMasini);
        }
        private void Inchiriaza(Client client, Masina masina)
        {
            return;
        }
    }
}
