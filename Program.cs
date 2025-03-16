using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClaseBaza;
using Administrator;

namespace InchirieriAuto
{
    class Program
    {
        static void Main(string[] args)
        {
            string Optiune, Nume, Prenume, Info;
            int Index;
            Client Client_Nou = null, Client_Gasit = null;
            Masina Masina_Noua = null;

            string FisierClienti = ConfigurationManager.AppSettings["FisierClienti"];
            string FisiserMasini = ConfigurationManager.AppSettings["FisierMasini"];
            string LastId = ConfigurationManager.AppSettings["LastId"];

            AdministratorClienti_FisierText AdminClienti = new AdministratorClienti_FisierText(FisierClienti);            
            AdministratorMasini_FisierText AdminMasini = new AdministratorMasini_FisierText(FisiserMasini);
            
            do {
                
                AfiseazaMeniu();
                Optiune = Console.ReadLine().ToUpper();
                
                switch(Optiune)
                {
                    case "M":
                        Masina_Noua = CitireMasinaConsola();
                        break;
                    case "D":
                        AdminMasini.AddMasinaFisier(Masina_Noua);
                        break;
                    case "C":
                        Console.WriteLine("Alegeti masina dupa Id:");
                        AdminMasini.GetMasiniFisier();
                        Index = int.Parse(Console.ReadLine());
                        if(Index < 0 || Index > AdminMasini.GetNrMasini())
                        {
                            Console.WriteLine("Id Invalid! Clientul nu va fi citit");
                            break;
                        }
                        Client_Nou = CitireClientConsola(AdminMasini.GetMasina(Index));
                        break;
                    case "S":
                        AdminClienti.AddClientFisier(Client_Nou);
                        break;
                    case "I":
                        AdminClienti.GetClientiFisier();
                        Console.WriteLine(AdminClienti.InfoClienti());
                        break;
                    case "K":
                        AdminMasini.GetMasiniFisier();
                        Console.WriteLine(AdminMasini.InfoMasini());
                        break;
                    case "R1":
                        Console.WriteLine("Introduceti numele:");
                        Nume = Console.ReadLine();
                        Console.WriteLine("Introduceti prenumele:");
                        Prenume = Console.ReadLine();
                        if( (Client_Gasit = AdminClienti.CautareClient(Nume, Prenume)) == null)
                        {
                            Console.WriteLine("Clientul nu a fost gasit");
                        }
                        else
                        {
                            Console.WriteLine(Client_Gasit.DetaliiClient());
                        }
                        break;
                    case "R2":
                        Console.WriteLine("Introduceti email-ul sau numar de telefon:");
                        Info = Console.ReadLine();
                        if ((Client_Gasit = AdminClienti.CautareClient(Info)) == null)
                        {
                            Console.WriteLine("Clientul nu a fost gasit");
                        }
                        else
                        {
                            Console.WriteLine(Client_Gasit.DetaliiClient());
                        }
                        break;
                    case "X":
                        AdminMasini.WriteLastId(); //Va memora ultimul Id inregistrat, pentru a evita repetarea Id-urilor. 
                        return;
                    default:
                        Console.WriteLine("Optiunea nu exista");
                        break;
                }
            } while (Optiune != "X");
        }
        public static void AfiseazaMeniu()
        {
            Console.WriteLine("M: Adauga masina.");
            Console.WriteLine("D: Salveaza masina in fisier.");
            Console.WriteLine("C: Adauga client.");
            Console.WriteLine("S: Salveaza client in fisier.");
            Console.WriteLine("I: Afiseaza clientii.");
            Console.WriteLine("K: Afiseasa catalog masini.");
            Console.WriteLine("R1: Cauta client dupa numele complet.");
            Console.WriteLine("R2: Cauta client dupa email sau numar de telefon.");
            Console.WriteLine("X: Exit.");
        }
        public static Masina CitireMasinaConsola()
        {
            string Model;
            int Taxa, Stoc, An;
            bool In_Stoc;
            
            Console.WriteLine("Introduceti modelul:");
            Model = Console.ReadLine();
            
            Console.WriteLine("Introduceti anul aparitiei:");
            An = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Introduceti taxa:");
            Taxa = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Introduceti stocul:");
            Stoc = int.Parse(Console.ReadLine());
            
            In_Stoc = Stoc > 0;
            
            return new Masina(Model, An, Taxa, Stoc, In_Stoc);
        }
        public static Client CitireClientConsola(Masina VehiculInchiriat)
        {
            string Nume, Prenume, Email, Nr_Telefon;
            int Perioada;

            Console.WriteLine("Introduceti numele:");
            Nume = Console.ReadLine();

            Console.WriteLine("Introduceti prenumele:");
            Prenume = Console.ReadLine();

            Console.WriteLine("Introduceti email-ul:");
            Email = Console.ReadLine();

            Console.WriteLine("Introduceti numarul de telefon:");
            Nr_Telefon = Console.ReadLine();
            
            Console.WriteLine("Introduceti perioada:");
            Perioada = int.Parse(Console.ReadLine());

            return new Client(Nume, Prenume, Email, Nr_Telefon, Perioada, VehiculInchiriat);
        }
    }
}
