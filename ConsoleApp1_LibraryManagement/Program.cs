using ConsoleApp1_LibraryManagement;
using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Library library = new Library();

        library.Books.Add(new Book { Title = "Book 1", Author = "Author 1", ISBN = "123456" });
        library.Books.Add(new Book { Title = "Book 2", Author = "Author 2", ISBN = "789012" });

        AddBook(library);
        DisplayBooks(library);
        RegisterMember(library);
        DisplayMembers(library);
    }

    static void AddBook(Library library)
    {
        Console.WriteLine("Please enter book details below:");
        Console.Write("Title: ");
        string title = Console.ReadLine();
        Console.Write("Author: ");
        string author = Console.ReadLine();
        Console.Write("ISBN: ");
        string isbn = Console.ReadLine();

        library.Books.Add(new Book { Title = title, Author = author, ISBN = isbn });

        Console.WriteLine("Book successfully added to the library.");
    }

    static void DisplayBooks(Library library)
    {
        Console.WriteLine("Here are the list of books in the library:");
        foreach (var book in library.Books)
        {
            Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, ISBN: {book.ISBN}, Available: {(book.IsAvailable ? "Yes" : "No")}");
        }
    }

    static void RegisterMember(Library library)
    {
        Console.WriteLine("Please enter member details below:");
        Console.Write("Member ID: ");
        int memberId = int.Parse(Console.ReadLine());
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Contact Information: ");
        string contactInfo = Console.ReadLine();

        library.Members.Add(new Member { MemberID = memberId, Name = name, ContactInfo = contactInfo });

        Console.WriteLine("Member registered.");
    }

    static void DisplayMembers(Library library)
    {
        Console.WriteLine("Hrere are the list of registered members:");
        foreach (var member in library.Members)
        {
            Console.WriteLine($"Member ID: {member.MemberID}, Name: {member.Name}, Contact Info: {member.ContactInfo}");
        }
    }
}
