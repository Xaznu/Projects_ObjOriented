using System;
using System.Collections.Generic;

namespace ConsoleApp30
{


    public class Db
    {
        public List<Item> ListaWszystkichFIlmów;
        public List<Customer> ListaWszystkichUzytkowników;

        public Db()
        {
            this.ListaWszystkichFIlmów = new();
            this.ListaWszystkichUzytkowników = new();
        }

        public void DodajFilmDoBazyDanych(Item i)
        {
            ListaWszystkichFIlmów.Add(i);
        }



        public Customer RejestracjaUzytkownika()
        {
            Console.WriteLine("Witaj w panelu rejestracyjnym! \n Podaj imię: ");
            string c = Console.ReadLine();
            Console.WriteLine("Podaj nazwisko: ");
            string lastname = Console.ReadLine();
            Console.WriteLine("Podaj login: ");
            string login = Console.ReadLine();
            Customer new_customer = new Customer(login, c, lastname);
            Console.WriteLine("Rejestracja przebiegła pomyślnie! Witamy w gronie użytkowników");
            ListaWszystkichUzytkowników.Add(new_customer);
            return new_customer;
        }



        public void WyświetlWszystkieFilmy()
        {
            foreach (var item in ListaWszystkichFIlmów)
            {
                Console.WriteLine($"\n Tytuł: {item.title} Typ: {item.type}  Kategoria: {item.cat}  Czas trwania:{item.CzasTrwaniawMinutach}min. Cena: {item.Price}zł.");
            }
        }

    }

    public enum ProductType
    {
        DVD,
        Kaseta
    }
    public enum MovieCategory
    {
        Akcja,
        Dokument,
        Horror,
        Obyczajowy
    }

    public class Item : Db
    {
        public string title { get; set; }
        public decimal Price { get; set; }
        public TimeSpan czastrwania { get; set; }
        public MovieCategory cat { get; set; }
        public ProductType type { get; set; }


        public double CzasTrwaniawMinutach

        {
            get
            {
                double c = czastrwania.TotalMinutes;
                return Math.Round(c);
            }
            set { }
        }


        public Item(string t, decimal d, TimeSpan timespan, ProductType typ, MovieCategory cat)
        {
            this.title = t;
            this.Price = d;
            czastrwania = timespan;
            this.type = typ;
            this.cat = cat;






        }




    }

}






