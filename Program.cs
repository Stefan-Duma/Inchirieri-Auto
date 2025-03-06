using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdministrareClienti;
using ClaseBaza;

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
            Admin Adm = new Admin();
            do {
                
                AfiseazaMeniu();
                Optiune = Console.ReadLine().ToUpper();
                
                switch(Optiune)
                {
                    case "M":
                        Masina_Noua = CitireMasinaConsola();
                        break;
                    case "D":
                        Adm.AddMasina(Masina_Noua);
                        break;
                    case "C":
                        Console.WriteLine("Alegeti masina dupa Id:");
                        Index = int.Parse(Console.ReadLine());
                        if(Index < 0 || Index > Adm.GetNrMasini())
                        {
                            Console.WriteLine("Id Invalid! Clientul nu va fi citit");
                            break;
                        }
                        Client_Nou = CitireClientConsola(Adm.GetMasina(Index));
                        break;
                    case "S":
                        Adm.AddClient(Client_Nou);
                        break;
                    case "I":
                        Console.WriteLine(Adm.InfoClienti());
                        break;
                    case "K":
                        Console.WriteLine(Adm.InfoMasini());
                        break;
                    case "R1":
                        Console.WriteLine("Introduceti numele:");
                        Nume = Console.ReadLine();
                        Console.WriteLine("Introduceti prenumele:");
                        Prenume = Console.ReadLine();
                        if( (Client_Gasit = Adm.CautareClient(Nume, Prenume)) == null)
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
                        if ((Client_Gasit = Adm.CautareClient(Info)) == null)
                        {
                            Console.WriteLine("Clientul nu a fost gasit");
                        }
                        else
                        {
                            Console.WriteLine(Client_Gasit.DetaliiClient());
                        }
                        break;
                    case "X":
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
            Console.WriteLine("D: Salveaza masina in vector de obiecte");
            Console.WriteLine("C: Adauga client.");
            Console.WriteLine("S: Salveaza client in vector de obiecte.");
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
