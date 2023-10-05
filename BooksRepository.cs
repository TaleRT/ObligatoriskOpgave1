using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatoriskOpgave
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
        public int Id { get; set; }

        public Book(string title, string author, int price)
        {
            Title = title;
            Author = author;
            Price = price;
        }
    }
    public class BookRepository
    {
        public List<Book> books = new List<Book>();
        public int nextId = 1;
        public void AddBook(string title, string author, int price)
        {
            Book newBook = new Book(title, author, price);
            books.Add(newBook);
        }

        public List<Book> Get(int? filterPrice = null)
        {
            if (filterPrice.HasValue)
            {
                return books.Where(book => book.Price == filterPrice.Value).ToList();

            }
            else
            {
                return new List<Book>(books);
            }
        }

        public List<Book> Get()
        {
            return new List<Book>(books);
        }
        public List<Book> Get(string? sortBy = null)
        {
            var filteredBooks = new List<Book>(books);

            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy.ToLower())
                {
                    case "title":
                        filteredBooks = filteredBooks.OrderBy(book => book.Title).ToList();
                        break;
                    case "price":
                        filteredBooks = filteredBooks.OrderBy(book => book.Price).ToList();
                        break;
                    default:
                        break;
                }
            }

            return filteredBooks;
        }
        public Book Delete(int id)
        {
            Book bookToRemove = books.FirstOrDefault(book => book.Id == id);
            if (bookToRemove != null)
            {
                books.Remove(bookToRemove);
            }
            return bookToRemove;
        }

        public Book Update(int id, Book values)
        {
            Book bookToUpdate = books.FirstOrDefault(book => book.Id == id);
            if (bookToUpdate != null)
            {
                bookToUpdate.Title = values.Title;
                bookToUpdate.Author = values.Author;
                bookToUpdate.Price = values.Price;
            }
            return bookToUpdate;
        }
        public Book GetById(int id)
        {
            return books.FirstOrDefault(book => book.Id == id);
        }
    }
    class Program
    {
        static void Main()
        {
            BookRepository repository = new BookRepository();

            repository.AddBook("Twisted Love", "Ana Huang", 500);
            repository.AddBook("Uden Håb", "Colleen Hoover", 500);
            repository.AddBook("Forbandede Kærlighed", "Colleen Hoover", 500);
            repository.AddBook("Twisted Games", "Ana Huang", 500);
            repository.AddBook("Manden I Tre Dele", "Thomas Bagger", 500);

            List<Book> allBooks = repository.Get();

            foreach (var book in allBooks)
            {
                Console.WriteLine($"Title: {book.Title}, Fofatter: {book.Author}");
            }
        }



    }
}

