using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie5
{
    class Program
    {
        static void Main(string[] args)
        {
            Interfejs i1 = new Interfejs("centropłat", 23500, 4, 2, 10);
            Interfejs i2 = new Interfejs("górnopłat", 50000, 6, 4, 200);
            Interfejs i3 = new Interfejs("centropłat", 30000, 5, 1, 100);
            Interfejs i4 = new Interfejs("dolnopłat", 12500, 7, 1, 25);
            Interfejs i5 = new Interfejs("dolnopłat", 17000, 8, 3, 60);
            Interfejs i6 = new Interfejs("górnopłat", 13000, 7, 6, 48);
            i1.WyswietlSpecyfikacje();
            Console.WriteLine("\n");
            i2.WyswietlSpecyfikacje();
            Console.WriteLine("\n");
            i3.WyswietlSpecyfikacje();
            Console.WriteLine("\n");
            i4.WyswietlSpecyfikacje();
            Console.WriteLine("\n");
            i5.WyswietlSpecyfikacje();
            Console.WriteLine("\n");
            i6.WyswietlSpecyfikacje();
            Console.WriteLine("\n");
            Samolot s1 = new Samolot("", "");
            s1.WyswietlSpecyfikacje();
            Console.ReadKey();

        }
    }
}
