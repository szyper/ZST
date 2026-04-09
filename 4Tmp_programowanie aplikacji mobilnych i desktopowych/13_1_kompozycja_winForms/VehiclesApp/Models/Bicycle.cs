using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesApp.Models
{
    internal class Bicycle : Vehicle
    {
        public int GearCount
        {
            get;
            set
            {
                if (value < 1 || value > 30)
                    throw new ArgumentException("nieprawidłowa liczba biegów");
            }
        }
        public Bicycle(string brand, int year, int gearCount) : base(brand, year)
        {
            GearCount = gearCount;
        }

        public override void Start()
        {
            Console.WriteLine("Rower jest gotowy do jazdy");
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Liczba biegów: {GearCount}");
        }
    }
}
