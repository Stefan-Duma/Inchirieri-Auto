using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ClaseBaza;

namespace AdministrareClienti
{
    public class Admin
    {
        public const int NR_MAX_CLIENTI = 50;
        
        Client[] Clienti;
        private int NrClienti;
    
        public Admin()
        {
            Clienti = new Client[NR_MAX_CLIENTI];
            NrClienti = 0;
        }
        public void AddClient(Client client)
        {
            if (client == null) return;
            if(NrClienti >= 50)
            {
                Console.WriteLine("Numar maxim de clienti introdusi!");
                return;
            }
            Clienti[NrClienti] = client;
            NrClienti++;
        }
        public void AddClient(Client[] client)
        {
            if(NR_MAX_CLIENTI - NrClienti < client.Length)
            {
                Console.WriteLine("Nu exista sufiecient spatiu pentru a aloca toti clientii!");
                return;
            }
            foreach(Client cln in client)
            {
                Clienti[NrClienti] = cln;
                NrClienti++;
            }
        }
        public string InfoClienti()
        {
            string Info = "";
            foreach(Client cln in Clienti)
            {
                if (cln == null) break;
                Info += $"\nNUME: {cln.Nume}\n" +
                    $"Prenume: {cln.Prenume}\n" +
                    $"Email: {cln.Email}\n" +
                    $"Nr_Telefon: {cln.Nr_telefon}\n" +
                    $"Perioada chirie: {cln.Perioada} zile\n" +
                    $"Vehicul inchiriat: {cln.Vehicul_inchiriat.Model}\n\n";
            }
            return Info;
        }
        public Client CautareClient(string nume, string prenume)
        {
            foreach(Client cln in Clienti)
            {
                if (cln != null && cln.Nume.ToUpper() == nume.ToUpper() && cln.Prenume.ToUpper() == prenume.ToUpper()) return cln;
            }
            return null;
        }
    }
}
