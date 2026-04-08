using _11_kompozycja.Models;
using _11_kompozycja.Services;

Console.WriteLine("=== SYSTEM POJAZDÓW ===");

//List<Vehicle> vehicles = new();
List<Vehicle> vehicles = new List<Vehicle>();

FaultService faultService = new FaultService();
StatisticsService statisticsService = new StatisticsService();

Car car = new("BYD", 2000, 5);
car.Engine = new Engine(400, _11_kompozycja.Models.Enums.EngineType.Petrol);
car.Radio = new Radio(true);

Motorcycle moto = new("Yamaha", 2022, _11_kompozycja.Models.Enums.MotorcycleType.Off_Road);
moto.Engine = new Engine(100, _11_kompozycja.Models.Enums.EngineType.Petrol);

Bicycle bike1 = new("Romet", 2025, 21);
Bicycle bike2 = new("Romet", 2026, 21);

ElectricCar eCar = new("Tesla", 2024, 5, 75);
eCar.Radio = new Radio(true);

vehicles.Add(car);
vehicles.Add(moto);
vehicles.Add(bike1);
vehicles.Add(bike2);
vehicles.Add(eCar);


foreach (Vehicle v in vehicles)
{
    v.Start();
    v.ShowInfo();
    faultService.CheckVehicle(v.Brand);
    Console.WriteLine("------------------");
}

Console.WriteLine();

statisticsService.ShowSummary(vehicles);

Console.WriteLine("\nNaciśnij dowolny klawisz, aby zakończyć");
Console.ReadKey();