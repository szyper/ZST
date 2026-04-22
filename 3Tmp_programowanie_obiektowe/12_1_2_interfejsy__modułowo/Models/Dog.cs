using _12_1_interfejsy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _12_1_interfejsy.Models
{
    internal class Dog : Animal, IRun, ISwim, IHasOwner
    {
        public string Breed { get; set; }
        public string Owner { get; set; }
        public Dog(string name, int age, string breed, string owner) : base(name, age)
        {
            Breed = breed;
            Owner = owner;
        }

        public override void MakeSound()
        {
            Console.WriteLine("Pies szczeka");
        }
        public void Run()
        {
            Console.WriteLine("Pies biegnie");
        }

        public void Swim()
        {
            Console.WriteLine("Pies pływa");
        }

        public void Bark()
        {
            Console.WriteLine("Hau hau!");
        }

        public void ShowDogInfo()
        {
            Console.WriteLine($"Imię: {Name}, wiek: {Age}, rasa: {Breed}, właściciel: {Owner}");
        }
    }
}
