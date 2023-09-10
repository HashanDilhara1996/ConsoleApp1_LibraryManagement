using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ConsoleApp1_LibraryManagement
{
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool IsAvailable { get; set; } = true;

        public void CheckOut()
        {
            IsAvailable = false;
        }

        public void CheckIn()
        {
            IsAvailable = true;
        }

        public static void AddToLibrary(List<Book> libraryBooks)
        {
            Console.WriteLine("Add a New Book to the Library:");
            Console.Write("Title: ");
            string title = Console.ReadLine();

            Console.Write("Author: ");
            string author = Console.ReadLine();

            Console.Write("ISBN: ");
            string isbn = Console.ReadLine();

            // Create a new book instance with user-provided data
            Book newBook = new Book
            {
                Title = title,
                Author = author,
                ISBN = isbn,
                IsAvailable = true // Assuming the book is initially available
            };

            // Add the new book to the library's collection
            libraryBooks.Add(newBook);

            Console.WriteLine($"Book '{title}' (ISBN: {isbn}) has been added to the library.");
            Console.WriteLine("============================================================================================");
        }

        public static void DisplayAllBooks(List<Book> books)
        {
            Console.WriteLine("List of Books in the Library:");
            foreach (var book in books)
            {
                Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, ISBN: {book.ISBN}, Available: {(book.IsAvailable ? "Yes" : "No")}");
                Console.WriteLine("===================================================================================================================");
            }
        }

        public static Book SearchByISBN(List<Book> books, string isbnToSearch)
        {
            return books.FirstOrDefault(b => b.ISBN == isbnToSearch);
        }

        public static void DisplayBookInformation(Book book)
        {
            if (book != null)
            {
                Console.WriteLine("Book Information:");
                Console.WriteLine($"Title: {book.Title}");
                Console.WriteLine($"Author: {book.Author}");
                Console.WriteLine($"ISBN: {book.ISBN}");
                Console.WriteLine($"Available: {(book.IsAvailable ? "Yes" : "No")}");
                Console.WriteLine("============================================================================================");
            }
            else
            {
                Console.WriteLine("Book not found in the library.");
                Console.WriteLine("============================================================================================");
            }
        }

        public static void LendBook(Book book, Member member)
        {
            if (book.IsAvailable)
            {
                book.IsAvailable = false;
                Console.WriteLine($"Book '{book.Title}' has been lent to {member.Name}.");
                Console.WriteLine("============================================================================================");
            }
            else
            {
                Console.WriteLine($"Book '{book.Title}' is not available for lending.");
                Console.WriteLine("============================================================================================");
            }
        }

        public static void ReturnBook(Book book, Member member, Library library)
        {
            if (!book.IsAvailable)
            {
                book.IsAvailable = true;

                // Find the lending transaction based on book and member
                Transactions transaction = library.Transactions
                    .FirstOrDefault(t => t.Book == book && t.Member == member);

                if (transaction != null)
                {
                    transaction.ReturnDate = DateTime.Now;
                    double fine = CalculateFine(transaction);

                    if (fine > 0)
                    {
                        Console.WriteLine($"Fine of Rs. {fine} applied for this return.");
                        Console.WriteLine("============================================================================================");
                    }

                    Console.WriteLine($"Book '{book.Title}' has been returned by {member.Name}.");
                }
                else
                {
                    Console.WriteLine($"No lending transaction found for book '{book.Title}' by {member.Name}.");
                }
            }
            else
            {
                Console.WriteLine($"Book '{book.Title}' is already available.");
            }
        }

        public static double CalculateFine(Transactions transaction)
        {
            // Calculate the number of days the book is overdue
            TimeSpan overdueDuration = DateTime.Now - transaction.ReturnDate;
            int overdueDays = (int)overdueDuration.TotalDays;

            // Define fine rates
            const double fineRateUpTo7Days = 50.0;
            const double fineRateAfter7Days = 100.0;

            double fine = 0;

            if (overdueDays > 0)
            {
                if (overdueDays <= 7)
                {
                    fine = overdueDays * fineRateUpTo7Days;
                }
                else
                {
                    fine = (7 * fineRateUpTo7Days) + ((overdueDays - 7) * fineRateAfter7Days);
                }

                Console.WriteLine($"Fine of Rs. {fine} applied for this transaction.");
            }

            return fine;
        }
    }


    }

