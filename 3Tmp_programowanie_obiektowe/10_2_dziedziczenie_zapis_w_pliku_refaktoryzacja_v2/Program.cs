
using _10_dziedziczenie.Models;
using _10_dziedziczenie.Services;

namespace _10_dziedziczenie
{
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
