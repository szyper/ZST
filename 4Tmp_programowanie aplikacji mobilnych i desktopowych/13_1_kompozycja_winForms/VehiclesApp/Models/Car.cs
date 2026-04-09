using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesApp.Models
{
    internal class Car : Vehicle
    {
        public int NumberOfDoors
        {
            get; 
            set
            {
                if (value < 1 || value > 6)
                    throw new ArgumentException("Nieprawidłowa liczba drzwi");
            } 
        }

        // KOMPOZYCJA
        public Engine Engine { get; set; }
        public Radio Radio { get; set; }

        public Car(string brand, int year, int numberOfDoors) : base(brand, year)
        {
            NumberOfDoors = numberOfDoors;
        }

        public override void Start()
        {
            Console.WriteLine("Samochód został uruchomiony");
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Drzwi: {NumberOfDoors}");

            if (Engine != null)
            {
                Engine.ShowEngineInfo();
            }

            if (Radio != null)
            {
                Radio.ShowRadioInfo();
            }
        }
    }
}
