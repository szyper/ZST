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
        public List<Author> AuthorList { get; set; }

        public Library()
        {
            BooksList = new List<Book>();
            ReadersList = new List<Reader>();
            AuthorList = new List<Author>();
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

        public void AddAuthor(Author author)
        {
            AuthorList.Add(author);
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

        public void DisplayBorrowedBooks()
        {
            Console.WriteLine("Wypożyczone książki:");
            foreach (var reader in ReadersList)
            {
                foreach (var book in reader.BorrowedBooksList)
                {
                    Console.WriteLine($"{book.Title} - {book.Author.FirstName} {book.Author.LastName} ({book.PublicationYear}) wypożyczona przez {reader.FirstName} {reader.LastName}");
                }
            }
        }
    }
    internal class Program
    {
        // zadanie_1 biblioteka
        static void Main(string[] args)
        {
            //Author author = new Author("Adam", "Mickiewicz");
            //Book book = new Book("Pan Tadeusz", author, 1834);
            //author.AddBook(book);

            //Reader reader = new Reader("Jan", "Kowalski");
            Library library = new Library();
            //library.AddBook(book);
            //library.AddReader(reader);
            //library.BorrowBook(reader, book);

            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Menu");
                Console.WriteLine("1. Dodaj autora");
                Console.WriteLine("4. Wypożycz książkę");
                Console.WriteLine("7. Wyświetl wszystkie wypożyczone książki");

                string choice = Console.ReadLine();
                switch (choice) 
                {
                    case "1":
                        Console.Write("Podaj imię autora:");
                        string authorFirstName = Console.ReadLine();
                        Console.Write("Podaj nazwisko autora:");
                        string authorLastName = Console.ReadLine();
                        library.AddAuthor(new Author(authorFirstName, authorLastName));
                        break;
                    case "4":
                        Console.Write("Podaj imię czytelnika: ");
                        string borrowerFirstName = Console.ReadLine();
                        Console.Write("Podaj nazwisko czytelnika: ");
                        string borrowerLastName = Console.ReadLine();
                        Reader borrower = library.ReadersList.Find(r => r.FirstName == borrowerFirstName && r.LastName == borrowerLastName);

                        if (borrower != null)
                        {
                            Console.Write("Podaj tytuł książki: ");
                            string borrowedBookTitle = Console.ReadLine();
                            Book borrowedBook = library.BooksList.Find(b => b.Title == borrowedBookTitle);
                            if (borrowedBook != null)
                            {
                                library.BorrowBook(borrower, borrowedBook);
                            } else
                            {
                                Console.WriteLine("Książka nie jest dotępna");
                            }
                        } else
                        {
                            Console.WriteLine("Czytelnik nie został znaleziony");
                        }
                        break;
                    case "7":
                        library.DisplayBorrowedBooks();
                        break;
                }
            }
        }
    }
}
