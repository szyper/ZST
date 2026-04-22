using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesApp.Services
{
    internal class FaultService
    {
        private Random _random = new Random();

        public bool IsBroken()
        {
            return _random.Next(1, 101) <= 25;
        }

        public string GetRandomFault()
        {
            int value = _random.Next(1, 5);

            switch (value)
            {
                case 1:
                    return "Awaria silnika";
                case 2:
                    return "Przegrzanie układu";
                case 3:
                    return "Problem z elektroniką";
                default:
                    return "Usterka nieznanego pochodzenia";
            }
        }

        public void CheckVehicle(string vehicleName)
        {
            if (IsBroken())
            {
                Console.WriteLine($"[AWARIA] {vehicleName}: {GetRandomFault()}");
            } else
            {
                Console.WriteLine($"{vehicleName}: działa poprawnie");
            }
        }
    }
}
