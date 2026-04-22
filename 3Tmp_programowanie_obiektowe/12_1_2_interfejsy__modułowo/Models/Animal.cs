using System;
using System.Collections.Generic;
using System.Text;

namespace _12_1_interfejsy.Models
{
    internal class Animal : IComparable<Animal>
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Animal(string name, int age)
        {
            Name = name;
            Age = age;
        }

        // implementacja interfejsu
        public int CompareTo(Animal? other)
        {
            if (other == null) return 1;
            return Age.CompareTo(other.Age);
        }

        public void Eat()
        {
            Console.WriteLine("Zwierzę je");
        }

        public virtual void MakeSound()
        {
            Console.WriteLine("Zwierzę wydaje dźwięk");
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Imię: {Name}, wiek: {Age}");
        }
    }
}
