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

    public enum CarCondition
    {
        Nowy,
        Używany,
        Uszkodzony,
        Odnowiony
    };

    // definicja klasy Car
    public class Car
    {
        // prywatne pola
        private string brand;
        private string model;
        private int year;
        private FuelType fuelType; // pole typu enum
        private DateTime firstRegistrationDate;
        private CarCondition condition; // stan samochodu

        // pole readonly - ustawiane tylko raz
        private readonly DateTime createdAt = DateTime.Now;

        // publiczne właściwości zachowują hermetyzację (pola pozostają prywatne)
        public string Brand
        {
            // getter - zwraca aktualną wartość marki
            get { return brand; }

            // setter - pozwala na zmianę marki (walidacja długości / pustej wartości)
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Marka nie może być pusta");
                    return;
                }
                brand = value;
            }
        }

        // publiczna właściwość Model - umozliwia odczyt i zapis modelu samochodu (setter z normalizacją danych)
        public string Model
        {
            get { return model; }
            set { model = value.Trim(); }
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

        // właściwość automatyczna
        public string Color { get; set; }

        // właściwość FuelType
        public FuelType FuelType
        {
            get { return fuelType; }
            set { fuelType = value; }
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

        // właściwośc tylko do odczytu (wiek samochodu)
        public int Age
        {
            get { return DateTime.Today.Year - Year; }
        }

        // właściwość zależna od enum - czy samochód jest ekologiczny
        public bool IsEcoFriendly
        {
            get
            {
                return FuelType == FuelType.Electric || FuelType == FuelType.Hybrid || fuelType == FuelType.Hydrogen;
            }
        }

        // właściwość obliczana - lata od pierwszej rejestracji
        public int yearsSinceRegistration 
        { 
            get { return DateTime.Today.Year - FirstRegistrationDate.Year; }
        }

        // właściwość tylko do odczytu - data utworzenia obiektu
        public DateTime CreatedAt
        {
            get { return createdAt; }
        }

        // właściwość init
        public string VIN { get; init; }

        // właściwość init (C# 9+), aktualna wersja C# 14 (w .NET 10)
        // jest to właściwość z akcesorem init, wprowadzona w C# 9.0
        // pozwala utworzyć wartość tylko podczas tworzenia obiektu, nie pozwala zmienić wartości poźniej!
        // można przypisać wartość przy inicjalizacji
        // po utworzeniu obiektu -> właściwość staje się tylko do odczytu
        // wykorzystanie init zwiększa bezpieczeństwo danych i wspiera niemutowalność obiektu
        // niemutowalny obiekt to obiekt, którego stan (wartości jego pól/właściwości) nie może się zmienić po jego utworzeniu 
        public string CountryOfOrigin { get; init; }

        // FullName - pełna nazwa samochodu, tylko do odczytu
        public string FullName => $"{brand} {Model} ({Year})";

        // Description - pełny opis samochodu, tylko do odczytu
        public string Description => $"Samochód {FullName}, paliwo: {GetFuelTypeInPolish()}, " + 
                                     $"{(IsEcoFriendly ? "ekologiczny" : "nieekologiczny")}, " +
                                     $"kraj pochodzenia: {CountryOfOrigin}";

        // publiczna właściwość z zabezpieczeniami
        public CarCondition Condition
        {
            get => condition;
            set
            {
                // walidacja: wartość musi być poprawnym enumem
                if (!Enum.IsDefined(typeof(CarCondition), value))
                {
                    Console.WriteLine("Błąd: nieprawidłowy stan samochodu. Ustawiam domyślnie UŻYWANY");
                    condition = CarCondition.Używany;
                    return;
                }
                condition = value;
            }
        }

        // tłumaczenie z angielskiego na polski
        public string GetFuelTypeInPolish()
        {
            return FuelType switch
            {
                FuelType.Gasoline => "Benzyna",
                FuelType.Diesel => "Diesel",
                FuelType.Electric => "Elektryczny",
                FuelType.Hybrid => "Hybryda",
                FuelType.LPG => "LPG (gaz)",
                FuelType.Hydrogen => "Wodór",
                _ => "Nieznane paliwo"
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

        public string GetFullDescription()
        {
            string fuelPolish = GetFuelTypeInPolish();

            string ecoStatus = IsEcoFriendly ? "ekologiczny" : "nieekologiczny";

            return $"Samochód {brand} {Model.Trim()} ({Year}), paliwo: {fuelPolish}, " +
                   $"{ecoStatus}, kraj pochodzenia: {CountryOfOrigin}, " +
                   $"wiek: {Age} lat, od rejestracji: {yearsSinceRegistration} lat, " +
                   $"obiekt utworzono {CreatedAt}, VIN: {VIN}";
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

            //car1.FirstRegistrationDate = new DateTime(2980, 8, 20);
            //Console.WriteLine(car1.FirstRegistrationDate);

            // ##########################################################

            Car car2 = new Car
            {
                Brand = "Ferrari",
                Model = "F430",
                CountryOfOrigin = "Włochy",
                VIN = "123341GD43342342",
                Year = 2020,
                FuelType = FuelType.Hybrid,
                FirstRegistrationDate = new DateTime(2020, 6, 20)
            };

            Console.WriteLine(car2.GetFullDescription() + "\n");

            // ##########################################################

            Car car3 = new Car()
            {
                VIN = "1234QWERT65709CV",
                CountryOfOrigin = "Niemcy"
            };

            car3.Brand = "Porsche";
            car3.Model = "911";
            car3.Year = 2019;
            car3.Color = "Czarny";
            car3.FuelType = FuelType.Gasoline;
            car3.FirstRegistrationDate = new DateTime(2019, 3, 20);

            Console.WriteLine(car3.GetFullDescription());
            Console.WriteLine();
            Console.WriteLine(car3.GetFullDescription());

            Console.WriteLine(car3.Condition);

            car3.Condition = CarCondition.Nowy;
            Console.WriteLine($"Stan samochodu: {car3.Condition}");

            car3.Condition = (CarCondition)2;
            Console.WriteLine($"Stan samochodu: {car3.Condition}"); // Uszkodzony

            car3.Condition = (CarCondition)20;
            Console.WriteLine($"Stan samochodu: {car3.Condition}"); // Używany

            Console.ReadKey();
        }
    }
}