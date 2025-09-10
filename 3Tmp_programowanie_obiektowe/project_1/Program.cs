using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_1
{
  internal class Program
  {
    static void Main(string[] args)
    {
      Console.Write("ZST");
      Console.WriteLine("programowanie");
      Console.Write("test\n");
      Console.WriteLine("ZST");

      string firstName = "Jan";
      Console.WriteLine("Imię: " + firstName);

      Console.Write("Podaj nazwisko: ");
      string lastName = Console.ReadLine();
      Console.WriteLine("Podane nazwisko z klawiatury: " + lastName);

      int age = int.Parse(Console.ReadLine());
      if (age >= 18)
      {
        Console.WriteLine("Jesteś pełnoletni");
      }
      else
      {
        Console.WriteLine("Jesteś dzieckiem");
      }

    }
  }
}
