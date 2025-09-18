namespace _2_delegaty_zadanie_4
{
    internal class Program
    {
        public delegate void NotificationHandler(string message);

        public class EmailNotifier
        {
            public void SendEmail(string message)
            {
                Console.WriteLine($"Email wysłany: {message}");
            }
        }

        public class SMSNotifier
        {
            public void SendSMS(string message)
            {
                Console.WriteLine($"SMS wysłany: {message}");
            }
        }

        public class PushNotifier
        {
            public void SendPush(string message)
            {
                Console.WriteLine($"Powiadomienie push wysłane: {message}");
            }
        }

        public class NotificationManager
        {
            public NotificationHandler Notify;

            public void AddNotificationMethod(NotificationHandler handler)
            {
                if (Notify != null && Notify.GetInvocationList().Contains(handler)) 
                {
                    Console.WriteLine("Ta metoda powiadomienia jest już dodana");
                    return;
                }

                Notify += handler;
                Console.WriteLine("Dodano metodę powiadomienia");
            }

            public void RemoveNotificationMethod(NotificationHandler handler)
            {
                if (Notify != null && Notify.GetInvocationList().Contains(handler))
                {
                    Notify -= handler;
                    Console.WriteLine("Usunięto metodę powiadomienia");
                }
                else
                {
                    Console.WriteLine("Nie znaleziono takiej metody powiadomienia");
                }


            }

            public void SendNotification(string message)
            {
                if (Notify == null)
                {
                    Console.WriteLine("Brak dostępnych metod powiadomień. Dodaj co najmniej jedną metodę");
                    return;
                }

                foreach (var handler in Notify.GetInvocationList())
                {
                    try
                    {
                        handler.DynamicInvoke(message); // emailNotifier.SendEmail(message)

                        //2025-09-18 10:16:33
                        string logEntry = $"[{DateTime.Now: yyyy-MM-dd HH:mm:ss}] Wysłano: {handler.Method.Name}, wiadomość: {message}{Environment.NewLine}";
                        File.AppendAllText("log.txt", logEntry);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Błąd podczas wysyłania powiadomienia: {ex.Message}");
                    }
                }
            }

            public void ListNotificationMethods()
            {
                if (Notify == null)
                {
                    Console.WriteLine("Brak zarejestrowanych metod powiadomień");
                    return;
                }

                Console.WriteLine("Zarejestrowane metody powiadomień");

                var displayedHandlers = new HashSet<string>();

                foreach (var handler in Notify.GetInvocationList())
                {
                    var target = handler.Target;
                    var methodName = handler.Method.Name;
                    var className = target?.GetType().Name ?? "Nieznany";

                    var uniqueKey = $"{className}.{methodName}";

                    if (!displayedHandlers.Contains(uniqueKey))
                    {
                        displayedHandlers.Add(uniqueKey);
                        Console.WriteLine($"- klasa: {className}, metoda: {methodName}");
                    }
                }
            }

            internal void ShowLog()
            {
                if (!File.Exists("log.txt"))
                {
                    Console.WriteLine("Brak logów do wyświetlenia");
                    return;
                }

                Console.WriteLine("\n--- Zawartośc logów ---");
                string[] logLines = File.ReadAllLines("log.txt");

                if (logLines.Length == 0)
                {
                    Console.WriteLine("Plik logów jest pusty");
                }
                else
                {
                    foreach (var line in logLines) 
                    {
                        Console.WriteLine(line);
                    }
                }

                Console.WriteLine("--- Koniec logów ---\n");
            }
        }

        public static void ShowMenu()
        {
            Console.WriteLine("Menu");
            Console.WriteLine("1. Dodaj powiadomienie Email");
            Console.WriteLine("2. Dodaj powiadomienie SMS");
            Console.WriteLine("3. Dodaj powiadomienie Push");
            Console.WriteLine("4. Usuń powiadomienie Email");
            Console.WriteLine("5. Usuń powiadomienie SMS");
            Console.WriteLine("6. Usuń powiadomienie Push");
            Console.WriteLine("7. Wyślij powiadomienie");
            Console.WriteLine("8. Pokaż zarejestrowane metody powiadomień");
            Console.WriteLine("9. Pokaż log wysłanych powiadomień");
            Console.WriteLine("10. Zamknij program");
            Console.WriteLine("Wybierz opcję: ");
        }
        static void Main(string[] args)
        {
            //tworzenie instancji klas powiadomień
            var emailNotifier = new EmailNotifier();
            var smsNotifier = new SMSNotifier();
            var pushNotifier = new PushNotifier();

            //tworzenie instancji klasy NotificationManager
            var notificationManager = new NotificationManager();

            while (true)
            {
                try
                {
                    ShowMenu();
                    var choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            notificationManager.AddNotificationMethod(emailNotifier.SendEmail);
                            break;
                        case "2":
                            notificationManager.AddNotificationMethod(smsNotifier.SendSMS);
                            break;
                        case "3":
                            notificationManager.AddNotificationMethod(pushNotifier.SendPush);
                            break;
                        case "4":
                            notificationManager.RemoveNotificationMethod(emailNotifier.SendEmail);
                            break;
                        case "5":
                            notificationManager.RemoveNotificationMethod(smsNotifier.SendSMS);
                            break;
                        case "6":
                            notificationManager.RemoveNotificationMethod(pushNotifier.SendPush);
                            break;
                        case "7":
                            Console.Write("Wpisz wiadomość do wysłania: ");
                            var message = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(message))
                            {
                                Console.WriteLine("Wiadomość nie może być pusta. Spróbuj ponownie");
                            } else
                            {
                                notificationManager.SendNotification(message);
                            }
                            break;
                        case "8":
                            notificationManager.ListNotificationMethods();
                            break;
                        case "9":
                            notificationManager.ShowLog();
                            break;
                        case "10":
                            Console.WriteLine("Czy na pewno chcesz wyjść? (t/n):");
                            var confirmation = Console.ReadLine()?.ToLower();
                            if (confirmation == "t")
                            {
                                return;
                            }
                            break;
                        default:
                            Console.WriteLine("Nieporawidłowa opcja. Spróbuj ponownie");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Wystąpił błąd: {e.Message}");
                }
            }


            Console.ReadKey();
        }
    }
}