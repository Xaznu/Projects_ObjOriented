using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie
{
    class Silnik : Interfejs
    {
        public Silnik()
        {
            waga = 0;
            mocSilnika = 0;
        }

        public Silnik(int w, int mS)
        {
            waga = w;
            mocSilnika = mS;
        }

        public void WyswietlSpecyfikacje()
        {
            Console.WriteLine($"Waga silnika to: {waga}");
            Console.WriteLine($"Moc silnika to: {mocSilnika}");
        }
    }
}
