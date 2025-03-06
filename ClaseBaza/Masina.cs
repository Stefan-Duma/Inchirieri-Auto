using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseBaza
{
    public class Masina
    {
        public static int Next_Id = 0;
        
        public string Model { get; set; }
        public int An_Aparitie { get; set; }
        public int Id { get; set; }
        public int Taxa { get; set; } // taxa pe zi
        public int Stoc { get; set; }
        public bool In_Stoc { get; set; }
        public Masina(string Model = "", int An_Aparitie = 0, int Taxa = 0, int Stoc = 0, bool In_Stoc = false)
        {
            this.Model = Model;
            this.An_Aparitie = An_Aparitie;
            this.Taxa = Taxa;
            this.Stoc = Stoc;
            this.In_Stoc = In_Stoc;
            this.Id = Next_Id++;

        }
        public string DetaliiMasina()
        {
            string Mesaj_Stoc = Stoc > 0 ? "Da" : "Nu";
            return $"\nModel masina: {Model}\n" +
                $"An aparitie: {An_Aparitie}\n" +
                $"Taxa: {Taxa} RON\n" +
                $"Stoc: {Stoc}\n" +
                $"In stoc: {Mesaj_Stoc}\n" +
                $"Id: {Id}\n\n";
        }
    }
}
