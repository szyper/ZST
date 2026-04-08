using _10_dziedziczenie.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _10_dziedziczenie.Services
{
    internal class LibraryService
    {
        public List<Book> BooksList { get; set; }
        public List<Reader> ReadersList { get; set; }
        public List<Author> AuthorList { get; set; }

        public LibraryService()
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
            Console.WriteLine($"| {"ID",-3} | {"Imię",-13} | {"Nazwisko",-13} |");
            Console.WriteLine("+-----+---------------+---------------+");

            for (int i = 0; i < AuthorList.Count; i++)
            {
                Console.WriteLine($"| {i + 1,-3} | {AuthorList[i].FirstName,-13} | {AuthorList[i].LastName,-13} |");
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

            string line = "+" + new string('-', titleWidth + 2) + "+" + new string('-', authorWidth + 2) + "+" + new string('-', yearWidth + 2) + "+";

            Console.WriteLine(line);
            Console.WriteLine($"| {"Tytuł",-titleWidth} | {"Autor",-authorWidth} | {"Rok",-yearWidth} |");

            foreach (var book in BooksList)
            {
                string authorFullName = $"{book.Author.FirstName} {book.Author.LastName}";
                Console.WriteLine($"| {book.Title,-titleWidth} | {authorFullName,-authorWidth} | {book.PublicationYear,-yearWidth} |");
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
}
