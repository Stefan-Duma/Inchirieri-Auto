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
            if (client == null) return;
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

                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    Clienti.Add(new Client(linieFisier));
                }
            }
        }
        public Client CautareClientFisier(string nume, string prenume)
        {
            Client Client_Gasit;
            string linieFisier = "";
            using (StreamReader streamReader = new StreamReader(NumeFisier))
            {
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    Client_Gasit = new Client(linieFisier);
                    if (Client_Gasit != null && Client_Gasit.Nume.ToUpper() == nume.ToUpper() && Client_Gasit.Prenume.ToUpper() == prenume.ToUpper()) return Client_Gasit;
                }
            }
            return null;
        }
        public Client CautareClientFisier(string Info)
        {
            Client Client_Gasit;
            string linieFisier = "";
            using (StreamReader streamReader = new StreamReader(NumeFisier))
            {
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    Client_Gasit = new Client(linieFisier);
                    if (Client_Gasit != null && Client_Gasit.Email.ToUpper() == Info.ToUpper()) return Client_Gasit;
                    if (Client_Gasit != null && Client_Gasit.Nr_Telefon == Info) return Client_Gasit;
                }
            }
            return null;
        }
    }
}
