using _12_1_interfejsy;
using System.Security.Cryptography.X509Certificates;

namespace _12_1_interfejsy
{
    public class Animal : IComparable<Animal>
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Animal(string name, int age)
        {
            Name = name;
            Age = age;
        }

        // implementacja interfejsu
        public int CompareTo(Animal? other)
        {
            if (other == null) return 1;
            return Age.CompareTo(other.Age);
        }

        public void Eat()
        {
            Console.WriteLine("Zwierzę je");
        }

        public virtual void MakeSound()
        {
            Console.WriteLine("Zwierzę wydaje dźwięk");
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Imię: {Name}, wiek: {Age}");
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

    public interface IHasOwner
    {
        string Owner { get; set; }
    }

    public class Dog : Animal, IRun, ISwim, IHasOwner
    {
        public string Breed { get; set; }
        public string Owner { get; set; }
        public Dog(string name, int age, string breed, string owner) : base(name, age)
        {
            Breed = breed;
            Owner = owner;
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

        public void ShowDogInfo()
        {
            Console.WriteLine($"Imię: {Name}, wiek: {Age}, rasa: {Breed}, właściciel: {Owner}");
        }
    }

    public class Cat : Animal, IRun
    {
        public Cat(string name, int age) : base(name, age) { }

        public override void MakeSound()
        {
            Console.WriteLine("Kot miauczy");
        }
        public void Run()
        {
            Console.WriteLine("Kot biegnie");
        }
    }

    public class Fish : Animal
    {
        public Fish(string name, int age) : base(name, age) { }

        public override void MakeSound()
        {
            Console.WriteLine("Ryba nie wydaje dźwięku");
        }
    }
}
internal class Program
{
    static void Main(string[] args)
    {
        Dog dog = new Dog("Burek", 2, "Pudel", "Janusz");
        Cat cat = new Cat("Mruczek", 5);
        Cat cat1 = new Cat("Mruczek", 1);

        Fish fish = new Fish("Nemo", 1);

        dog.Eat();
        dog.Run();
        dog.Swim();
        dog.ShowInfo();
        dog.ShowDogInfo();

        Console.WriteLine();

        cat.Eat();
        cat.Run();
        cat.ShowInfo();

        Console.WriteLine("\nLista zwierząt:");

        List<Animal> aninmals = new List<Animal>();
        aninmals.Add(dog);
        aninmals.Add(cat);
        aninmals.Add(cat1);
        aninmals.Add(fish);

        foreach (Animal animal in aninmals)
        {
            animal.MakeSound();
        }

        Console.WriteLine("\n\nPrzed sortowaniem:");
        foreach (Animal animal in aninmals)
        {
            animal.ShowInfo();
        }

        // sortowanie po wieku
        aninmals.Sort();

        Console.WriteLine("\nPo sortowaniu (niemalejąco według wieku)");
        foreach (Animal animal in aninmals)
        {
            animal.ShowInfo();
        }

        Console.WriteLine("\nBiegnące zwierzęta:");
        foreach (Animal animal in aninmals)
        {
            if (animal is IRun runner)
                runner.Run();
        }
    }
}
