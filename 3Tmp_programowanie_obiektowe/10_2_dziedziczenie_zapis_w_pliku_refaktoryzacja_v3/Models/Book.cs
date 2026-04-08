using System;
using System.Collections.Generic;
using System.Text;

namespace _10_dziedziczenie.Models
{
    internal class Book
    {
        public string Title { get; set; }
        public Author Author { get; set; }
        public int PublicationYear { get; set; }

        public Book(string title, Author author, int publicationYear)
        {
            Title = title;
            Author = author;
            PublicationYear = publicationYear;
        }

        // refaktoryzacja - metoda do wyświetlenia
        public string GetBookInfo()
        {
            return $"{Title} - {Author.GetFullName()} ({PublicationYear})";
        }
    }
}
