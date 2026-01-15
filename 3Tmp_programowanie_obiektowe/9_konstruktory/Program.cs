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
            Person person1 = new Person(); // za pomocą konstruktora domyślnego
            Person person2 = new Person("Janusz", "Nowak", 20);

            // wywołanie metody Print
            person1.Print();
            person2.Print();

            person2.ChangeAge(10);
            person2.Print();

        }
    }
}
