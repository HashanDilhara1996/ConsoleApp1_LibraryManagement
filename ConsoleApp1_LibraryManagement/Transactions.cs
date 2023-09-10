using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1_LibraryManagement
{
    class Transactions
    {
        public Book Book { get; set; }
        public Member Member { get; set; }
        public DateTime LendingDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public double CalculateFine()
        {
            return 0;//Change this with the logic
        }
    }

}
