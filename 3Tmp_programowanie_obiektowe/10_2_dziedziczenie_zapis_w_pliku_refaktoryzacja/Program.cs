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

        // refaktoryzacja - metoda pomocnicza
        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
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

        // refaktoryzacja - metoda do wyświetlenia
        public string GetBookInfo()
        {
            return $"{Title} - {Author.GetFullName()} ({PublicationYear})";
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
            Console.WriteLine($"Czytelnik {GetFullName()} wypożyczył książkę: {book.Title}");
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
            Console.WriteLine($"Dodano czytelnika: {reader.GetFullName()}");
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
                Console.WriteLine($"Książka {book.Title} została wypożyczona przez {reader.GetFullName()}");
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
                    Console.WriteLine($"{book.Title} - {book.Author.FirstName} {book.Author.LastName} ({book.PublicationYear}) wypożyczona przez {reader.GetFullName()}");
                }
            }
        }

        internal void DisplayAuthorsTable()
        {
            if (AuthorList.Count == 0)
            {
                Console.WriteLine("Brak autorów w bibliotece"); // poprawiony komunikat
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
            Console.WriteLine(line); // dodana dolna linia
        }

        // refaktoryzacja - rozbicie logiki eksportu
        internal void ExportLibrary(string? folderPath)
        {
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
            ExportAuthors(folderPath);
        }

        private void ExportAuthors(string folderPath) // nowa metoda
        {
            using (var writer = new StreamWriter(Path.Combine(folderPath, "authors.csv")))
            {
                writer.WriteLine("FirstName, LastName");

                foreach (var author in AuthorList)
                    writer.WriteLine($"{author.FirstName},{author.LastName}");
            }
        }

        // refaktoryzacja - rozbicie importu
        internal void ImportLibrary(string? folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine("Folder nie istnieje!");
                return;
            }
            ImportAuthors(folderPath);
        }

        private void ImportAuthors(string folderPath)
        {
            string authorsPath = Path.Combine(folderPath, "authors.csv");

            if (File.Exists(authorsPath))
            {
                var lines = File.ReadAllLines(authorsPath);

                for (int i = 1; i < lines.Length; i++)
                {
                    var parts = lines[i].Split(',');
                    if (parts.Length != 2) continue;

                    // refaktoryzacja -  LINQ
                    bool exists = AuthorList.Any(a => a.FirstName == parts[0] && a.LastName == parts[1]);
                    if (!exists)
                        AuthorList.Add(new Author(parts[0], parts[1]));
                }
            }
        }
    }

    internal class Program
    {
        // zadanie_1 biblioteka
        static void Main(string[] args)
        {
            Library library = new Library();
            bool exit = false;

            while (!exit)
            {
                ShowMenu();

                string choice = Console.ReadLine();

                switch (choice) 
                {
                    case "1":
                        AddAuthor(library);
                        break;
                    case "2":
                        AddBook(library);
                        break;
                    case "3":
                        AddReader(library);
                        break;
                    case "4":
                        BorrowBook(library);
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
                        Console.Write("Podaj folder do zapisania CSV: ");
                        string exportFolder = Console.ReadLine();
                        library.ExportLibrary(exportFolder);
                        break;
                    case "9":
                        Console.Write("Podaj folder z plikami CSV: ");
                        string importFolder = Console.ReadLine();
                        library.ImportLibrary(importFolder);
                        break;
                    case "10":
                        exit = true;
                        break;
                }
                Console.WriteLine("\n\nNaciśnij dowolny klawisz, aby kontynuować...");
                Console.ReadKey();
            }
        }

        private static void BorrowBook(Library library)
        {
            Console.Write("Podaj imię czytelnika: ");
            string first = Console.ReadLine();
            Console.Write("Podaj nazwisko czytelnika: ");
            string last = Console.ReadLine();

            Reader reader = library.ReadersList.Find(r => r.FirstName == first && r.LastName == last);

            if (reader == null)
            {
                Console.WriteLine("Nie znaleziono czytelnika");
                return;
            }
            
            Console.Write("Podaj tytuł książki: ");
            string title = Console.ReadLine();

            var book = library.BooksList.Find(b => b.Title == title);

            if (book == null)
            {
                Console.WriteLine("Brak ksiązki");
                return;
            }

                library.BorrowBook(reader, book);  
        }

        private static void AddReader(Library library)
        {
            Console.Write("Podaj imię czytelnika:");
            string readerFirstName = Console.ReadLine();
            Console.Write("Podaj nazwisko czytelnika:");
            string readerLastName = Console.ReadLine();

            library.AddReader(new Reader(readerFirstName, readerLastName));
        }

        private static void AddBook(Library library)
        {
            if (library.AuthorList.Count == 0)
            {
                Console.WriteLine("Brak autorów w bibliotece. Najpierw dodaj autora!");
                return;
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
        }

        private static void AddAuthor(Library library)
        {
            Console.Write("Podaj imię autora:");
            string authorFirstName = Console.ReadLine();
            Console.Write("Podaj nazwisko autora:");
            string authorLastName = Console.ReadLine();

            library.AddAuthor(new Author(authorFirstName, authorLastName));
        }

        private static void ShowMenu()
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
            Console.WriteLine("8. Eksportuj bibliotekę do CSV");
            Console.WriteLine("9. Importuj bibliotekę z CSV");
            Console.WriteLine("10. Wyjście");
            Console.Write("Wybierz opcję: ");
        }
    }
}
