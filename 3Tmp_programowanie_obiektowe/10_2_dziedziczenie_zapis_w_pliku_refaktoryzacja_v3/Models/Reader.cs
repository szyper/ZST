using System;
using System.Collections.Generic;
using System.Text;

namespace _10_dziedziczenie.Models
{
    internal class Reader : Person
    {
        public List<Book> BorrowedBooksList { get; set; }
        public Reader(string firstName, string lastName) : base(firstName, lastName)
        {
            BorrowedBooksList = new List<Book>();
        }

        public void BorrowBook(Book book)
        {
            BorrowedBooksList.Add(book);
            Console.WriteLine($"Czytelnik {GetFullName()} wypożyczył książkę: {book.Title}");
        }
    }
}
