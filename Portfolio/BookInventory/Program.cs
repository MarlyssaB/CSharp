using System;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace BookInventory
{
    class Program
    {
        static void Main(string[] args)
        {
            BooksContext context = new BooksContext();

            context.Database.EnsureCreated();
            Console.WriteLine("Welcome to the Library Database");
            String titleAndAuthor = string.Empty;

            do {
                Console.WriteLine("Enter book title and author separated by an asterisk (ex. Winnie the Pooh*A.A. Milne), or quit to end: ");
                titleAndAuthor = Console.ReadLine();
                String[] parts = titleAndAuthor.Split('*');

                if (parts.Length == 2)
                {
                    Book newBook = new Book(parts[0], parts[1]);

                    context.books.Add(newBook);

                    context.SaveChanges();
                    Console.WriteLine("Book added.");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Invalid input. Book not added");
                    Console.WriteLine();
                }
            } while (titleAndAuthor != "quit");

            Console.WriteLine("Books currently in inventory: ");
            
            foreach(Book b in context.books)
            {
                Console.WriteLine("{0}- {1} by {2}", b.ID, b.Title, b.Author);
            }
            Console.Read();



        }
    }
}
