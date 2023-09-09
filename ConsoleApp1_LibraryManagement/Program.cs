using ConsoleApp1_LibraryManagement;
using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Library library = new Library();

        // Add some initial books to the library
        library.Books.Add(new Book { Title = "Book 1", Author = "Author 1", ISBN = "123456" });
        library.Books.Add(new Book { Title = "Book 2", Author = "Author 2", ISBN = "789012" });

        // Call a method to add a new book
        AddBook(library);

        // Display the list of books in the library
        DisplayBooks(library);

        // Call a method to register a new member
        RegisterMember(library);

        // Display the list of registered members
        DisplayMembers(library);
    }

    static void AddBook(Library library)
    {
        Console.WriteLine("Enter book details:");
        Console.Write("Title: ");
        string title = Console.ReadLine();
        Console.Write("Author: ");
        string author = Console.ReadLine();
        Console.Write("ISBN: ");
        string isbn = Console.ReadLine();

        // Create a new book object and add it to the library
        library.Books.Add(new Book { Title = title, Author = author, ISBN = isbn });

        Console.WriteLine("Book added to the library.");
    }

    static void DisplayBooks(Library library)
    {
        Console.WriteLine("List of Books in the Library:");
        foreach (var book in library.Books)
        {
            Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, ISBN: {book.ISBN}, Available: {(book.IsAvailable ? "Yes" : "No")}");
        }
    }

    static void RegisterMember(Library library)
    {
        Console.WriteLine("Enter member details:");
        Console.Write("Member ID: ");
        int memberId = int.Parse(Console.ReadLine());
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Contact Information: ");
        string contactInfo = Console.ReadLine();

        // Create a new member object and add it to the library
        library.Members.Add(new Member { MemberID = memberId, Name = name, ContactInfo = contactInfo });

        Console.WriteLine("Member registered.");
    }

    static void DisplayMembers(Library library)
    {
        Console.WriteLine("List of Registered Members:");
        foreach (var member in library.Members)
        {
            Console.WriteLine($"Member ID: {member.MemberID}, Name: {member.Name}, Contact Info: {member.ContactInfo}");
        }
    }
}
