namespace _9_konstruktory
{
    // klasa Person
    class Person
    {
        // pola klasy
        private string name;
        private string surname;
        private int age;

        // konstruktor domyślny
        public Person() 
        {
            name = "Jan";
            surname = "Kowalski";
            age = 20;
        }

        // konstruktor jednoparametrowy
        public Person(string name) : this()
        {
            this.name = name;
        }

        // konstruktor dwuparametrowy
        public Person(string name, string surname) : this(name)
        {
            this.surname = surname;
        }

        // konstruktor parametryczny
        public Person(string name, string surname, int age)
        {
            this.name = name;
            this.surname = surname;
            this.age = age;
        }

        //metoda wypisująca dane
        public void Print()
        {
            Console.WriteLine($"Imię: {name}, nazwisko: {surname}, wiek: {age}");
        }

        // metoda modyfikująca wiek
        public void ChangeAge(int number)
        {
            age = number;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // utworzenie obiektów
            Person person = new Person(); // za pomocą konstruktora domyślnego
            Person person1 = new Person("Jan");
            Person person2 = new Person("Anna", "Nowak");
            Person person3 = new Person("Janusz", "Nowak", 20);

            // wywołanie metody Print
            person1.Print();
            person.Print();
            person3.Print();

            person3.ChangeAge(10);
            person2.Print();

        }
    }
}
