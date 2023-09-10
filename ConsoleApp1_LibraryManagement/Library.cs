using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ConsoleApp1_LibraryManagement
{
    class Library
    {
        public List<Book> Books { get; } = new List<Book>();
        public List<Member> Members { get; } = new List<Member>();
        public List<Transactions> Transactions { get; set; } = new List<Transactions>();

        public void DisplayOverdueBooks()
        {
            Console.WriteLine("Overdue Books:");
            Console.WriteLine("ISBN\tTitle\tMember\tReturn Date");

            foreach (Transactions transaction in Transactions)
            {
                if (IsBookOverdue(transaction))
                {
                    Console.WriteLine($"{transaction.BookISBN}\t{transaction.BookTitle}\t{transaction.MemberName}\t{transaction.ReturnDate}");
                }
            }
        }

        private bool IsBookOverdue(Transactions transaction)
        {
            // Calculate the number of days the book is overdue
            TimeSpan overdueDuration = DateTime.Now - transaction.ReturnDate;
            int overdueDays = (int)overdueDuration.TotalDays;

            // Check if the book is overdue
            return overdueDays > 0;
        }

        public void RemoveBookByISBN(string isbn)
        {
            Book bookToRemove = Books.FirstOrDefault(book => book.ISBN == isbn);

            if (bookToRemove != null)
            {
                Books.Remove(bookToRemove);
                Console.WriteLine($"Book '{bookToRemove.Title}' (ISBN: {bookToRemove.ISBN}) has been removed from the library.");
            }
            else
            {
                Console.WriteLine($"Book with ISBN '{isbn}' not found in the library.");
            }
        }

        public void RemoveMemberByID(int memberId)
        {
            Member memberToRemove = Members.FirstOrDefault(member => member.MemberID == memberId);

            if (memberToRemove != null)
            {
                Members.Remove(memberToRemove);
                Console.WriteLine($"Member '{memberToRemove.Name}' (ID: {memberToRemove.MemberID}) has been removed from the library's records.");
            }
            else
            {
                Console.WriteLine($"Member with ID '{memberId}' not found in the library's records.");
            }
        }
    }
}
