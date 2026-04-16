namespace _12_interfejsy
{
    class Book : IComparable<Book>
    {
        public string title;
        public string author;
        public int yearOfPublication;
        public double price;

        public Book(string title, string author, int yearOfPublication, double price)
        {
            this.title = title;
            this.author = author;
            this.yearOfPublication = yearOfPublication;
            this.price = price;
        }

        public override string ToString()
        {
            return $"{title}, {author}, {yearOfPublication}, {price} zł";
        }
        public int CompareTo(Book? other)
        {
            if (other == null)
            {
                return 1;
            }

            // return price.CompareTo(other.price);
            return -price.CompareTo(other.price);
            // return -author.CompareTo(other.author);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = new List<Book>();

            books.Add(new Book("Jaś i Małgosia", "Nowak", 1937, 45.99));
            books.Add(new Book("Jaś i Małgosia 2", "Pawlak", 2000, 155.99));
            books.Add(new Book("Jaś i Małgosia 4", "Arbuz", 2000, 5.99));
            books.Add(new Book("Jaś i Małgosia 3", "Arbuz", 1948, 5.99));

            foreach (Book book in books)
            {
                Console.WriteLine(book);
            }
            Console.WriteLine("   -----------------    ");

            // sortowanie według ceny nierosnąco
            books.Sort();

            foreach (Book book in books)
            {
                Console.WriteLine(book);
            }
            Console.WriteLine("    -------   ");

            // sortowanie według autora nierosnąco
            var sortedByAuthorDesc = books.OrderByDescending(book => book.author);

            foreach (Book book in sortedByAuthorDesc)
            {
                Console.WriteLine(book);
            }
            Console.WriteLine("    -------   ");


            // sortowanie według autora niemalejąco
            var sortedByAuthor = books.OrderBy(book => book.author);

            foreach (Book book in sortedByAuthor)
            {
                Console.WriteLine(book);
            }
            Console.WriteLine("    -------   ");

            // sortowanie według roku publikacji (rosnąco)
            var sortedByYear = books.OrderBy(book => book.yearOfPublication);
            foreach (Book book in sortedByYear)
            {
                Console.WriteLine(book);
            }
            Console.WriteLine("    -------   ");

            // najpierw sortowanie nierosnąco po cenie a następnie dla książek o tej samej cenie po roku publikacji (od najstarszej do najmłodszej)
            var sortedByPriceAndYear = books.OrderByDescending(b => b.price).ThenBy(b => b.yearOfPublication);
            foreach (Book book in sortedByPriceAndYear)
            {
                Console.WriteLine(book);
            }
            Console.WriteLine("    -------   ");

            Console.WriteLine("Sortowanie według tytułu, autora (malejąco), roku i ceny (malejąco)");
            var sortedByAll = books.OrderBy(b => b.title).ThenByDescending(b => b.author).ThenBy(b => b.yearOfPublication).ThenByDescending(b => b.price);

            foreach (Book book in sortedByAll)
            {
                Console.WriteLine(book);
            }
            Console.WriteLine("    -------   ");
        }
    }
}
