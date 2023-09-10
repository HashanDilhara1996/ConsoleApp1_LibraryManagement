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
        public string BookISBN { get; set; }
        public string BookTitle { get; set; }
        public string MemberName { get; set; }

        public double CalculateFine()
        {
            return 0;//Change this with the logic
        }

        public static void ViewLendingInformation(List<Transactions> transactions)
        {
            Console.WriteLine("Lending Information:");
            foreach (var transaction in transactions)
            {
                Console.WriteLine($"Book: {transaction.Book.Title}");
                Console.WriteLine($"Member: {transaction.Member.Name}");
                Console.WriteLine($"Lending Date: {transaction.LendingDate}");
                Console.WriteLine($"Return Date: {transaction.ReturnDate}");
                Console.WriteLine();
                Console.WriteLine("========================================================================================");
            }
        }
    }

}
