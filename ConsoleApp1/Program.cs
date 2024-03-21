using System;
using System.Collections.Generic;

// Define a Book with Title, Author, and Category properties
class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Category { get; set; }
}

// Library manages a list of books and provides operations to add, remove, and list books
class Library
{
    private List<Book> books = new List<Book>();

    // AddBook method adds a book to the library
    public void AddBook(Book book) => books.Add(book);

    // RemoveBook method removes a book from the library by title
    public void RemoveBook(string title)
    {
        Book bookToRemove = books.Find(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        if (bookToRemove != null)
        {
            books.Remove(bookToRemove);
            Console.WriteLine($"Removed: {title}");
        }
        else
        {
            Console.WriteLine($"Not found: {title}");
        }
    }

    // ListAllBooks method displays all books in the library
    public void ListAllBooks()
    {
        Console.WriteLine("Books in the Library:");
        foreach (var book in books)
        {
            Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Category: {book.Category}");
        }
    }
}

// Program class contains the main entry point for the application
class Program
{
    static void Main()
    {
        Library library = new Library();

        // Main loop for the library menu
        while (true)
        {
            Console.WriteLine("Menu\n1. Add Book\n2. Remove Book\n3. List All Books\n4. Exit");
            Console.Write("Enter choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": library.AddBook(new Book { Title = GetUserInput("Title"), Author = GetUserInput("Author"), Category = GetUserInput("Category") }); break;
                case "2": library.RemoveBook(GetUserInput("Enter title to remove")); break;
                case "3": library.ListAllBooks(); break;
                case "4": Environment.Exit(0); break;
                default: Console.WriteLine("Invalid choice. Try again."); break;
            }
        }
    }

    // GetUserInput method prompts the user for input based on a given prompt
    static string GetUserInput(string prompt)
    {
        Console.Write($"{prompt}: ");
        return Console.ReadLine();
    }
}