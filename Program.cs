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
            Masina Audi = new Masina("Audi A3", 2012, 120, 3);
            Masina Dacia = new Masina("Dacia Duster", 2016, 150, 1);
            Client Ion = new Client("Georgescu", "Ion", "Ion01@gmail.com", "0742384552", 3, Audi);
            Client Florin = new Client("Amariei", "Florin", "Florin@gmail.com", "0745263788", 7, Audi);
            Admin Adm = new Admin();
            
            /*
            Client[] temp = new Client[2];
            temp[0] = Ion;
            temp[1] = Florin;
            adm.AddClient(temp);
            */

            Ion.Perioada = 10;
            Ion.Vehicul_inchiriat = Dacia;

            Adm.AddClient(Ion);
            Adm.AddClient(Florin);

            Console.WriteLine(Adm.InfoClienti());

            Console.WriteLine("Clientul cu numele Georgescu Ion:");
            Console.WriteLine((Adm.CautareClient("Georgescu", "Ion")).Detalii_client());
        }
    }
}
