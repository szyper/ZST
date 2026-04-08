using _11_kompozycja.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace _11_kompozycja.Models
{
    internal class Engine
    {
        private int _power;
        private EngineType _type;
        public int Power 
        { 
            get => _power;
            set
            {
                if (value <= 0 || value > 2000)
                    throw new ArgumentException("Nieprawidłowa moc silnika");
                _power = value;
            }
        }

        public EngineType Type
        {
            get => _type;
            set
            {
                _type = value;
            }
        }
        
        public Engine(int power,  EngineType type)
        {
            Power = power;
            Type = type; 
        }
        public void ShowEngineInfo()
        {
            Console.WriteLine($"Silnik: {Type}, moc: {Power} KM");
        }
    }
}
