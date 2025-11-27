using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _9_2_1_pliki.Logger;

namespace _9_2_1_pliki
{
    internal class LibraryManager
    {
        private readonly string _dataFile;
        private readonly Logger _logger;
        //private readonly List<Book> _books = new List<Book>();
        private readonly List<Book> _books = new();
        private const string CsvHeader = "Tytuł;Autor;Rok;Gatunek";
        public bool IsDirty { get; private set; } = false;

        public LibraryManager(string file, Logger logger)
        {
            _dataFile = file;
            _logger = logger;

            Load();
        }

        // wczytywanie
        private void Load()
        {
            if (!File.Exists(_dataFile))
            {
                _logger.Log($"Plik {_dataFile} nie istnieje - tworzony nowy", Logger.LogType.Info);
                return;
            }

            try
            {
                string[] lines = File.ReadAllLines(_dataFile, Encoding.UTF8);

                // pomijamy nagłówek, jeśli istnieje 
                int start = (lines.Length > 0 && lines[0] == CsvHeader) ? 1 : 0;

                for (int i = start; i < lines.Length; i++)
                {
                    if (!string.IsNullOrWhiteSpace(lines[i]))
                        _books.Add(Book.FromCsv(lines[i]));
                }

                _logger.Log($"Wczytano {_books.Count} książek z pliku {_dataFile}", LogType.Success);
            }
            catch (Exception ex)
            {
                _logger.Log($"Błąd podczas wczytywania danych: {ex.Message}", Logger.LogType.Error);
            }
        }

        // zapis
        public void Save()
        {
            var lines = new List<string> { CsvHeader };
            lines.AddRange(_books.Select(b => b.ToCsv()));

            File.WriteAllLines(_dataFile, lines, Encoding.UTF8);
            _logger.Log($"Zapisano {_books.Count} książek", Logger.LogType.Success);
            IsDirty = false;
        }

        // obsługa książek
        public IReadOnlyList<Book> GetAll() => _books;

        public void AddBook(Book book)
        {
            bool exists = _books.Any(b => b.Title.Equals(book.Title, StringComparison.OrdinalIgnoreCase) && b.Author.Equals(book.Author, StringComparison.OrdinalIgnoreCase));

            if (exists)
            {
                _logger.Log("Ta książka już istnieje", Logger.LogType.Error);
                return;
            }

            _books.Add(book);
            IsDirty = true;
            _logger.Log($"Dodano książkę: {book}", Logger.LogType.Success);
        }

        public bool RemoveBook(int index)
        {
            if (index < 0 || index >= _books.Count)
                return false;

            var b = _books[index];
            _books.RemoveAt(index);
            IsDirty = true;
            _logger.Log($"Usunięto książkę: {b.Title} - {b.Author}", Logger.LogType.Success);
            return true;
        } 
    }
}
