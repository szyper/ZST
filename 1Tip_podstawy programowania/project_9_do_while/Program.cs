namespace project_9_do_while
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // byte 0-255
            byte counter = 1;

            do
            {
                Console.WriteLine("Licznik: " + counter);
                counter++;
            }
            while (counter <= 3);

            Console.WriteLine("Koniec pętli");

            // pętla z wejściem od użytkownika
            string password;

            do
            {
                Console.Write("Podaj hasło: ");
                password = Console.ReadLine();
            }
            while (password != "tajne");

            Console.WriteLine("Dostęp przyznany");

            // dwa warunki (do while)
            counter = 0;
            int sum = 0;

            do
            {
                Console.Write("Podaj liczbę (0 kończy program): ");
                int number = int.Parse(Console.ReadLine());

                if (number == 0)
                {
                    break;
                }

                sum += number;
                counter++;
            }
            while (sum < 20 && counter < 4);

            Console.WriteLine("Suma liczb: " + sum);
            Console.WriteLine("Liczba wprowadzonych wartości: " + counter);
            Console.WriteLine("Koniec programu");
        }
    }
}
