using System;
using System.Collections.Generic;
using System.Linq;


namespace ConsoleApp30
{
    class Program
    {
        static void Main(string[] args)
        {

            Db BazaDanych = new Db();


            var x = new Item("Milczenie owiec", 15, new TimeSpan(1, 30, 5), ProductType.DVD, MovieCategory.Dokument);
            var x1 = new Item("Przemineło z Wiatrem", 10, new TimeSpan(1, 32, 5), ProductType.Kaseta, MovieCategory.Obyczajowy);
            var x2 = new Item("Góry i doły", 13, new TimeSpan(5, 3, 5), ProductType.DVD, MovieCategory.Dokument);
            var x3 = new Item("Projekt zaliczeniowy - zdamy, czy nie zdamy?", 14, new TimeSpan(1, 30, 5), ProductType.Kaseta, MovieCategory.Akcja);
            var x4 = new Item("Terminator", 18, new TimeSpan(1, 50, 5), ProductType.DVD, MovieCategory.Akcja);

            BazaDanych.DodajFilmDoBazyDanych(x);
            BazaDanych.DodajFilmDoBazyDanych(x1);
            BazaDanych.DodajFilmDoBazyDanych(x2);
            BazaDanych.DodajFilmDoBazyDanych(x3);
            BazaDanych.DodajFilmDoBazyDanych(x4);


            Karta karta1 = new Karta();
            var new_goldcustomer = new GoldCustomer("Andrzej12", "Andrzej", "Kowalski");

            Karta karta = new();

            do
            {
                Console.Clear();
                Console.WriteLine("\t Witaj w naszej wypożyczalni!");
                Console.WriteLine("Co chcesz zrobić? Naciśnij odpowiedni klawisz. \nLegenda:");
                Console.WriteLine("Q - Wyświetl listę dostępnych filmów. ");
                Console.WriteLine("W - Aby doładować środki pieniężne do swojego konta.");
                Console.WriteLine("E - Wyszukaj produkt.");
                Console.WriteLine("R - Wyświetl zawartość koszyka.");
                Console.WriteLine("T - Dokonaj zakupu: ");
                Console.WriteLine("Y - Dokonaj wynajmu: ");
                Console.WriteLine("U - Pokaż historie transakcji. ");
                Console.WriteLine("I - Pokaż wypożyczone filmy oraz ich pozostały czas. ");
                Console.WriteLine("O - Pokaż dostępne środki pieniężne.");

                var keyInfo = Console.ReadKey();


                switch (keyInfo.Key)
                {


                    case ConsoleKey.Q:
                        Console.Clear();
                        BazaDanych.WyświetlWszystkieFilmy();
                        Console.WriteLine("\nWciśnij dowolny przycisk, aby kontynuować...");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case ConsoleKey.W:
                        Console.Clear();
                        Console.WriteLine("Wprowadź unikalny kod, znajdujący się na karcie: ");

                        string input = Console.ReadLine();
                        int number;
                        if (!Int32.TryParse(input, out number))
                        {
                            Console.WriteLine("Błędny kod.");
                        }

                        new_goldcustomer.DoładujŚrodki(karta1, number);
                        Console.WriteLine("Wciśnij dowolny przycisk, aby kontynuować...");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case ConsoleKey.E:
                        Console.Clear();
                        Console.WriteLine("\n Wprowadź tytuł: ");
                        string input_title = Console.ReadLine();


                        var get = BazaDanych.ListaWszystkichFIlmów.FirstOrDefault(x => x.title == input_title);
                        if (get != null)
                        {
                            Console.WriteLine($"\nZnaleziono {get.title}. \nCena: {get.Price}\nTyp: {get.cat}" +
                            $"\nRodzaj nośnika: {get.type}\n Czy chcesz dodać produkt do koszyka Y/N?");
                            ConsoleKeyInfo Decyzja = Console.ReadKey();
                            if (Decyzja.Key == ConsoleKey.Y)
                            {
                                new_goldcustomer.CustomerBasket.AddToBasket(get);
                                Console.WriteLine($"Dodałeś produkt {get.title} do koszyka");
                                Console.ReadKey();
                            }
                            else if (Decyzja.Key == ConsoleKey.N)
                            {
                                Console.WriteLine("Produkt nie został dodany do koszyka. wciśnij dowolny przycisk, aby kontynuować...");
                                Console.ReadKey();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nie znaleziono filmu o podanym tytule.Proszę wciśnij dowolny przycisk, aby kontynuować...");
                            Console.ReadKey();
                        }
                        Console.Clear();
                        break;

                    case ConsoleKey.R:
                        Console.Clear();
                        new_goldcustomer.ZawartośćKoszyka();
                        Console.WriteLine("Wciśnij dowolny przycisk, aby kontynuować...");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case ConsoleKey.T:

                        new_goldcustomer.DokonajZakupu();
                        Console.WriteLine("Wciśnij dowolny przycisk, aby kontynuować...");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case ConsoleKey.Y:
                        new_goldcustomer.DokonajWynajmu();
                        Console.WriteLine("Wciśnij dowolny przycisk, aby kontynuować...");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case ConsoleKey.U:
                        Console.Clear();
                        new_goldcustomer.PokażHistorieZakupów();
                        Console.WriteLine("Wciśnij dowolny przycisk, aby kontynuować...");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case ConsoleKey.I:
                        Console.Clear();
                        new_goldcustomer.PokażWypożyczoneilmy();
                        Console.WriteLine("Wciśnij dowolny przycisk, aby kontynuować...");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case ConsoleKey.O:
                        Console.Clear();
                        new_goldcustomer.PokażStanPortfela();
                        Console.WriteLine("Wciśnij dowolny przycisk, aby kontynuować...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            } while (true);

        }
    }

}



