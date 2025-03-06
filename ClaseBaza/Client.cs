using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseBaza
{
    public class Client
    {
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Email { get; set; }
        public string Nr_Telefon { get; set; }
        public int Perioada { get; set; } // Perioada de timp pentru care clientul va inchiria masina.
        public Masina Vehicul_Inchiriat { get; set; }

        public Client(string Nume = "", string Prenume = "", string Email = "", string Nr_Telefon = "", int Perioada = 0, Masina Vehicul_Inchiriat = null)
        {
            this.Nume = Nume;
            this.Prenume = Prenume;
            this.Email = Email;
            this.Nr_Telefon = Nr_Telefon;
            this.Perioada = Perioada;
            this.Vehicul_Inchiriat = Vehicul_Inchiriat;
            if (this.Vehicul_Inchiriat != null) this.Vehicul_Inchiriat.Stoc--;
        }
        public int PretFinal()
        {
            if (Perioada > 0 && Vehicul_Inchiriat.Taxa > 0) return Perioada * Vehicul_Inchiriat.Taxa;
            return -1; // In cazul valorilor invalide, va returna -1.
        }
        public string DetaliiClient()
        {
            return $"\nNUME: {Nume}\n" +
                    $"Prenume: {Prenume}\n" +
                    $"Email: {Email}\n" +
                    $"Nr_Telefon: {Nr_Telefon}\n" +
                    $"Perioada chirie: {Perioada} zile\n" +
                    $"Vehicul inchiriat: {Vehicul_Inchiriat.Model}\n\n";
        }
    }
}
