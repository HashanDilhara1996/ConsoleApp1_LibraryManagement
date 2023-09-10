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
        Console.WriteLine("Please Enter Book Details Below:");
        Console.Write("Title: ");
        string title = Console.ReadLine();
        Console.Write("Author: ");
        string author = Console.ReadLine();
        Console.Write("ISBN: ");
        string isbn = Console.ReadLine();

        library.Books.Add(new Book { Title = title, Author = author, ISBN = isbn });

        Console.WriteLine("Book Successfully Added to the Library!");
        Console.WriteLine("============================================================================================");
    }

    static void DisplayBooks(Library library)
    {
        Console.WriteLine("Here are the List of Books in the Library:");
        foreach (var book in library.Books)
        {
            Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, ISBN: {book.ISBN}, Available: {(book.IsAvailable ? "Yes" : "No")}");
        }
        Console.WriteLine("==============================================================================================");

    }

    static void RegisterMember(Library library)
    {
        Console.WriteLine("Please Enter Member Details Below:");
        Console.Write("Member ID: ");
        int memberId = int.Parse(Console.ReadLine());
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Contact Number: ");
        string ContactNum = Console.ReadLine();

        library.Members.Add(new Member { MemberID = memberId, Name = name, ContactNum = ContactNum });

        Console.WriteLine("Member Registered Successfully!");
        Console.WriteLine("==============================================================================================");
    }

    static void DisplayMembers(Library library)
    {
        Console.WriteLine("Here are the List of Registered Members:");
        foreach (var member in library.Members)
        {
            Console.WriteLine($"Member ID: {member.MemberID}, Name: {member.Name}, Contact Number: {member.ContactNum}");
        }
        Console.WriteLine("==============================================================================================");
    }
}
