namespace _1_delegaty_zadanie_1
{
    internal class Program
    {
        public delegate float Operation(float x, float y);

        public static float Add(float x, float y)
        {
            return x + y;
        }

        public static float Subtract(float x, float y)
        {
            return x - y;
        }

        public static float Multiply(float x, float y)
        {
            return x * y;
        }

        public static float Divide(float x, float y)
        {
            return x / y;
        }

        public static void DisplayResult(Operation op, float x, float y)
        {
            float result;

            if (op.Method.Name == "Divide" && y == 0)
            {
                Console.WriteLine("Błędne dzielenie przez 0");
                result = 0;
            }
            else
            {
                try
                {
                    result = op(x, y);
                    Console.WriteLine("Wynik operacji {0} na liczbach {1} i {2} wynosi {3}", op.Method.Name, x, y, result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    result = 0;
                }
            }
        }

        public static float GetFloatFromUser(string prompt)
        {
            Console.Write(prompt);
            float number;

            bool isValid = float.TryParse(Console.ReadLine(), out number) && number >= 0;

            while (!isValid)
            {
                Console.Write("Nieprawidłowe dane. Podaj liczbę zmiennoprzecinkową nieujemną");
                isValid = float.TryParse(Console.ReadLine(), out number) && number >= 0;
            }
            return number;
        }

        static void Main(string[] args)
        {
            float a = GetFloatFromUser("Podaj pierwszą liczbę: ");
            float b = GetFloatFromUser("Podaj drugą liczbę: ");

            //ustawienie instancji delegatów dla każdej operacji
            Operation adding = new Operation(Add);
            Operation substracting = new Operation(Subtract);
            Operation multiplying = new Operation(Multiply);
            Operation dividing = new Operation(Divide);

            //wyświetlenie wyników operacji
            DisplayResult(adding, a, b);
            DisplayResult(substracting, a, b);
            DisplayResult(multiplying, a, b);
            DisplayResult(dividing, a, b);

            Console.ReadKey();
        }
    }
}
