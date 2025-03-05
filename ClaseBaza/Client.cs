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
        public string Nr_telefon { get; set; }
        public int Perioada { get; set; } // Perioada de timp pentru care clientul va inchiria masina.
        public Masina Vehicul_inchiriat { get; set; }

        public Client(string nume = "", string prenume = "", string email = "", string nr_telefon = "", int perioada = 0, Masina vehicul_inchiriat = null)
        {
            this.Nume = nume;
            this.Prenume = prenume;
            this.Email = email;
            this.Nr_telefon = nr_telefon;
            this.Perioada = perioada;
            this.Vehicul_inchiriat = vehicul_inchiriat;
            if (this.Vehicul_inchiriat != null) this.Vehicul_inchiriat.Stoc--;
        }
        public int Pret_final()
        {
            if (Perioada > 0 && Vehicul_inchiriat.Taxa > 0) return Perioada * Vehicul_inchiriat.Taxa;
            return -1; // In cazul valorilor invalide, va returna -1.
        }
        public string Detalii_client()
        {
            return $"Nume: {Nume}\nPrenume: {Prenume}\nEmail: {Email}\nTelefon: {Nr_telefon}\n" +
                   $"Perioada chirie: {Perioada} zile\nModel inchiriat: {Vehicul_inchiriat.Model}\n" +
                   $"Total de achitat: {Pret_final()} RON";
            ;
        }
    }
}
