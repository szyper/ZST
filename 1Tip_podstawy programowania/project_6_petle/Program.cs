namespace project_6_petle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* Pętle są podstawowym mechanizmemw programowaniu. Służą do wielokrotnego wykonywania bloku kodu w zależności od spełnienia określonego warunku. 
              W C# są różne rodzaje pętli: FOR, WHILE, DO-WHILE, FOREACH
             */

            /* for - idealna, gdy znamy liczbę iteracji
             * while - używana, gdy warunek jest sprawdzany przed każdą iteracją
             * do-while - gwarantuje przynajmniej jedno wykonanie bloku kodu
             * foreach - przeznaczona do iteracji po kolekcjach, takich jak tablice, listy, bez konieczności ręcznego zarządzania indeksami
             */

            // pętla FOR
            /*
            for (inicjalizacja; warunek; aktualizacja)
            {
                
            }
            */

            // inicjalizacja - wykonywana raz przed rozpoczęciem pętli, zwykle deklaruje i inicjalizuje zmienną licznikową (np. int i = 1)

            // warunek - sprawdzany przed każdą iteracją, jeśli jest prawdziwy, kod w pętli jest wykonywany (np. i < 10)

            // aktualizacja - wykonywana po każdej iteracji, zwykle zmienia wartość zmiennej licznikowej (np. i++)




            // wyświetlenie liczb 1 - 10
            for (int i = 1; i <= 10; i++)
            {
                Console.Write($"{i} ");
            }
        }
    }
}
