using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProstyBank
{
    class Loan
    {
        private decimal credit;
        internal static decimal Sum;

        public decimal Credit
        {
            get { return credit; }
            set { credit = value; }
        }
        public Loan(decimal loan)
        {
            this.Credit = loan;
        }

    }
}