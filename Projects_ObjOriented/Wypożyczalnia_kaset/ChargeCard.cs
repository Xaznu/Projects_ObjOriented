namespace ConsoleApp30
{
    public class Karta
    {
        public decimal kwota;
        private readonly int kod;

        public Karta()
        {
            this.kod = 100;
            this.kwota = 1000;
        }

        public bool KartaAktywna(int kod1)
        {
            if (kod == kod1)
                return true;
            else return false;
        }
    }
}

