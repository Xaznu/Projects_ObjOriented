namespace Zadanie_4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Pracownik> lista = new List<Pracownik>();
            lista.Add(new Sekretarka());
            lista.Add(new Ochroniarz());
            lista.Add(new Ksiegowy());

            foreach (var i in lista)
            {
                i.Pracuj();
            }

            Console.ReadKey();
        }
    }
}