using System;
using System.Collections.Generic;
using System.Text;

namespace _10_dziedziczenie.Models
{
    internal class Author : Person
    {
        // public List<Book> BooksList { get; set; } = new List<Book>();
        public List<Book> BooksList { get; set; }

        public Author(string firstName, string lastName) : base(firstName, lastName)
        {
            BooksList = new List<Book>();
        }

        public void AddBook(Book book)
        {
            BooksList.Add(book);
        }
    }
}
