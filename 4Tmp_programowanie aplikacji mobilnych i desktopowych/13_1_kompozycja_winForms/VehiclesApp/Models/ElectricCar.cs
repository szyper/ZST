using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesApp.Models
{
    internal class ElectricCar : Car
    {
        public int BatteryCapacity
        {
            get;
            set
            {
                if (value < 1 || value > 300)
                    throw new ArgumentException("Nieprawidłowa pojemność baterii");
            }
        }
        public ElectricCar(string brand, int year, int numberOfDoors, int batteryCapacity) : base(brand, year, numberOfDoors)
        {
            BatteryCapacity = batteryCapacity;
        }

        public override void Start()
        {
            Console.WriteLine("Samochód elektryczny został uruchomiony");
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Bateria: {BatteryCapacity} kWh");
        }
    }
}
