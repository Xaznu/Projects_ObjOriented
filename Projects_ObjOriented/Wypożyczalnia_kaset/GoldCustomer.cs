using ConsoleApp30;
using System;

public class GoldCustomer : Customer, Irabat
{
    public override decimal rabatvalue
    {
        get
        {
            decimal x = CustomerBasket.BasketValue * 10 / 100;
            return x;
        }
        set { }
    }


    public GoldCustomer(string login, string name, string lastname) : base(login, name, lastname)
    {
        this.login = login;
        this.name = name;
        this.lastname = lastname;
    }

    public override void DokonajZakupu()
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
                $"\n Zaoszczędzono dzięki rabatowi dla użytkownika VIP: {rabatvalue}zł. " +
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
            Console.Clear();
            Console.WriteLine("Nie masz wystarczających sródków.");
        }
        Console.Clear();
        Console.WriteLine("Twój koszyk jest pusty!");
    }

    public override void DokonajWynajmu()
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
                $"\n Zaoszczędzono dzięki rabatowi użytkownika VIP: {rabatvalue}zł. " +
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




}



