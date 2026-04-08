using System;
using System.Collections.Generic;
using System.Text;

namespace _11_kompozycja.Models
{
    internal class Bicycle : Vehicle
    {
        public int GearCount 
        { 
            get; 
            set
            {
                if (value < 1 || value > 30)
                    throw new ArgumentException("Nieprawidłowa liczba biegów");
            } 
        }
        public Bicycle(string brand, int year, int gears) : base(brand, year)
        {
            GearCount = gears;
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
