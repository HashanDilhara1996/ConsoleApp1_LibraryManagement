using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1_LibraryManagement
{
    class LendingTransaction
    {
        public Book Book { get; set; }
        public Member Member { get; set; }
        public DateTime LendingDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public double CalculateFine()
        {
            // Implement fine calculation logic based on your requirements
            // Rs. 50 per additional day for up to 7 days
            // Rs. 100 per additional day after 7 days
            // You can calculate the fine here based on the lending and return dates.
            // Return the calculated fine amount.
            return 0; // Placeholder value; replace with actual calculation.
        }
    }

}
