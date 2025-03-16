using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClaseBaza;

namespace Administrator
{
    public class AdministratorMasini_Memorie
    {
        public const int NR_MAX_MASINI = 50;
        protected Masina[] Masini;
        protected int Nr_Masini;
        public AdministratorMasini_Memorie()
        {
            Masini = new Masina[NR_MAX_MASINI];
            Nr_Masini = 0;
        }
        public void AddMasina(Masina Mn)
        {
            if (Mn == null) return;
            if (Nr_Masini >= NR_MAX_MASINI)
            {
                return;
            }
            Masini[Nr_Masini++] = Mn;
        }

        public Masina[] GetMasini()
        {
            return (Masina[])Masini.Clone();
        }
        public Masina GetMasina(int Id)
        {
            foreach (Masina Mn in Masini)
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
            return Nr_Masini-1;
        }
    }
}