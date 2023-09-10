using ConsoleApp1_LibraryManagement;
using System;
using System.Data.Common;
using System.Linq;
using System.Transactions;

class Program
{
    static void Main(string[] args)
    {
        Library library = new Library();

        // Call a method to add a new book
        Book.AddToLibrary(library.Books);

        // Display the list of books in the library
        Book.DisplayAllBooks(library.Books);

        // Register a new member
        Member.RegisterMember(library.Members);

        // Display the list of registered members
        Member.DisplayAllMembers(library.Members);

        // Search for book information by ISBN
        Console.Write("Enter ISBN of the book to search: ");
        string isbnToSearch = Console.ReadLine();
        Book book = Book.SearchByISBN(library.Books, isbnToSearch);
        Book.DisplayBookInformation(book);

        // Lend a book to a member (assuming Member with ID 1 exists)
        int memberIdToLendTo = 11;
        Member memberToLendTo = library.Members.FirstOrDefault(m => m.MemberID == memberIdToLendTo);
        if (memberToLendTo != null)
        {
            Console.Write("Enter ISBN of the book to lend: ");
            string isbnToLend = Console.ReadLine();
            Book bookToLend = Book.SearchByISBN(library.Books, isbnToLend);
            if (bookToLend != null)
            {
                // Create a lending transaction 
                Transactions lendingTransaction = new Transactions
                {
                    Book = bookToLend,
                    Member = memberToLendTo,
                    LendingDate = DateTime.Now,
                    ReturnDate = DateTime.Now.AddDays(14) // Example: Set a return date 14 days from today
                };

                // Add the transaction to the library's transactions list 
                library.Transactions.Add(lendingTransaction);

                // Display lending information
                Transactions.ViewLendingInformation(library.Transactions);

                // Return the book
                Book.ReturnBook(bookToLend, memberToLendTo, library);

                // Display updated lending information
                Transactions.ViewLendingInformation(library.Transactions);

                // Calculate and display the fine (if applicable)
                double fine = Book.CalculateFine(lendingTransaction);
                if (fine > 0)
                {
                    Console.WriteLine($"Fine of Rs. {fine} applied for this return.");
                }
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }
        else
        {
            Console.WriteLine("Member not found.");
        }

        // Display overdue books
        library.DisplayOverdueBooks();

        // Remove a book by ISBN
        string isbnToRemove = "123456"; // Replace with the actual ISBN of the book to remove
        library.RemoveBookByISBN(isbnToRemove);

        // Remove a member by ID
        int memberIdToRemove = 1; // Replace with the actual ID of the member to remove
        library.RemoveMemberByID(memberIdToRemove);
    }
}
