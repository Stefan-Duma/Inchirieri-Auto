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
        public const int NR_MAX_CLIENTI = 50;

        protected Client[] Clienti;
        protected int Nr_Clienti;
        public AdministratorClienti_Memorie()
        {
            Clienti = new Client[NR_MAX_CLIENTI];
            Nr_Clienti = 0;
        }
        public Client[] GetClients()
        {
            return (Client[])Clienti.Clone();
        }
        public int GetNrClienti()
        {
            return Nr_Clienti;
        }

        public void AddClient(Client ClientNou)
        {
            if (ClientNou == null) return;
            if (Nr_Clienti >= NR_MAX_CLIENTI) return;
            Clienti[Nr_Clienti] = ClientNou;
            Nr_Clienti++;
        }
        public void AddClient(Client[] ClientNou)
        {
            if (NR_MAX_CLIENTI - Nr_Clienti < ClientNou.Length) return;
            foreach (Client Cln in Clienti)
            {
                Clienti[Nr_Clienti] = Cln;
                Nr_Clienti++;
            }
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
