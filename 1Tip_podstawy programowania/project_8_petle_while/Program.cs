namespace project_8_petle_while
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            while (warunek)
            {
                kod do wykonania
            }
            */

            // licznik 1 - 5
            int counter = 1;

            while (counter <= 5)
            {
                Console.WriteLine("Licznik: " + counter);
                counter++; // counter = counter + 1
            }

            // hasło od użytkownika
            string password = "";

            while (password != "tajne")
            {
                Console.Write("Podaj hasło: ");
                password = Console.ReadLine();
            }
            Console.WriteLine("Dostęp przyznany");

            // nieskończona pętla
            while (true)
            {
                Console.Write("Wpisz 'q', aby zakończyć");
                string input = Console.ReadLine();

                if (input == "q")
                {
                    Console.WriteLine("Dziękujemy za zakończenie");
                    break;
                }
            }

            // dwa warunki keepRunning i counter
        }
    }
}
