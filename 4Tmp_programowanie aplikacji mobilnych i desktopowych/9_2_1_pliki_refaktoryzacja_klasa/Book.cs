using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9_2_1_pliki
{
    internal class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }

        public Book(string title, string author, int year, string genre)
        {
            Title = title;
            Author = author;
            Year = year;
            Genre = genre;
        }

        public override string ToString()
        {
            return $"{Title} - {Author} {Year}, gatunek: {Genre}";
        }

        // format CSV
        public string ToCsv()
        {
            return $"{Title};{Author};{Year};{Genre}";
        }

        // parsowanie CSV
        public static Book FromCsv(string line) 
        { 
            var parts = line.Split(';');
            return new Book(parts[0], parts[1], int.Parse(parts[2]), parts[3]);
        }
    }
}
