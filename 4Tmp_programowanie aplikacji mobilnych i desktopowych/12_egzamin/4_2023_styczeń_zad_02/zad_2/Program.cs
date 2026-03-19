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

        public Note(string title, string content)
        {
            counter++;
            id = counter;
            this.title = title;
            this.content = content;
        }

        public void Display()
        {
            Console.WriteLine("Tytuł: " + title);
            Console.WriteLine("Treść: " + content);
            Console.WriteLine();
        }

        public void Diagnostics()
        {
            Console.WriteLine(id + ";" + counter + ";" + title + ";" + content);
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== PROGRAM DO OBSŁUGI NOTATEK ===\n");

            Note note1 = new Note("Zakupy", "Kup jajka i mleko");
            Note note2 = new Note("Szkoła", "Spraedzian z C#");

            Console.WriteLine("=== NOTATKA 1 ===");
            note1.Display();
            note1.Diagnostics();

            Console.WriteLine("=== NOTATKA 2 ===");
            note2.Display();
            note2.Diagnostics();

            Console.ReadKey();
        }
    }
}
