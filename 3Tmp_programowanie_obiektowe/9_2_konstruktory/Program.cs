namespace _9_2_konstruktory
{
    
    class Person
    {
        // pole przechowujące imię
        protected string name;

        // konstruktor domyślny
        public Person()
        {
            name = "Brak imienia";
            Console.WriteLine("1. Konstruktor Person()");
            Console.WriteLine($"    Ustawiono name = {name}");
        }
        
        // konstrukotr z parametrem
        // : this oznacza, że najpierw wywołaj Person() a następnie poniższy kod
        public Person(string name) : this()
        {
            // this.name odnosi się do pola klasy
            // name (bez this) to parametr konstruktora
            this.name = name;
            Console.WriteLine("2. Konstruktor Person(string)");
            Console.WriteLine($"    Zmieniono name na {this.name}");
        }

    }

    class Student : Person
    {
        // pole klasy pochodnej
        // to pole należy tylko do klasy Student
        // klasa Person NIE "widzi" tego pola

        private int age;


        // konstruktor bezparametrowy
        // : base("Jan") oznacza, że zanim wykona się ciało tego konstruktora, najpierw zostanie wywołany konstruktor klasy bazowej Person(string) z argumentem "Jan"
        public Student() : base("Jan")
        {
            // w tym momencie:
            // 1) konstruktor Person() już się wykonał
            // 2) konstruktor Person(string) już się wykonał
            // 3) pole name zostało ustawione na "Jan"

            // teraz inicjalizujemy pole klasy Student
            age = 0;
            Console.WriteLine("3. Konstruktor Student()");
            Console.WriteLine($"    Student: name = {name}, age = {age}");
        }

        // konstruktor z parametrem
        // : this() oznacza, że najpierw wywołaj konstruktor Student() a dopiero później wykonaj poniższy kod
        public Student(int age) : this()
        {
            // w tym momencie:
            // 1) Student() już się wykonał
            // 2) base("Jan") też już się wykonał
            // 3) pole name = "Jan"
            // 4) pole age = 0

            // this.age -> pole klasy
            // age -> parametr konstruktora
            // nadpisujemy wcześniejszą wartość (0)
            
            this.age = age;
            Console.WriteLine("4. Konstruktor Student(int)");
            Console.WriteLine($"    Student: name = {name}, age = {this.age}");
        }
        
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // Person p = new Person();
            // Person p = new Person("Franuś");
            // Student s = new Student();
            Student s = new Student(25);
        }
    }
}
