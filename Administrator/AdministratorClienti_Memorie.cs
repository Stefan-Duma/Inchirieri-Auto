using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClaseBaza;

namespace Administrator
{
    public class AdministratorClienti_Memorie
    {
        protected List<Client> Clienti;
        protected int Nr_Clienti;
        public AdministratorClienti_Memorie()
        {
            Clienti = new List<Client>();
        }
        public List<Client> GetClients()
        {
            return Clienti;
        }

        public void AddClient(Client ClientNou)
        {
            if (ClientNou == null) return;
            Clienti.Add(ClientNou);
        }
        public string InfoClienti()
        {
            string Info = "";
            foreach (Client Cln in Clienti)
            {
                if (Cln == null) break;
                Info += Cln.DetaliiClient();
            }
            return Info;
        }
        public Client CautareClient(string Nume, string Prenume)
        {
            foreach (Client Cln in Clienti)
            {
                if (Cln != null && Cln.Nume.ToUpper() == Nume.ToUpper() && Cln.Prenume.ToUpper() == Prenume.ToUpper()) return Cln;
            }
            return null;
        }
        public Client CautareClient(string Info)
        {
            foreach (Client Cln in Clienti)
            {
                if (Cln != null && Cln.Email.ToUpper() == Info.ToUpper()) return Cln;
                if (Cln != null && Cln.Nr_Telefon == Info) return Cln;
            }
            return null;
        }
    }
}
