using System.Text.Json;

namespace _10_serializacja
{
    internal class Program
    {
        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
        }
        static void Main(string[] args)
        {
            Person person = new Person 
            { 
                FirstName = "Jan",
                LastName = "Nowak",
                Age = 20
            };

            // serializacja obiektu do formatu json
            string json = JsonSerializer.Serialize(person, new JsonSerializerOptions { WriteIndented = true });

            //Console.WriteLine(json);

            File.WriteAllText(@"C:\xampp\htdocs\js\files\filesperson.json", json);
            Console.WriteLine("Plik person.json został zapisany");

        }
    }
}
