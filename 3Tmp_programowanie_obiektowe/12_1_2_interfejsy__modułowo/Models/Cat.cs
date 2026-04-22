using _12_1_interfejsy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _12_1_interfejsy.Models
{
    internal class Cat : Animal, IRun
    {

        public Cat(string name, int age) : base(name, age) { }

        public override void MakeSound()
        {
            Console.WriteLine("Kot miauczy");
        }
        public void Run()
        {
            Console.WriteLine("Kot biegnie");
        }
    }
}
