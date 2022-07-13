using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProstyBank
{
    class BankAccount
    {
        private Loan credit;
        private List<Transaction> AllTransactions = new List<Transaction>();
        private static UInt32 accountNumberSeed = 23232323;
        public UInt32 Number { get; }
        public string Owner { get; set; }
        private decimal balance;


        public decimal Balance
        {
            get
            {
                decimal transactionSum = 0;
                foreach (var transaction in AllTransactions)
                {
                    transactionSum += transaction.Amount;
                }
                return transactionSum + balance;
            }
            set { balance = value; }
        }

        public BankAccount(string name, decimal initialBalance)
        {
            this.Owner = name;
            this.Balance = initialBalance;
            this.Number = accountNumberSeed++;
            Console.WriteLine($"\nGratulacje! Utworzono nowe konto z saldem: {initialBalance}");
        }

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            Console.WriteLine($"\nDokonano wpłaty o kwocie: {amount}");
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Nie można wpłacić kwoty ujemnej");
            }
            Transaction deposit = new Transaction(amount, date, note);
            AllTransactions.Add(deposit);

        }

        public void MakeWithdraw(decimal amount, DateTime date, string note)
        {
            Console.WriteLine($"\nDokonano wypłaty o kwocie: {amount}");
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), " Nie można wypłacić kwoty ");
            }

            Transaction withdraw = new Transaction(amount, date, note);
            AllTransactions.Add(withdraw);

        }

        public void MakeRepayment(decimal amount, DateTime date, string note)
        {

            if (amount <= 0 || amount > Loan.Sum)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Błędna kwota!");
            }
            MakeWithdraw(amount, date, note);
            Loan.Sum = Loan.Sum - amount;
        }

        public void MakeLoan(decimal amount, DateTime date, string note)
        {

            if (amount <= 0 || amount > 1000)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Błędna kwota!");
            }

            this.credit = new Loan(amount);
            MakeDeposit(amount, date, note);

        }



        public void ListTransactionHistory()
        {
            Console.WriteLine("Historia:");
            foreach (Transaction x in AllTransactions)
            {
                Console.WriteLine($"Kwota:  {x.Amount}");
                Console.WriteLine($"Data: {x.Date}");
                Console.WriteLine($"Notatka: {x.Note}");
            }
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Imie Nazwisko: {Owner}");
            Console.WriteLine($"Numer konta: {Number}");
            Console.WriteLine($"Saldo: {Balance}");
            Console.WriteLine($"Kredyt : {Loan.Sum}");
        }

    }
}