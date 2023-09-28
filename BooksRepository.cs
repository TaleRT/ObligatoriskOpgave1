using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatoriskOpgave
{
    internal class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }

        public Book(string title, string author)
        {
            this.Title = title;
            this.Author = author;
        }
    }
    public class BookRepository
    {
        public List<Book> books = new List<Book>();

        public void AddBook(string title, string author)
        {
            Book newBook = new Book(title, author);
            books.Add(newBook);
        }

        public List<Book> Get()
        {
            // Den her returnere listen af book objekterne
            return new List<Book>(books);
        }
    }
    class Program
    {
        static void Main()
        {
            BookRepository repository = new BookRepository();

            repository.AddBook("Twisted Love", "Ana Huang");
            repository.AddBook("Uden Håb", "Colleen Hoover");
            repository.AddBook("Forbandede Kærlighed", "Colleen Hoover");
            repository.AddBook("Twisted Games", "Ana Huang");
            repository.AddBook("Manden I Tre Dele", "Thomas Bagger");

            List<Book> allBooks = repository.Get();

            foreach (var book in allBooks)
            {
                Console.WriteLine($"Title: {book.Title}, Fofatter: {book.Author}");
        }
    }
   

    
}
