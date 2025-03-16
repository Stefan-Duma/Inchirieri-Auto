using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClaseBaza;

namespace Administrator
{
   public class AdministratorClienti_FisierText : AdministratorClienti_Memorie
    {
        private string NumeFisier;

        public AdministratorClienti_FisierText(string numeFisier) : base()
        {
            NumeFisier = numeFisier;
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }
        public void AddClientFisier(Client client)
        {
            using (StreamWriter streamWriterFisierText = new StreamWriter(NumeFisier, true))
            {
                streamWriterFisierText.WriteLine(client.DetaliiClientFisier());
            }
        }
        public void GetClientiFisier()
        { 
            using (StreamReader streamReader = new StreamReader(NumeFisier))
            {
                string linieFisier;
                Nr_Clienti = 0;

                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    Clienti[Nr_Clienti++] = new Client(linieFisier);
                }
            }
        }
    }
}
