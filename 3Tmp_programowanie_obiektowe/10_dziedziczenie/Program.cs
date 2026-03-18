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

        pub
    }

    public class Book
    {

    }
    internal class Program
    {
        // zadanie_1 biblioteka
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
