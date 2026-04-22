using System;
using System.Collections.Generic;
using System.Text;

namespace _12_1_interfejsy.Models
{
    internal class Fish : Animal
    {
        public Fish(string name, int age) : base(name, age) { }

        public override void MakeSound()
        {
            Console.WriteLine("Ryba nie wydaje dźwięku");
        }
    }
}
