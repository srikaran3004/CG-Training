using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<dynamic> books = new List<dynamic>();
    static int bookIdCounter = 1;

    static void Main()
    {
        DisplayMainMenu();
    }

    static void DisplayMainMenu()
    {
        while (true)
        {
            Console.WriteLine("\n1. Admin\n2. User\n3. Exit");
            Console.Write("Choose Role: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1) ShowAdminMenu();
            else if (choice == 2) ShowUserMenu();
            else break;
        }
    }

    static void ShowAdminMenu()
    {
        while (true)
        {
            Console.WriteLine("\n--- Admin Menu ---");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Update Book");
            Console.WriteLine("3. Delete Book");
            Console.WriteLine("4. View All Books");
            Console.WriteLine("5. Back");
            Console.Write("Enter choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1) AddBook();
            else if (choice == 2) UpdateBook();
            else if (choice == 3) DeleteBook();
            else if (choice == 4) ViewAllBooks();
            else break;
        }
    }

    static void ShowUserMenu()
    {
        while (true)
        {
            Console.WriteLine("\n--- User Menu ---");
            Console.WriteLine("1. Browse All Books");
            Console.WriteLine("2. Search Book by Name");
            Console.WriteLine("3. Search Book by Publisher");
            Console.WriteLine("4. View Highest Priced Book");
            Console.WriteLine("5. View Lowest Priced Book");
            Console.WriteLine("6. Back");
            Console.Write("Enter choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1) ViewAllBooks();
            else if (choice == 2) SearchBookByName();
            else if (choice == 3) SearchBookByPublisher();
            else if (choice == 4) DisplayHighestPricedBook();
            else if (choice == 5) DisplayLowestPricedBook();
            else break;
        }
    }

    static void AddBook()
    {
        dynamic book = new System.Dynamic.ExpandoObject();
        book.Id = bookIdCounter++;

        Console.Write("Enter Book Name: ");
        book.Name = Console.ReadLine();

        Console.Write("Enter Author Name: ");
        book.Author = Console.ReadLine();

        Console.Write("Enter Publisher Name: ");
        book.Publisher = Console.ReadLine();

        Console.Write("Enter Book Price: ");
        book.Price = Convert.ToDouble(Console.ReadLine());

        books.Add(book);
        Console.WriteLine("Book added successfully.");
    }

    static void UpdateBook()
    {
        Console.Write("Enter Book ID to update: ");
        int id = Convert.ToInt32(Console.ReadLine());

        var book = books.FirstOrDefault(b => b.Id == id);
        if (book != null)
        {
            Console.Write("Enter New Book Name: ");
            book.Name = Console.ReadLine();

            Console.Write("Enter New Author Name: ");
            book.Author = Console.ReadLine();

            Console.Write("Enter New Publisher Name: ");
            book.Publisher = Console.ReadLine();

            Console.Write("Enter New Book Price: ");
            book.Price = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Book updated successfully.");
        }
        else
        {
            Console.WriteLine("Book not found.");
        }
    }

    static void DeleteBook()
    {
        Console.Write("Enter Book ID to delete: ");
        int id = Convert.ToInt32(Console.ReadLine());

        var book = books.FirstOrDefault(b => b.Id == id);
        if (book != null)
        {
            books.Remove(book);
            Console.WriteLine("Book deleted successfully.");
        }
        else
        {
            Console.WriteLine("Book not found.");
        }
    }

    static void ViewAllBooks()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("No books available.");
            return;
        }

        foreach (var book in books)
        {
            Console.WriteLine($"ID: {book.Id} | Name: {book.Name} | Author: {book.Author} | Publisher: {book.Publisher} | Price: {book.Price}");
        }
    }

    static void SearchBookByName()
    {
        Console.Write("Enter Book Name to search: ");
        string name = Console.ReadLine().ToLower();

        var results = books.Where(b => b.Name.ToLower().Contains(name));

        foreach (var book in results)
        {
            Console.WriteLine($"ID: {book.Id} | Name: {book.Name} | Author: {book.Author} | Publisher: {book.Publisher} | Price: {book.Price}");
        }
    }

    static void SearchBookByPublisher()
    {
        Console.Write("Enter Publisher Name to search: ");
        string publisher = Console.ReadLine().ToLower();

        var results = books.Where(b => b.Publisher.ToLower().Contains(publisher));

        foreach (var book in results)
        {
            Console.WriteLine($"ID: {book.Id} | Name: {book.Name} | Author: {book.Author} | Publisher: {book.Publisher} | Price: {book.Price}");
        }
    }

    static void DisplayHighestPricedBook()
    {
        if (books.Count == 0) return;

        var book = books.OrderByDescending(b => b.Price).First();
        Console.WriteLine($"Highest Priced Book: {book.Name} | Price: {book.Price}");
    }

    static void DisplayLowestPricedBook()
    {
        if (books.Count == 0) return;

        var book = books.OrderBy(b => b.Price).First();
        Console.WriteLine($"Lowest Priced Book: {book.Name} | Price: {book.Price}");
    }
}
