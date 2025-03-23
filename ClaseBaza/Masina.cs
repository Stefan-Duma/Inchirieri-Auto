using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseBaza
{
    public class Masina
    {
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';

        private const int ID = 0;
        private const int MODEL = 1;
        private const int AN_APARITIE = 2;
        private const int TAXA = 3;
        private const int STOC = 4;
        private const int IN_STOC = 5;
        private const int CULOARE = 6;
        private const int OPTIUNI = 7;

        public static int Next_Id = 0;
        
        public string Model { get; set; }
        public int An_Aparitie { get; set; }
        public int Id { get; set; }
        public int Taxa { get; set; } // taxa pe zi
        public int Stoc { get; set; }
        public bool In_Stoc { get; set; }
        public Culoare Culoare_Masina { get; set; }
        public Optiuni Optiuni_Masina { get; set; }
        public Masina(string Model = "", int An_Aparitie = 0, int Taxa = 0, int Stoc = 0, bool In_Stoc = false,
                      Culoare Culoare_Masina = Culoare.Alb, Optiuni Optiuni_Masina = Optiuni.AerConditionat)
        {
            this.Id = Next_Id++;
            this.Model = Model;
            this.An_Aparitie = An_Aparitie;
            this.Taxa = Taxa;
            this.Stoc = Stoc;
            this.In_Stoc = In_Stoc;
            this.Culoare_Masina = Culoare_Masina;
            this.Optiuni_Masina = Optiuni_Masina;
        }

        public Masina(string LinieFisier)
        {
            string[] DateFisier = LinieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);

            Id = Int32.Parse(DateFisier[ID]);
            Model = DateFisier[MODEL];
            An_Aparitie = Int32.Parse(DateFisier[AN_APARITIE]);
            Taxa = Int32.Parse(DateFisier[TAXA]);
            Stoc = Int32.Parse(DateFisier[STOC]);
            In_Stoc = bool.Parse(DateFisier[IN_STOC]);
            Culoare_Masina = (Culoare)Enum.Parse(typeof(Culoare), DateFisier[CULOARE]);
            Optiuni_Masina = (Optiuni)Enum.Parse(typeof(Optiuni), DateFisier[OPTIUNI]);
        }
        public string DetaliiMasina()
        {
            string Mesaj_Stoc = Stoc > 0 ? "Da" : "Nu";
            string optiuni_masina = "";
            foreach (Optiuni optiune in Enum.GetValues(typeof(Optiuni)))
            {
                if (Optiuni_Masina.HasFlag(optiune)) optiuni_masina += $"{optiune}, ";
            }
                return $"\nModel masina: {Model}\n" +
                $"An aparitie: {An_Aparitie}\n" +
                $"Taxa: {Taxa} RON\n" +
                $"Stoc: {Stoc}\n" +
                $"In stoc: {Mesaj_Stoc}\n" +
                $"Id: {Id}\n" +
                $"Culoare: {Culoare_Masina}\n" +
                $"Optiuni: {optiuni_masina}\b\b.\n\n";
        }
        public string DetaliiMasinaFisier()
        {
            return string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}{0}{8}{0}",
                SEPARATOR_PRINCIPAL_FISIER,
                Id.ToString() ?? "NULL",
                Model ?? "NULL",
                An_Aparitie.ToString() ?? "NULL",
                Taxa.ToString() ?? "NULL",
                Stoc.ToString() ?? "NULL",
                In_Stoc.ToString() ?? "NULL",
                Culoare_Masina.ToString() ?? "NULL",
                Optiuni_Masina.ToString() ?? "NULL");

        }
    }
}
