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
            Client Alex = new Client("Alex", "alex01@gmail.com", "0742384552", 3, Audi);
            Console.Out.WriteLine(Alex.Detalii_client());

            Console.Out.WriteLine();

            Masina Dacia = new Masina("Duster", 2016, 150, 1);
            Alex.Perioada = 7;
            Alex.Vehicul_inchiriat = Dacia;
            Console.Out.WriteLine(Alex.Detalii_client());
        }
    }
}
