using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie
{
    class Program
    {
        static void Main(string[] args)
        {
            Auto sam = new Specyfikacja("Sportowe", 1200, 2000, 250, "Niebieski", 2);
            sam.WyswietlSpecyfikacje();

            Console.ReadLine();
        }
    }
}
