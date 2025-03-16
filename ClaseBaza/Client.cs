using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseBaza
{
    public class Client
    {
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';

        private const int NUME = 0;
        private const int PRENUME = 1;
        private const int EMAIL = 2;
        private const int NR_TELEFON = 3;
        private const int PERIOADA = 4;
        private const int ID_VEHICUL = 5;

        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Email { get; set; }
        public string Nr_Telefon { get; set; }
        public int Perioada { get; set; } // Perioada de timp pentru care clientul va inchiria masina.
        public int Id_Vehicul { get; set; }

        public Client(string Nume = "", string Prenume = "", string Email = "", string Nr_Telefon = "", int Perioada = 0, Masina Vehicul_Inchiriat = null)
        {
            this.Nume = Nume;
            this.Prenume = Prenume;
            this.Email = Email;
            this.Nr_Telefon = Nr_Telefon;
            this.Perioada = Perioada;
            this.Id_Vehicul = Vehicul_Inchiriat.Id;
            Vehicul_Inchiriat.Stoc--;
        }
        public Client(string LinieFisier)
        {
            string[] DateFisier = LinieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);
            Nume = DateFisier[NUME];
            Prenume = DateFisier[PRENUME];
            Email = DateFisier[EMAIL];
            Nr_Telefon = DateFisier[NR_TELEFON];
            Perioada = Int32.Parse(DateFisier[PERIOADA]);
            Id_Vehicul = Int32.Parse(DateFisier[ID_VEHICUL]);
        }

        public string DetaliiClient()
        {
            return $"\nNUME: {Nume}\n" +
                    $"Prenume: {Prenume}\n" +
                    $"Email: {Email}\n" +
                    $"Nr_Telefon: {Nr_Telefon}\n" +
                    $"Perioada chirie: {Perioada} zile\n" +
                    $"Id vehicul inchiriat: {Id_Vehicul}\n\n";
        }
        public string DetaliiClientFisier()
        {
            return string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}",
                SEPARATOR_PRINCIPAL_FISIER,
                (Nume ?? "NULL"),
                (Prenume ?? "NULL"),
                Email ?? "NULL",
                Nr_Telefon ?? "NULL",
                Perioada.ToString() ?? "NULL",
                Id_Vehicul.ToString() ?? "NULL"
                );
        }
    }
}
