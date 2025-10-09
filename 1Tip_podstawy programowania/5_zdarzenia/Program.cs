using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _5_zdarzenia
{
    internal class Program
    {
        public enum Role
        {
            Administrator,
            Manager,
            User
        }

        public enum Permission
        {
            Read,
            Write,
            Modify,
            ManageUsers
        }



        public class User
        {
            public string Username { get; set; }
            public List<Role> Roles { get; set; }

            public User(string username)
            {
                Username = username;
                Roles = new List<Role>();
            }

            public void AddRole(Role role)
            {
                if (!Roles.Contains(role))
                {
                    Roles.Add(role);
                }
            }

            public static void AddNewUser()
            {
                Console.Write("Podaj nazwę użytkownika: ");
                string newUser = Console.ReadLine();

                Console.Write("Podaj hasło użytkownika: ");
                string newPassword = Console.ReadLine();

                PasswordManager.SavePassword(newUser, newPassword);
                Console.WriteLine($"Dodano nowego użytkownika: {newUser}");
            }
        }

        public class RBAC
        {
            private readonly Dictionary<Role, List<Permission>> _rolePermissions;

            public RBAC() 
            {
                _rolePermissions = new Dictionary<Role, List<Permission>>
                {
                    { Role.Administrator, new List<Permission> { Permission.Read, Permission.Write, Permission.Modify, Permission.ManageUsers}},
                    { Role.Manager, new List<Permission> { Permission.Read, Permission.Write }},
                    { Role.User, new List<Permission> { Permission.Read }}
                };
            }

            public bool HasPermission(User user, Permission permission)
            {
                foreach (var role in user.Roles)
                {
                    if (_rolePermissions.ContainsKey(role) && _rolePermissions[role].Contains(permission))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public class PasswordManager
        {
            private const string _passwordFilePath = "userPasswords.txt";
            public static event Action<string, bool> PasswordVerified;

            static PasswordManager()
            {
                if (!File.Exists(_passwordFilePath))
                {
                    File.Create(_passwordFilePath).Dispose();
                }
            }

            public static void SavePassword(string username, string password)
            {
                if (File.ReadLines(_passwordFilePath).Any(line => line.Split(',')[0] == username))
                {
                    Console.WriteLine($"Użytkownik {username} już istnieje w systemie");
                    return;
                }

                string hashedPassword = HashPassword(password);
                File.AppendAllText(_passwordFilePath, $"{username},{hashedPassword}\n");
            }

            private static string HashPassword(string password)
            {
                using (var  sha256 = SHA256.Create())
                {
                    var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                    return Convert.ToBase64String(bytes);
                }
            }

            public static bool VerifyPassword(string username, string password)
            {
                string hashedPassword = HashPassword(password);
                foreach (var line in File.ReadLines(_passwordFilePath))
                {
                    var parts = line.Split(',');
                    if (parts[0] == username && parts[1] == hashedPassword)
                    {
                        PasswordVerified?.Invoke(username, true);
                        return true;
                    }
                }
                PasswordVerified?.Invoke(username, false);
                return false;
            }
        }

        public delegate void FileOperation(string filePath);

        public class FileManager
        {
            //odczyt zawartości pliku
            public static void ReadFile(string filePath)
            {
                if (File.Exists(filePath))
                {
                    string content = File.ReadAllText(filePath);
                    Console.WriteLine("Zawartość pliku:\n" + content);
                }
                else
                {
                    Console.WriteLine("Plik nie istnieje");
                }
            }

            //nadpisanie zawartości pliku
            public static void WriteToFile(string filePath)
            {
                if (File.Exists(filePath))
                {
                    Console.Write("Podaj tekst do zapisania w pliku: ");
                    string text = Console.ReadLine();
                    File.WriteAllText(filePath, text);
                    Console.WriteLine("Zapisano do pliku");
                }
                else
                {
                    Console.WriteLine("Plik nie istnieje");
                }
            }

            public static void ModifyFile(string filePath)
            {
                if (File.Exists(filePath))
                {
                    Console.Write("Podaj tekst, który będzie dopisany do pliku: ");
                    string text = Console.ReadLine();
                    File.AppendAllText(filePath, Environment.NewLine + text);
                    Console.WriteLine("Zmodyfikowano plik");
                }
                else
                {
                    Console.WriteLine("Plik nie istnieje");
                }
            }
        }


        static void Main(string[] args)
        {
            PasswordManager.PasswordVerified += (username1, success) => Console.WriteLine($"Logowanie użytkownika {username1}: {(success ? "udane" : "nieudane")}");

            PasswordManager.SavePassword("AdminUser", "admin");
            PasswordManager.SavePassword("ManagerUser", "admin");
            PasswordManager.SavePassword("User", "admin");
            PasswordManager.SavePassword("xyz", "admin");

            bool exitProgram = false;

            while (!exitProgram)
            {
                Console.Clear();
                Console.WriteLine("=== SYSTEM LOGOWANIA ===");

                Console.Write("Wprowadź nazwę użytkownika: ");
                string username = Console.ReadLine();

                Console.Write("Wprowadź hasło: ");
                string password = Console.ReadLine();

                if (!PasswordManager.VerifyPassword(username, password))
                {
                    Console.WriteLine("Niepoprawna nazwa użytkowniak lub hasło");
                    Console.ReadKey();
                    continue;
                }

                var user = new User(username);
                
                var userRoleMap = new Dictionary<string, Role> 
                {
                    { "AdminUser", Role.Administrator },
                    { "ManagerUser", Role.Manager },
                    { "User", Role.User }
                };

                if (userRoleMap.TryGetValue(username, out var role))
                {
                    user.AddRole(role);
                }
                else
                {
                    Console.WriteLine($"Użytkownik {username} nie ma przypisanej roli");
                    // user.AddRole(userRoleMap.TryGetValue(username, out var role1) ? role1 : Role.User);
                }

                var rbacSystem = new RBAC();
                string filePath = "testFile.txt";

                bool logout = false;
                while (!logout)
                {
                    Console.Clear();
                    Console.WriteLine($"Zalogowano jako: {username}");
                    Console.WriteLine("\nWybierz opcję");

                    // lista opcji menu: (numer, nazwa, akcja)
                    var menuOptions = new List<(int Number, string Description, Action Action)>();
                    int optionNumber = 1;

                    // dodawanie opcji na podstawie uprawnień
                    if (rbacSystem.HasPermission(user, Permission.Read))
                        menuOptions.Add((optionNumber++, "Odczytaj plik", () => FileManager.ReadFile(filePath)));
                    if (rbacSystem.HasPermission(user, Permission.Write))
                        menuOptions.Add((optionNumber++, "Zapisz do pliku", () => FileManager.WriteToFile(filePath)));
                    if (rbacSystem.HasPermission(user, Permission.Modify))
                        menuOptions.Add((optionNumber++, "Modyfikuj plik", () => FileManager.ModifyFile(filePath)));
                    if (rbacSystem.HasPermission(user, Permission.ManageUsers))
                        menuOptions.Add((optionNumber++, "Dodaj nowego użytkownika", () => User.AddNewUser()));

                    // dodanie opcji Wyloguj i Wyjdź z programu
                    int logoutOption = optionNumber++;
                    menuOptions.Add((logoutOption, "Wyloguj się", () => { Console.WriteLine("Wylogowano"); logout = true; }));

                    int exitOption = optionNumber++;
                    menuOptions.Add((exitOption, "Wyjdź z programu", () => { Console.WriteLine("Zamykanie programu"); exitProgram = true; }));


                    // wyświelenie menu
                    foreach (var option in menuOptions)
                    {
                        Console.WriteLine($"{option.Number}. {option.Description}");
                    }

                    Console.ReadLine();
                }
            }
        }
    }
}
