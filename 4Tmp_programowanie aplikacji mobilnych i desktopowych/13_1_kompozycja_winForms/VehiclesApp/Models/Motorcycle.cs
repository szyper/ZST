using VehiclesApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesApp.Models
{
    internal class Motorcycle : Vehicle
    {
        private MotorcycleType _type;
        public MotorcycleType Type
        {
            get => _type;
            set
            {
                _type = value; 
            }
        }

        // KOMPOZYCJA
        public Engine Engine { get; set; }

        public Motorcycle(string brand, int year, MotorcycleType type) : base(brand, year)
        {
            Type = type;
        }

        public override void Start()
        {
            Console.WriteLine("Motocykl został uruchomiony");
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Typ: {Type}");

            if (Engine != null)
            {
                Engine.ShowEngineInfo();
            }
        }
    }
}
