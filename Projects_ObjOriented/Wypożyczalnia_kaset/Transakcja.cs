
using System;
using System.Collections.Generic;

namespace ConsoleApp30
{
    public class Transakcja
    {
        public Customer customer;
        public DateTime DataZakupu;
        public decimal KwotaZamowienia;
        public int iloscproduktow;
        public List<Item> _listaprzedmiotów_zamówienia;
        public readonly int numer_zamówienia;



        public Transakcja(decimal kwotaZamowienia, int r)
        {

            this.KwotaZamowienia = kwotaZamowienia;
            this.DataZakupu = DateTime.Now;
            this._listaprzedmiotów_zamówienia = new();
            this.numer_zamówienia = r;

        }


        public void PokażPrzedmioty()
        {
            Console.WriteLine("Lista przedmiotów: ");
            foreach (var item in _listaprzedmiotów_zamówienia)
            {
                Console.WriteLine($"{item.title} {item.Price}, {item.type}, {item.czastrwania} ");
            }
        }



    }
}
