using System;

namespace ProstyBank
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                playWithAccount();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Coś poszło nie tak: {e.Message}");
                Console.ReadKey();
            }

        }
        static public void playWithAccount()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Witaj! Załóż nowe konto.");
            Console.WriteLine("\nProszę wpisać Pan/i imię:");
            var name = Console.ReadLine();
            Console.WriteLine("\nW jakiej wysokości będzie wpłata?");
            int balance = int.Parse(Console.ReadLine());
            var Account = new BankAccount(name, balance);
            string ABC;
            Console.ResetColor();

            do
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine($"\n1. Wpłać:  \n2. Wypłać:  \n3. Historia: \n4. Konto: \n5. Weź kredyt: \n6. Wpłacić ratę kredytu: ");
                string Menu = Console.ReadLine();
                DateTime date = DateTime.Today;
                Console.ResetColor();
                switch (Menu)
                {
                    case "1":
                        Console.WriteLine("Podaj kwote");
                        int DepositAmount = int.Parse(Console.ReadLine());
                        string note = "Wpłata";
                        Account.MakeDeposit(DepositAmount, date, note);
                        break;
                    case "2":
                        Console.WriteLine("Podaj kwote");
                        int WithdrawAmount = int.Parse(Console.ReadLine());
                        string note1 = "";
                        Account.MakeWithdraw(WithdrawAmount, date, note1);
                        break;
                    case "3":
                        Account.ListTransactionHistory();
                        break;
                    case "4":
                        Account.DisplayInfo();
                        break;
                    case "5":
                        Console.WriteLine("Podaj kwote");
                        int credit = int.Parse(Console.ReadLine());
                        string note2 = "";
                        Account.MakeLoan(credit, date, note2);
                        break;
                    case "6":
                        Console.WriteLine("Podaj kwote");
                        int repayment = int.Parse(Console.ReadLine());
                        string note3 = "";
                        Account.MakeRepayment(repayment, date, note3);
                        break;
                    default:
                        Console.WriteLine("");
                        break;
                }
                Console.WriteLine("Czy kontynuować? Y/N");
                ABC = Console.ReadLine();
                Console.Clear();
            } while (ABC == "Y");

            Console.ReadKey();
        }


    }
}
