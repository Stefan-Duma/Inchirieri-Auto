using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace InchirieriAuto
{
    public class Masina
    {
        public string Model { get; set; }
        public int An_aparitie { get; set; }
        public int Taxa { get; set; } // taxa pe zi
        public int Stoc { get; set; }


        public Masina(string model = "", int an_aparitie = 0, int taxa = 0, int stoc = 0)
        {
            this.Model = model;
            this.An_aparitie = an_aparitie;
            this.Taxa = taxa;
            this.Stoc = stoc;
        }
        public bool In_stoc()
        {
            return Stoc > 0;
        }
    }
}
