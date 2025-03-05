using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseBaza
{
    public class Masina
    {
        public string Model { get; set; }
        public int An_aparitie { get; set; }
        public int Taxa { get; set; } // taxa pe zi
        public int Stoc { get; set; }
        public bool In_Stoc { get; set; }
        public Masina(string model = "", int an_aparitie = 0, int taxa = 0, int stoc = 0, bool in_Stoc = false)
        {
            this.Model = model;
            this.An_aparitie = an_aparitie;
            this.Taxa = taxa;
            this.Stoc = stoc;
            this.In_Stoc = in_Stoc;
        }
    }
}
