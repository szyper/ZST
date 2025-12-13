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
            string json = JsonSerializer.Serialize(person);
            Console.WriteLine(json);

            // deserializacja obiektu z formatu JSON
            Person person_d = JsonSerializer.Deserialize<Person>(json);
            Console.WriteLine("\nObiekt po deserializacji: ");
            Console.WriteLine("Imię: " + person_d.FirstName);
            Console.WriteLine("Nazwisko: " + person_d.LastName);
            Console.WriteLine("Wiek: " + person_d.Age);
        }
    }
}
