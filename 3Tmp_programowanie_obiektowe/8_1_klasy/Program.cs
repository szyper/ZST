namespace _8_1_klasy
{
    // enum definiujący możliwe rodzaje paliwa
    public enum FuelType
    {
        Gasoline = 1, // benzyna (petrol)
        Diesel = 2, // olej napędowy
        Electric = 3, // w pełni elektryczny
        Hybrid = 4, // benzyna / elektryk
        LPG = 5, // gaz
        Hydrogen = 6 // (H2 / FCEV)
    }

    // definicja klasy Car
    public class Car
    {
        // prywatne pola
        private string brand;
        private string model;
        private int year;
        private FuelType fuelType; // pole typu enum
        private DateTime firstRegistrationDate;

        // publiczne właściwości zachowują hermetyzację (pola pozostają prywatne)
        public string Brand {
            // getter - zwraca aktualną wartość marki
            get { return brand; }

            // setter - pozwala na zmianę marki
            set { brand = value; }
        }

        // publiczna właściwość Model - umozliwia odczyt i zapis modelu samochodu
        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        // publiczna właściwość Year - odczyt i zapis roku produkcji z walidacją
        public int Year
        {
            // getter - zwraca aktualny rok produkcji
            get { return year; }

            // setter - ustawia rok produkcji, ale nie pozwala na wartość wcześniejszą niż 1886
            // (1886 to rok skonstruowania pierwszeg osamochodu przez karla Benza)
            set 
            {
                if (value < 1886)
                {
                    // throw new ArgumentException("Rok produkcji nie może być wcześniejszy niż 1886");

                    Console.WriteLine("Błąd: rok produkcji nie może być wcześniejszy niż 1886");
                    Console.WriteLine($"Podano {value}");
                    return;
                }
                    year = value;
            }
        }

        // właściwość FuelType
        public FuelType FuelType
        {
            get { return fuelType; }
            set {  fuelType = value; }
        }

        // data pierwszej rejestracji - walidacja z komunikatami
        public DateTime FirstRegistrationDate
        {
            get { return firstRegistrationDate; }
            set
            {
                // nie może być z przyszłości
                if (value > DateTime.Today)
                {
                    Console.WriteLine($"Błąd: Data {value:d} jest z przyszłości! ustawiamy dzisiejszą datę");
                    firstRegistrationDate = DateTime.Today;
                    return;
                }
                
                // nie wcześniejsza niż 1886
                if (value.Year < 1886)
                {
                    Console.WriteLine("Błąd: pierwszy samochód powstał w 1886! Ustawiam 1 stycznia 1886");
                    firstRegistrationDate = new DateTime(1886, 1, 1);
                    return;
                }

                firstRegistrationDate = value;
            }
        }

        // tłumaczenie z angielskiego na polski
        public string GetFuelTypeInPolish()
        {
            return FuelType switch
            {
                FuelType.Gasoline => "Benzyna",
                FuelType.Diesel   => "Diesel",
                FuelType.Electric => "Elektryczny",
                FuelType.Hybrid   => "Hybryda",
                FuelType.LPG      => "LPG (gaz)",
                FuelType.Hydrogen => "Wodór",
                _                 => "Nieznane paliwo"
            };
        }

        // metoda wyświetlająca informacje o samochodzie
        public void Display()
        {
            Console.WriteLine($"Marka: {Brand}");
            Console.WriteLine($"Model: {Model}");
            Console.WriteLine($"Rok produkcji: {Year}");
            Console.WriteLine($"Paliwo: {GetFuelTypeInPolish()}");
            Console.WriteLine($"Data produkcji: {FirstRegistrationDate}");
            Console.WriteLine();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // utworzenie obiektu klasy
            Car car1 = new Car();

            car1.Brand = "Ferrari";
            car1.Model = "F430";
            //car1.Year = 1700;
            car1.Year = 2020;

            //Console.WriteLine(car1.Year);

            car1.FuelType = FuelType.Hydrogen;
            car1.Display();

            car1.FirstRegistrationDate = new DateTime(2980, 8, 20);
            Console.WriteLine(car1.FirstRegistrationDate);
        }
    }
}
