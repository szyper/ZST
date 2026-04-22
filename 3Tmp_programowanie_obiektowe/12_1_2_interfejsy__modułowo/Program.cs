using _12_1_interfejsy;
using _12_1_interfejsy.Interfaces;
using _12_1_interfejsy.Models;
using System.Security.Cryptography.X509Certificates;

namespace _12_1_interfejsy
{

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
