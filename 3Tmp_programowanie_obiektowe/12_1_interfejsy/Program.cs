namespace _12_1_interfejsy
{
    public class Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public void Eat()
        {
            Console.WriteLine("Zwierzę je");
        }

        public virtual void MakeSound()
        {
            Console.WriteLine("Zwierzę wydaje dźwięk");
        }
    }

    public interface IRun
    {
        void Run();
    }

    public interface ISwim
    {
        void Swim();
    }

    public class Dog : Animal, IRun, ISwim
    {
        public Dog(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public override void MakeSound()
        {
            Console.WriteLine("Pies szczeka");
        }
        public void Run()
        {
            Console.WriteLine("Pies biegnie");
        }

        public void Swim()
        {
            Console.WriteLine("Pies pływa");
        }

        public void Bark()
        {
            Console.WriteLine("Hau hau!");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog("Burek", 2);

            dog.Eat();
            dog.Run();
            dog.Swim();

// dodać właściwość rasa psa w Dog
// dodać metodę pokazująca informacje o zwierzęciu ShowInfo()\
// nowa klasa Cat, dziedziczy po Animal i implementuje interfejs IRun 
// Cat -> metody: Run(), MakeSound()
// lista zwierząt, w któej są zwierzęta (pies, kot)
// pętla wywołująca metodę MakeSound() dla wszystkich elementów listy



        }
    }
}
