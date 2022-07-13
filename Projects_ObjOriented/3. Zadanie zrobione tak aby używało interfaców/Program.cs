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
            Interfejs i1 = new Interfejs("Fiat", 1900, 105, 220, "Czarny", 2);
            Interfejs i2 = new Interfejs("Audi", 1700, 65, 205, "Biały", 2);
            Interfejs i3 = new Interfejs("Civic", 1000, 40, 184, "Różowy", 2);
            i1.WyswietlSpecyfikacje();
            Console.WriteLine("\n");
            i2.WyswietlSpecyfikacje();
            Console.WriteLine("\n");
            i3.WyswietlSpecyfikacje();
            Console.WriteLine("\n");
            Silnik s1 = new Silnik(1200, 140);
            Silnik s2 = new Silnik(1500, 170);
            Silnik s3 = new Silnik(1800, 215);
            s1.WyswietlSpecyfikacje();
            Console.WriteLine("\n");
            s2.WyswietlSpecyfikacje();
            Console.WriteLine("\n");
            s3.WyswietlSpecyfikacje();
            Console.ReadKey();
        }
    }
}
