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
        private string FisierId;
        public AdministratorMasini_FisierText(string numeFisier) : base()
        {
            NumeFisier = numeFisier;
            FisierId = ConfigurationManager.AppSettings["LastId"];
            
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            Stream streamLastId = File.Open(FisierId, FileMode.OpenOrCreate);
            
            streamFisierText.Close();
            streamLastId.Close();

            ReadLastId();
        }
        public void AddMasinaFisier(Masina masina)
        {
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
            };
        }
        public void WriteLastId()
        {
            using (StreamWriter streamWriterFisierId = new StreamWriter(FisierId)) 
            {
                streamWriterFisierId.WriteLine(Masina.Next_Id.ToString());
            }
        }
        public static void ReadLastId()
        {
            int lastId;
            string linieFisier;
            string fisierId = ConfigurationManager.AppSettings["LastId"];
            using (StreamReader streamReaderFisierId = new StreamReader(fisierId))
            {
                if ((linieFisier = streamReaderFisierId.ReadLine()) != null) 
                {
                    lastId = Int32.Parse(linieFisier.Split()[0]);
                    Masina.Next_Id = lastId;
                }
                else
                {
                    Masina.Next_Id = 0;
                }
            }
            using (StreamWriter streamWriterFisierId = new StreamWriter(fisierId, false)) { } //Golire fisier dupa citire.
        }
    }
}
