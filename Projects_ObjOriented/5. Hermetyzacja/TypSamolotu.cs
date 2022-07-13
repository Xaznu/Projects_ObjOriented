using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie5
{
    class Interfejs
    {
        protected string typUsterzenia;
        protected int wagaSamolotu;
        protected int silnikSamolotu;
        protected int ilośćSilników;
        protected int ilośćMiejsc;
        protected string rodzajeSamolotów;
        protected string największeSamoloty;

        public Interfejs()
        {
            typUsterzenia = "";
            wagaSamolotu = 0;
            silnikSamolotu = 0;
            ilośćSilników = 0;
            ilośćMiejsc = 0;
            rodzajeSamolotów = "";
            największeSamoloty = "";
        }

        public Interfejs(string tU, int kg, int cyl, int iS, int iM)
        {
            typUsterzenia = tU;
            wagaSamolotu = kg;
            silnikSamolotu = cyl;
            ilośćSilników = iS;
            ilośćMiejsc = iM;
        }

        public void WyswietlSpecyfikacje()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Rodzaj uskrzydlenia samolotu: {typUsterzenia}");
            Console.WriteLine($"Waga samolotu: {wagaSamolotu}");
            Console.WriteLine($"Moc silnika samolotu: {silnikSamolotu}");
            Console.WriteLine($"Ilość silników w samolocie: {ilośćSilników}");
            Console.WriteLine($"Ilość miejsc w samolocie: {ilośćMiejsc}");
        }
    }
}
