using System;
using System.Collections.Generic;
using System.Text;

namespace _10_dziedziczenie.Models
{
    internal class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        // refaktoryzacja - metoda pomocnicza
        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
