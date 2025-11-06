namespace project_10_petle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool repeatProgram = true;
            do
            {
                Console.Write("Ile liczb chcesz wpisać? ");
                int count = int.Parse(Console.ReadLine());

                // pętla for - wypisanie liczb
                Console.WriteLine("\nPętla FOR - wypisuję liczby:");
                for (int i = 1; i <= count; i++)
                {
                    Console.WriteLine("Liczba: " + i);
                }

                // pętla while - sumowanie liczb
                int index = 1;
                int sum = 0;

                while (index <= count)
                {
                    sum += index;
                    index++;
                }

                Console.WriteLine("\nPętla while - suma liczb od 1 do " + count + " wynosi: " + sum);

                // pętla do while - pytanie o kontynuację
                string answer;

                do
                {
                    Console.Write("\nCzy chcesz powtórzyć program? (tak/nie): ");
                    answer = Console.ReadLine();
                }
                while (answer != "tak" && answer != "nie");

                repeatProgram = (answer == "tak");
                // Console.WriteLine(repeatProgram);
                Console.WriteLine();
            }
            while (repeatProgram);

            Console.WriteLine("Koniec programu");
        }
    }
}
