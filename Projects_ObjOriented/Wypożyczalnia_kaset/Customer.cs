using System;
using System.Collections.Generic;

namespace ConsoleApp30
{
    public class Customer : Irabat
    {
        public string login { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        private int client_id;
        public Dictionary<DateTime, Item> BazaWypozyczonychFilmów;
        public readonly DateTime datazalozeniakonta;
        public List<Transakcja> lista_transakcji;
        public Basket CustomerBasket;
        public decimal Balance { get; set; }

        public DateTime KoniecWynajmu
        {
            get
            {
                DateTime x = DateTime.Now;
                return x;
            }
            set
            {
                DateTime x = DateTime.Now;
                if (BazaWypozyczonychFilmów.TryGetValue(x, out Item values))
                {
                    BazaWypozyczonychFilmów.Remove(x);
                }

            }
        }

        public virtual decimal rabatvalue
        {
            get
            {
                DateTime convert_to_DateTime = new DateTime().Add(staz);
                var Discount_exeption = datazalozeniakonta.AddDays(7);

                if (convert_to_DateTime <= Discount_exeption)
                    return CustomerBasket.BasketValue * 5 / 100;
                else return 0;
            }
            set { }
        }


        public int Client_Id
        {
            get
            {
                return new Random().Next();
            }
            set
            {
                client_id = value;
            }
        }


        public TimeSpan staz
        {
            get
            {
                TimeSpan x = DateTime.Now - datazalozeniakonta;
                return x;
            }
            private set { }
        }

        public Customer(string login, string name, string lastname)
        {
            this.login = login;
            this.name = name;
            this.lastname = lastname;
            CustomerBasket = new();
            datazalozeniakonta = DateTime.Now;
            BazaWypozyczonychFilmów = new Dictionary<DateTime, Item>();
            this.lista_transakcji = new();




        }
        public virtual void DokonajZakupu()
        {
            if (Balance >= CustomerBasket.BasketValue && CustomerBasket.ItemsInBasket.Count != 0)
            {
                decimal kwota = 0;
                foreach (var item in CustomerBasket.ItemsInBasket)
                {
                    kwota += item.Price;

                }
                kwota = kwota - rabatvalue;
                int nr_zamowienia = new Random().Next();
                Balance -= kwota;

                Console.WriteLine($"\n\t\t Dokonałeś zakupu!\n  \t\n Kwota zamówienia: {kwota + rabatvalue}zł. " +
                    $"\n Zaoszczędzono dzięki rabatowi: {rabatvalue}zł. " +
                    $"\n Całkowita kwota do zapłaty: {kwota}zł.\n Na koncie pozostało {Balance}zł. " +
                    $"\n Twój numer zamówienia: {nr_zamowienia}" +
                    $"\n Proszę zgłoś się z numerem zamówienia do najbliższego punktu naszej sieci.");
                Console.ReadKey();

                var nowa_transakcja = new Transakcja(kwota, nr_zamowienia);
                lista_transakcji.Add(nowa_transakcja);
                CustomerBasket.ItemsInBasket.Clear();
            }
            else if (Balance < CustomerBasket.BasketValue)


            {

                Console.WriteLine("Nie masz wystarczających sródków.");

            }
            Console.WriteLine("Twój koszyk jest pusty!");




        }


        public virtual void DokonajWynajmu()
        {
            if (Balance >= CustomerBasket.BasketValue && CustomerBasket.ItemsInBasket.Count != 0 && CustomerBasket.ItemCount != 0)
            {
                decimal kwota = 0;
                foreach (var item in CustomerBasket.ItemsInBasket)
                {
                    kwota += item.Price;

                }
                kwota = kwota - rabatvalue;
                int nr_zamowienia = new Random().Next();
                Balance -= kwota;

                Console.WriteLine($"\n\t\t Dokonałeś wynajmu!\n  \t\n Kwota zamówienia: {kwota + rabatvalue}zł. " +
                    $"\n Zaoszczędzono dzięki rabatowi: {rabatvalue}zł. " +
                    $"\n Całkowita kwota do zapłaty: {kwota}zł.\n Na koncie pozostało {Balance}zł. " +
                    $"\n Twój numer zamówienia: {nr_zamowienia}" +
                    $"\n Proszę zgłoś się z numerem zamówienia do najbliższego punktu naszej sieci.");

                var nowa_transakcja = new Transakcja(kwota, nr_zamowienia);

                var CzasTrwaniaWynajmu = DateTime.Now.AddDays(7) - DateTime.Now;
                DateTime CzasTrwaniaWynajmuConvert = new DateTime().Add(CzasTrwaniaWynajmu);

                foreach (var item in CustomerBasket.ItemsInBasket)
                {
                    BazaWypozyczonychFilmów.Add(CzasTrwaniaWynajmuConvert, item);


                }
                lista_transakcji.Add(nowa_transakcja);
                CustomerBasket.ItemsInBasket.Clear();


            }
            else if (Balance < CustomerBasket.BasketValue)
            {
                Console.Clear();
                Console.WriteLine("Nie masz wystarczających sródków.");
            }
            Console.Clear();
            Console.WriteLine("Twój koszyk jest pusty!");
        }

        public void PokażStanPortfela()
        {
            Console.WriteLine($"Twój budżet wynosi: {Balance}zł.");
        }

        public void PokażWypożyczoneilmy()
        {
            if (BazaWypozyczonychFilmów.Count != 0)
            {
                Console.WriteLine("\n \t Twoja lista wypożyczonych filmów:");
                foreach (var item in BazaWypozyczonychFilmów)
                {
                    Console.WriteLine($"\n Tytuł: {item.Value.title} \t Pozostały czas: {item.Key.Day}dni.");
                }
            }
            else
                Console.WriteLine("Na tym koncie nie wypożyczono dotychczas żadnych filmów.");
        }

        public void PokażHistorieZakupów()
        {
            if (lista_transakcji.Count != 0)
            {
                Console.WriteLine("\n\tHistoria zakupów: ");
                foreach (var item in lista_transakcji)
                {
                    Console.WriteLine($"\t Data: {item.DataZakupu} Nr Zamówienia: {item.numer_zamówienia}\n");
                }
            }
            else
                Console.WriteLine("\nNa tym koncie nie dokonano żadnych zakupów.");
        }



        public void ZawartośćKoszyka()
        {
            foreach (var item in CustomerBasket.ItemsInBasket)
            {
                Console.WriteLine("\n\t\tZawartość koszyka: ");
                Console.WriteLine($"Produkt: {item.title} Cena: {item.Price} Typ: {item.type} Kategoria: {item.cat} Czas trwania:{item.CzasTrwaniawMinutach}min.");
            }
            if (rabatvalue > 0)
                Console.WriteLine($"\n ilość produktów: {CustomerBasket.ItemCount}\n łączna kwota: {CustomerBasket.BasketValue} zł" +
                    $"\n Wysokość rabatu: {rabatvalue}zł. \n Uwzględniając rabat: {CustomerBasket.BasketValue - rabatvalue}zł ");
            else
                Console.WriteLine($"\n ilość produktów: {CustomerBasket.ItemCount}\n łączna kwota: {CustomerBasket.BasketValue} zł");
        }


        public void DoładujŚrodki(Karta karta1, int kod)
        {
            if (karta1.KartaAktywna(kod))
            {
                Balance += karta1.kwota;
                Console.WriteLine($"Dodałeś do swojego konta środki w wysokości: {karta1.kwota} zł.");
            }
            else Console.WriteLine("Kod doładowywujący jest błędny.");
        }




    }
}


