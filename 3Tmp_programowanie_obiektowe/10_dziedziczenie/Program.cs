namespace _10_dziedziczenie
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }

    public class Author : Person
    {
        // public List<Book> BooksList { get; set; } = new List<Book>();
        public List<Book> BooksList { get; set; }

        public Author(string firstName, string lastName) : base(firstName, lastName) 
        {
            BooksList = new List<Book>();
        }

        public void AddBook(Book book)
        {
            BooksList.Add(book);
        }
    }

    public class Book
    {
        public string Title { get; set; }
        public Author Author { get; set; }
        public int PublicationYear { get; set; }

        public Book(string title, Author author, int publicationYear)
        {
            Title = title;
            Author = author;
            PublicationYear = publicationYear;
        }
    }

    public class Reader : Person
    {
        public List<Book> BorrowedBooksList { get; set; }
        public Reader(string firstName, string lastName) : base(firstName, lastName)
        {
            BorrowedBooksList = new List<Book>();
        }

        public void BorrowBook(Book book)
        {
            BorrowedBooksList.Add(book);
            Console.WriteLine($"Czytelnik {FirstName} {LastName} wypożyczył książkę: {book.Title}");
        }
    }

    public class Library
    {
        public List<Book> BooksList { get; set; }
        public List<Reader> ReadersList { get; set; }

        public Library()
        {
            BooksList = new List<Book>();
            ReadersList = new List<Reader>();
        }

        public void AddBook(Book book)
        {
            BooksList.Add(book);
            Console.WriteLine($"Dodano książkę: {book.Title}");
        }

        public void AddReader(Reader reader)
        {
            ReadersList.Add(reader);
            Console.WriteLine($"Dodano czytelnika: {reader.FirstName} {reader.LastName}");
        }

        public void BorrowBook(Reader reader, Book book)
        {
            if (BooksList.Contains(book))
            {
                reader.BorrowBook(book);
                BooksList.Remove(book);
                Console.WriteLine($"Książka {book.Title} została wypożyczona przez {reader.FirstName} {reader.LastName}");
            }
            else
            {
                Console.WriteLine($"Książka {book.Title} nie jest dostępna w bibliotece");
            }
        }
    }
    internal class Program
    {
        // zadanie_1 biblioteka
        static void Main(string[] args)
        {
            Author author = new Author("Adam", "Mickiewicz");
            Book book = new Book("Pan Tadeusz", author, 1834);
            author.AddBook(book);

            Reader reader = new Reader("Jan", "Kowalski");
            Library library = new Library();
            library.AddBook(book);
            library.AddReader(reader);
            library.BorrowBook(reader, book);

            Console.ReadKey();
        }
    }
}
