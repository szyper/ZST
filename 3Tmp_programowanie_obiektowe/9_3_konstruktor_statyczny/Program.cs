using System.Net.NetworkInformation;

namespace _9_3_konstruktor_statyczny
{
    class Car
    {
        // pole statyczne - wspólne dla wszystkich obiektów, liczy ile samochodów utworzono
        public static int Counter;

        // pole statyczne - maksymalna liczba obiektów
        public static int MaxCars;

        // pole statyczne - kolejny dostępny ID
        public static int NextId;

        // pola instancyjne - unikalne dla każdego obiektu
        public string Brand;
        public int Year;
        public int Id;

        // konstruktor statyczny
        //nie tworzy obiektów, działa na klasie jako całości, nie przyjmuje parametrów, wykonuje się tylko raz, przed pierwszym użyciem klasy
        static Car()
        {
            Counter = 0;
            MaxCars = 3;
            NextId = 1;
            Console.WriteLine("Konstruktor statyczny Car()");
            Console.WriteLine($"Maksymalna liczba samochodów: {MaxCars}");
        }

        // konstruktor instancyjny, to konstruktor, który tworzy obiekt klasy (czyli instancję). Może być domyślny (bez parametrów) lub parametryczny (z parametrami). Nie jest statyczny - wykonuje siędla konkretnego obiektu

        // konstruktor instancyjny domyślny
        public Car()
        {
            checkLimit("domyślnego");
            Brand = "nieznana";
            Year = 0;
            Id = NextId++;

            Counter++;
            Console.WriteLine($"Car(): Id = {Id}, marka: {Brand}, rok produkcji: {Year}, ilość samochodów: {Counter}");
        }

        // konstruktor instancyjny parametryczny
        public Car(string brand, int year)
        {
            checkLimit(brand);
            Brand = brand;
            Year = year;
            Id = NextId++;

            Counter++; // zliczamy obiekty
            Console.WriteLine($"Car(): Marka: {Brand}, rok produkcji: {Year}, licznik: {Counter}");
        }

        private void checkLimit(string name)
        {
            if (Counter >= MaxCars)
                throw new InvalidOperationException($"Nie można utworzyć samochodu {name}, osiągnięto limit {MaxCars}");
        }

        // metoda instancyjna - wypisuje dane samochodu
        public void Print()
        {
            Console.WriteLine($"Samochód ID {Id}: marka: {Brand}, rok produkcji: {Year}");
        }

        // metoda statyczna - wypisuje liczbę stworzonych samochodów
        public static void ShowCounter()
        {
            Console.WriteLine($"\nLiczba utworzonych samochodów: {Counter}\n");
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // pierwsze użycie klasy -> wywołuje się konstruktor statyczny
            // Próba utworzenia 4 samochodów przy limicie 3

            Car.ShowCounter();

            Car car1 = null;
            Car car2 = null;
            Car car3 = null;
            Car car4 = null;

            try
            {
                car1 = new Car();
                car2 = new Car("Toyota", 2022);
                car3 = new Car("Opel", 2000);
                car4 = new Car();

            }
            catch (InvalidOperationException ex) 
            {
                Console.WriteLine($"Błąd: {ex.Message}");
            }

            if (car1 != null) car1.Print();
            if (car2 != null) car2.Print();
            if (car3 != null) car3.Print();
            if (car4 != null) car4.Print();

            Car.ShowCounter();

        }
    }
}
