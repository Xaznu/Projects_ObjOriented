using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie
{
    class Auto
    {
        protected string kategoriaPojazdu;
        protected int waga;
        protected int pojemnosc;
        protected int mocSilnika;
        protected string kolor;
        protected int iloscOsi;

        public Auto(string kP, int w, int poj, int mS, string k, int ilOsi)
        {
            kategoriaPojazdu = kP;
            waga = w;
            pojemnosc = poj;
            mocSilnika = mS;
            kolor = k;
            iloscOsi = ilOsi;
        }

        public void WyswietlSpecyfikacje()
        {
            Console.WriteLine($"Kategoria pojazdu to: {kategoriaPojazdu}");
            Console.WriteLine($"Waga pojazdu to: {waga}");
            Console.WriteLine($"Pojemnosc pojazdu to: {pojemnosc}");
            Console.WriteLine($"Moc silnika pojazdu to: {mocSilnika}");
            Console.WriteLine($"Kolor pojazdu to: {kolor}");
            Console.WriteLine($"Ilosc osi pojazdu to: {iloscOsi}");
        }
    }
}
