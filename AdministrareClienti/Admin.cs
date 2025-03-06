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
        public const int NR_MAX_MASINI = 50;

        Client[] Clienti;
        private int Nr_Clienti;

        Masina[] Masini;
        private int Nr_Masini;
        public Admin()
        {
            Clienti = new Client[NR_MAX_CLIENTI];
            Nr_Clienti = 0;

            Masini = new Masina[NR_MAX_MASINI];
            Nr_Masini = 0;
        }
        public void AddClient(Client ClientNou)
        {
            if (ClientNou == null) return;
            if(Nr_Clienti >= NR_MAX_CLIENTI)
            {
                Console.WriteLine("Numar maxim de Clienti introdusi!");
                return;
            }
            Clienti[Nr_Clienti] = ClientNou;
            Nr_Clienti++;
        }
        public void AddClient(Client[] ClientNou)
        {
            if(NR_MAX_MASINI - Nr_Clienti < ClientNou.Length)
            {
                Console.WriteLine("Nu exista sufiecient spatiu pentru a aloca toti Clientii!");
                return;
            }
            foreach(Client Cln in Clienti)
            {
                Clienti[Nr_Clienti] = Cln;
                Nr_Clienti++;
            }
        }
        public string InfoClienti()
        {
            string Info = "";
            foreach(Client Cln in Clienti)
            {
                if (Cln == null) break;
                Info += Cln.DetaliiClient();
            }
            return Info;
        }
        public Client CautareClient(string Nume, string Prenume)
        {
            foreach(Client Cln in Clienti)
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
        public void AddMasina(Masina Mn)
        {
            if (Mn == null) return;
            if (Nr_Masini >= NR_MAX_MASINI)
            {
                Console.WriteLine("Numar maxim de masin introduse!");
                return;
            }
            Masini[Nr_Masini] = Mn;
            Nr_Masini++;
        }
        
        public Masina[] GetMasini()
        {
            return (Masina[])Masini.Clone();
        }
        public Masina GetMasina(int Id)
        {
            foreach(Masina Mn in Masini)
            {
                if (Mn != null && Mn.Id == Id) return Mn;
            }
            return null;
        }
        
        public string InfoMasini()
        {
            string Info = "";
            foreach (Masina Mn in Masini)
            {
                if (Mn == null) break;
                    Info += Mn.DetaliiMasina();
            }
            return Info;
        }
        public int GetNrMasini()
        {
            return Nr_Masini;
        }
    }
}
