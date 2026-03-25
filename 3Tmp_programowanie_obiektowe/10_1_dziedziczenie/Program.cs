

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

        internal void DisplayAuthorsTable()
        {
            if (AuthorList.Count == 0)
            {
                Console.WriteLine("Brak książek w bibliotece");
                return;
            }

            Console.WriteLine("Lista autorów:");
            // Console.WriteLine("{0, -3} {1, -13} {2, -13}", "ID", "Imię", "Nazwisko");
            Console.WriteLine("+-----+---------------+---------------+");
            Console.WriteLine($"| { "ID", -3 } | { "Imię", -13} | { "Nazwisko", -13} |");
            Console.WriteLine("+-----+---------------+---------------+");

            for (int i = 0; i < AuthorList.Count; i++)
            {
                Console.WriteLine($"| {i + 1, -3} | {AuthorList[i].FirstName, -13} | {AuthorList[i].LastName, -13} |");
            }
            Console.WriteLine("+-----+---------------+---------------+");
        }

        internal void DisplayBooks()
        {
            if (BooksList.Count == 0)
            {
                Console.WriteLine("Brak książek w bibliotece");
                return;
            }

            Console.WriteLine("Książki w bibliotece:");
            const int titleWidth = 30;
            const int authorWidth = 25;
            const int yearWidth = 6;

            string line = "+" + new string('-', titleWidth + 2) + "+" + new string('-', authorWidth + 2) + "+" + new string('-',yearWidth + 2) + "+";

            Console.WriteLine(line);
            Console.WriteLine($"| {"Tytuł",-titleWidth} | {"Autor",-authorWidth} | {"Rok",-yearWidth} |");

            foreach (var book in BooksList)
            {
                string authorFullName = $"{book.Author.FirstName} {book.Author.LastName}";
                Console.WriteLine($"| {book.Title, -titleWidth} | {authorFullName, -authorWidth} | {book.PublicationYear, -yearWidth} |");
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
                Console.WriteLine("2. Dodaj książkę");
                Console.WriteLine("3. Dodaj czytelnika");
                Console.WriteLine("4. Wypożycz książkę");
                Console.WriteLine("5. Wyświetl wszystkie książki");
                Console.WriteLine("6. Wyświetl wszystkich autorów");
                Console.WriteLine("7. Wyświetl wszystkie wypożyczone książki");
                Console.WriteLine("8. Wyjście");
                Console.Write("Wybierz opcję: ");

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
                    case "2":
                        if (library.AuthorList.Count == 0)
                        {
                            Console.WriteLine("Brak autorów w bibliotece. Najpierw dodaj autora!");
                            Console.WriteLine("Naciśnij dowolny klawisz, aby kontynuować...");
                            Console.ReadKey();
                            break;
                        }
                        library.DisplayAuthorsTable();
                        Console.Write("Podaj ID autora: ");
                        int authorIndex = int.Parse(Console.ReadLine()) - 1;
                        if (authorIndex >= 0 && authorIndex < library.AuthorList.Count)
                        {
                            Author selectedAuthor = library.AuthorList[authorIndex];
                            Console.Write("Podaj tytuł książki: ");
                            string bookTitle = Console.ReadLine();
                            Console.Write("Podaj rok publikacji: ");
                            int publicationYear = int.Parse(Console.ReadLine());
                            Book newBook = new Book(bookTitle, selectedAuthor, publicationYear);
                            library.AddBook(newBook);
                            selectedAuthor.AddBook(newBook);
                        } 
                        else
                        {
                            Console.WriteLine("Nieprawidłowy numer autora");
                        }
                        break;
                    case "3":
                        Console.Write("Podaj imię czytelnika:");
                        string readerFirstName = Console.ReadLine();
                        Console.Write("Podaj nazwisko czytelnika:");
                        string readerLastName = Console.ReadLine();
                        library.AddReader(new Reader(readerFirstName, readerLastName));
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
                    case "5":
                        library.DisplayBooks();
                        break;
                    case "6":
                        library.DisplayAuthorsTable();
                        break;
                    case "7":
                        library.DisplayBorrowedBooks();
                        break;
                    case "8":
                        exit = true;
                        break;
                }
                Console.WriteLine("\n\nNaciśnij dowolny klawisz, aby kontynuować...");
                Console.ReadKey();
            }
        }
    }
}
