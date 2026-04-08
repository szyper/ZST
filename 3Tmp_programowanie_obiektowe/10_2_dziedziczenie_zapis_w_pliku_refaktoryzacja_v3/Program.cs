
using _10_dziedziczenie.Services;

namespace _10_dziedziczenie
{
    internal class Program
    {
        // zadanie_1 biblioteka
        static void Main(string[] args)
        {
            var libraryService = new LibraryService();
            var menuService = new MenuService(libraryService);

            menuService.Run();
        }
    }
}
