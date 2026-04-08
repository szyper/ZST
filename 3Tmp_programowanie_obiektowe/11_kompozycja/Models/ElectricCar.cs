using System;
using System.Collections.Generic;
using System.Text;

namespace _11_kompozycja.Models
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
        public ElectricCar(string brand, int year, int doors, int battery) : base(brand, year, doors)
        {
            BatteryCapacity = battery;
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
