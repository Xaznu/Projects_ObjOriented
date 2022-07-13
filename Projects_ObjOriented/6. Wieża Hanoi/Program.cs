using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanoi2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(70, 22);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.Write("Wieże Hanoi\n-----------\nLiczba krążków (1-10): ");
            try
            {
                n = int.Parse(Console.ReadLine().Trim());
                if (n <= 0 || n > 10)
                    throw new Exception("Problem z liczbą krążków.");
                Console.Write("Zatrzymania (T/N): ");
                while ((stop = char.ToUpper(Console.ReadKey(true).KeyChar)) != 'T' && stop != 'N')
                    ;
                Console.WriteLine(stop);
                Start();
                Console.CursorVisible = false;
                Hanoi(n, 0, 1, 2);
                Wyczyść(DÓŁ + 2);
                Console.CursorVisible = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void Hanoi(int n, int a, int b, int c)
        {
            if (n > 1) Hanoi(n - 1, a, c, b);
            Przenieś(a, c);
            if (n > 1) Hanoi(n - 1, b, a, c);
        }

        static void Przenieś(int p, int q)
        {
            int kr = wieża[p].Pop();
            int x = 21 * p + 1;
            int y = DÓŁ - wieża[p].Count;
            while (y > GÓRA)
            {
                Console.SetCursorPosition(x, y--);
                Console.Write(krążek[0]);
                Console.SetCursorPosition(x, y);
                Console.ForegroundColor = kolor[kr];
                Console.Write(krążek[kr]);
                Console.ForegroundColor = kolor[0];
                System.Threading.Thread.Sleep(PRZESKOK);
            }
            Console.SetCursorPosition(x, y);
            Console.Write(krążek[0]);
            Console.SetCursorPosition(x = 21 * q + 1, y);
            Console.ForegroundColor = kolor[kr];
            Console.Write(krążek[kr]);
            Console.ForegroundColor = kolor[0];
            p = DÓŁ - wieża[q].Count;
            while (y < p)
            {
                System.Threading.Thread.Sleep(PRZESKOK);
                Console.SetCursorPosition(x, y++);
                Console.Write(krążek[0]);
                Console.SetCursorPosition(x, y);
                Console.ForegroundColor = kolor[kr];
                Console.Write(krążek[kr]);
                Console.ForegroundColor = kolor[0];
            }
            wieża[q].Push(kr);
            if (wieża[2].Count < n) Zatrzymanie(stop == 'T');
        }

        static void Start()
        {
            wieża = new Stack<int>[] { new Stack<int>(), new Stack<int>(), new Stack<int>() };
            krążek = new string[11];
            for (int k = 0; k <= 10; k++)
            {
                string s = new String(' ', 10 - k);
                krążek[k] = s + new String('\u2588', 2 * k + 1) + s;
            }
            Console.SetCursorPosition(0, GÓRA);
            for (int k = GÓRA; k <= DÓŁ; k++)
                Console.WriteLine(" {0}{1}{2}", krążek[0], krążek[0], krążek[0]);
            Console.Write(new String('\u2580', 3 * 21 + 2));
            for (int k = n; k > 0; k--)
            {
                wieża[0].Push(k);
                Console.SetCursorPosition(1, DÓŁ + k - n);
                Console.ForegroundColor = kolor[k];
                Console.Write(krążek[k]);
            }
            Console.ForegroundColor = kolor[0];
            Console.SetCursorPosition(0, DÓŁ + 2);
            Console.Write("Przerwanie wykonania programu: Esc");
            Zatrzymanie(true);
        }

        static void Wyczyść(int wiersz)
        {
            Console.SetCursorPosition(0, wiersz);
            Console.Write(new String(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, wiersz);
        }

        static void Koniec()
        {
            Wyczyść(DÓŁ + 3);
            Console.CursorVisible = true;
            Environment.Exit(2);
        }

        static void Zatrzymanie(bool klawisz)
        {
            if (klawisz)
            {
                Console.SetCursorPosition(0, DÓŁ + 3);
                Console.Write("Naciśnij dowolny klawisz...");
                if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                    Koniec();
                Wyczyść(DÓŁ + 3);
            }
            else
            {
                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape)
                    Koniec();
                System.Threading.Thread.Sleep(PRZERWA);
            }
        }

        const int GÓRA = 6;                 // Górny wiersz (wierzchołek palika)
        const int DÓŁ = 16;                 // Dolny wiersz (podstawa palika)
        const int PRZERWA = 1000;           // Przerwa między przesunięciami krążka (ms)
        const int PRZESKOK = 30;            // Przeskok krążka między wierszami (ms)

        static int n;                       // Liczba krążków
        static char stop;                   // T - zatrzymania, N - nie
        static Stack<int>[] wieża;          // Paliki z wieżami
        static string[] krążek;             // Fragment palika (0) i krążki (1-10)

        static readonly ConsoleColor[] kolor = { // Kolory palika (0) i krążków (1-10)
            ConsoleColor.Black, ConsoleColor.Magenta, ConsoleColor.Green, ConsoleColor.Red,
            ConsoleColor.Blue, ConsoleColor.Cyan, ConsoleColor.DarkYellow, ConsoleColor.Green,
            ConsoleColor.Red, ConsoleColor.Cyan, ConsoleColor.Magenta };
    }
}