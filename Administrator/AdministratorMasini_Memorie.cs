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
        protected List<Masina> Masini;
        public AdministratorMasini_Memorie()
        {
            Masini = new List<Masina>();
        }
        public void AddMasina(Masina Mn)
        {
            if (Mn == null) return;
            Masini.Add(Mn);
        }

        public List<Masina> GetMasini()
        {
            return Masini;
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
    }
}