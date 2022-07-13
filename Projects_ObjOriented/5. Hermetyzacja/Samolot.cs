using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie5
{
    class Samolot : Interfejs
    {
        public Samolot()
        {
            rodzajeSamolotów = "";
            największeSamoloty = "";
        }

        public Samolot(string rS, string nS)
        {
            rodzajeSamolotów = "";
            największeSamoloty = "";
        }

        public void WyswietlSpecyfikacje()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"Rodzaje samolotów: pasażerskie, śmigłowe, towarowe, dwusilnikowe, akrobatyczne, myśliwce oraz helikoptery {rodzajeSamolotów}");
            Console.WriteLine($"Największe samoloty w historii: Antonow An-225, Airbus A380, Boeing 747-8 oraz Lockheed C-5 Galaxy {największeSamoloty}");
        }
    }
}
