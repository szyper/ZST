namespace project_7_petle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1 2 3 4 5 6 7 8 9 10
            for (int i = 1; i <= 10; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            // 10 9 8 7 6 5 4 3 2 1
            for (int i = 10; i >= 1; i--)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            // 2 4 6 8 10
            for (int i = 2; i <= 10; i = i + 2)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            // 2 4 6 8 10
            for (int i = 2; i <= 10; i += 2)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            // 2 4 6 8 10
            for (int i = 1; i <= 10; i++)
            {
                if (i % 2 == 0)
                {
                    Console.Write(i + " ");
                }
            }
            Console.WriteLine();

            // Suma liczb: 30 
            int sum = 0;
            for (int i = 1; i <= 10; i++)
            {
                if (i % 2 == 0)
                {
                    sum += i;
                }
            }
            Console.WriteLine($"Suma liczb: {sum}\n");

            /*
                11111
                22222
                33333
                44444
                55555
            */
            for (int i = 1; i <= 5 ; i++)
            {
                for (int j = 1; j <= 5; j++)
                {
                    Console.Write($"{i}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            /*
                [1,1]   [1,2]   [1,3]   [1,4]   [1,5]   [1,6]   [1,7]   [1,8]   [1,9]   [1,10]
                [2,1]   [2,2]   [2,3]   [2,4]   [2,5]   [2,6]   [2,7]   [2,8]   [2,9]   [2,10]
                [3,1]   [3,2]   [3,3]   [3,4]   [3,5]   [3,6]   [3,7]   [3,8]   [3,9]   [3,10]
                [4,1]   [4,2]   [4,3]   [4,4]   [4,5]   [4,6]   [4,7]   [4,8]   [4,9]   [4,10]
                [5,1]   [5,2]   [5,3]   [5,4]   [5,5]   [5,6]   [5,7]   [5,8]   [5,9]   [5,10]
            */
            for (int i = 1; i <= 5; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    Console.Write($"\t[{i},{j}]");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            /*
                * * *
                * * *
                * * *
                * * *
                * * *
            */
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }

        }
    }
}
