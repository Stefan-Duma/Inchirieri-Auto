using ClaseBaza;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administrator
{
    public class AdministratorMasini_FisierText : AdministratorMasini_Memorie
    {
        private string NumeFisier;
        public AdministratorMasini_FisierText(string numeFisier) : base()
        {
            NumeFisier = numeFisier;
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
            GetLastId();
        }
        public void AddMasinaFisier(Masina masina)
        {
            if (masina == null) return;
            using (StreamWriter streamWriterFisierText = new StreamWriter(NumeFisier, true))
            {
                streamWriterFisierText.WriteLine(masina.DetaliiMasinaFisier());
            }
        }

        public void GetMasiniFisier()
        {
            using (StreamReader streamReader = new StreamReader(NumeFisier))
            {
                string linieFisier;
                Nr_Masini = 0;
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    Masini[Nr_Masini++] = new Masina(linieFisier);
                }
            }
        }

        private static void GetLastId()
        {

            string LocatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string FisierMasini = ConfigurationManager.AppSettings["FisierMasini"];
            string CaleCompletaFisierMasini = LocatieFisierSolutie + "\\" + FisierMasini;

            using (StreamReader streamReader = new StreamReader(CaleCompletaFisierMasini))
            {
                string linieFisier;
                string[] lista;
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    lista = linieFisier.Split(';');
                    Masina.Next_Id = Int32.Parse(lista[0]) + 1;
                }
            }
        }
    }
}