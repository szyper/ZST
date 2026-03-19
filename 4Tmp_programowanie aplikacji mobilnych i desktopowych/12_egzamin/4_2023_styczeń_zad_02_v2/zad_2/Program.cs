
namespace zad_2
{
    /***********************************************
     * Nazwa klasy: Note
     * Opis klasy: Klasa do obsługi notatek. Przechowuje tytuł i treść notatki, przypisuje unikalne ID oraz umożliwia wyświetlanie i diagnostykę notatki
     * 
     * Pola:
     *      private static int counter - statyczny licznik notatek
     *      private int id - unikalny identyfikator notatki
     *      protected string title - tytuł notatki
     *      protected string content - treść notatki
     * Metody:
     *      public void Display() - wyświetla tytuł i  treść notatki
     *      public void Diagnostics() - wypisuje wszystkie pola oddzielone średnikami
     * Autor: 12345678901
    ***********************************************/
    class Note
    {
        private static int counter = 0;
        private int id;

        protected string title;
        protected string content;

        public string Title
        {
            get { return title; }
        }
        public string Content
        {
            get { return content; }
        }

        public Note(string title, string content)
        {
            counter++;
            id = counter;
            this.title = title;
            this.content = content;
        }

        public virtual void Display()
        {
            Console.WriteLine("ID: " + id);
            Console.WriteLine("Tytuł: " + title);
            Console.WriteLine("Treść: " + content);
            Console.WriteLine();
        }

        public void Diagnostics()
        {
            Console.WriteLine(id + ";" + counter + ";" + title + ";" + content);
        }

        public int GetId()
        {
            return id;
        }

        public void Edit(string newTitle, string newContent)
        {
            title = newTitle;
            content = newContent;
        }

        public bool Contains(string text)
        {
            return title.Contains(text) || content.Contains(text);
        }

        public override string ToString()
        {
            return $"{id};{title};{content}";
        }
    }

    class ImportantNote : Note
    {
        public string Priority;

        public ImportantNote(string title, string content, string priority) : base (title, content)
        {
            Priority = priority;
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine("Priorytet: " + Priority);
            Console.WriteLine();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Note> notes = new List<Note>();

            while (true)
            {
                Console.WriteLine("\n=== MENU ===");
                Console.WriteLine("1. Dodaj notatkę");
                Console.WriteLine("2. Wyświetl wszystkie notatki");
                Console.WriteLine("3. Usuń notatkę");
                Console.WriteLine("4. Edytuj notatkę");
                Console.WriteLine("5. Wyszukaj notatkę");
                Console.WriteLine("6. Zapisz notatkę do pliku");
                Console.WriteLine("7. Dodaj ważną notatkę");
                Console.WriteLine("0. Wyjście");

                Console.Write("Wybierz opcję: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Podaj tytuł: ");
                        string title = Console.ReadLine();

                        Console.Write("Podaj treść: ");
                        string content = Console.ReadLine();

                        notes.Add(new Note(title, content));
                        Console.WriteLine("Dodano notatkę");
                        break;

                    case "2":
                        foreach (var note in notes)
                        {
                            note.Display();
                        }
                        break;
                    case "3":
                        DisplayNotesTable(notes);

                        Console.Write("Podaj ID do usunięcia: ");
                        int deleteId = int.Parse(Console.ReadLine());

                        notes.RemoveAll(n => n.GetId() == deleteId);
                        break;
                    case "4":
                        DisplayNotesTable(notes);

                        Console.Write("Podaj ID do edycji: ");
                        int editId = int.Parse(Console.ReadLine());

                        var noteToEdit = notes.Find(n => n.GetId() == editId);
                        if (noteToEdit != null)
                        {
                            Console.Write("Podaj tytuł: ");
                            string newTitle = Console.ReadLine();

                            Console.Write("Podaj treść: ");
                            string newContent = Console.ReadLine();

                            noteToEdit.Edit(newTitle, newContent);
                            Console.WriteLine("Zaktualizowano notatkę");
                        }
                        else
                        {
                            Console.WriteLine("Nie znaleziono notatki");
                        }
                        break;
                    case "5":
                        Console.Write("Szukaj: ");
                        string search = Console.ReadLine();

                        foreach (var note in notes)
                        {
                            if (note.Contains(search))
                                note.Display();
                        }
                        break;
                    case "6":
                        File.WriteAllText("notes.txt", "");
                        foreach (var note in notes)
                        {
                            File.AppendAllText("notes.txt", note.ToString() + "\n");
                        }
                        Console.WriteLine("Zapisano do pliku notes.txt");
                        break;
                    case "7":
                        Console.Write("Podaj tytuł: ");
                        string titleNote = Console.ReadLine();

                        Console.Write("Podaj treść: ");
                        string contentNote = Console.ReadLine();

                        Console.Write("Podaj priorytet (np. wysoki): ");
                        string priorityNote = Console.ReadLine();


                        notes.Add(new ImportantNote(titleNote, contentNote, priorityNote));
                        Console.WriteLine("Dodano ważną notatkę");
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Niepoprawna opcja");
                        break;
                }
            }
        }

        private static void DisplayNotesTable(List<Note> notes)
        {
            if (notes.Count == 0)
            {
                Console.WriteLine("Brak notatek do usunięcia");
                return;
            }

            Console.WriteLine("\nLista notatek");
            Console.WriteLine("ID   | Tytuł           |  Treść");
            Console.WriteLine("-------------------------------");

            foreach (var note in notes)
            {
                string shortContent = note.Content.Length > 20 ? note.Content.Substring(0, 20) : note.Content;
                Console.WriteLine($"{note.GetId(),-3} | {note.Title,-18} | {shortContent}");
            }
        }
    }
}
