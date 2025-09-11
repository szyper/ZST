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
                Notify += handler;
            }

            public void RemoveNotificationMethod(NotificationHandler handler)
            {
                Notify -= handler;
            }

            public void SendNotification(string message) 
            {
                //if (Notify != null)
                //{
                //    Notify.Invoke(message);
                //}

                Notify?.Invoke(message);
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
            Console.WriteLine("8. Zamknij program");
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
                            Console.WriteLine("Dodano powiadomienie Email");
                            break;
                        case "2":
                            notificationManager.AddNotificationMethod(smsNotifier.SendSMS);
                            Console.WriteLine("Dodano powiadomienie SMS");
                            break;
                        case "3":
                            notificationManager.AddNotificationMethod(pushNotifier.SendPush);
                            Console.WriteLine("Dodano powiadomienie Push");
                            break;
                        case "4":
                            notificationManager.RemoveNotificationMethod(emailNotifier.SendEmail);
                            Console.WriteLine("Usunięto powiadomienie Email");
                            break;
                        case "5":
                            notificationManager.RemoveNotificationMethod(smsNotifier.SendSMS);
                            Console.WriteLine("Usunięto powiadomienie SMS");
                            break;
                        case "6":
                            notificationManager.RemoveNotificationMethod(pushNotifier.SendPush);
                            Console.WriteLine("Usunięto powiadomienie Push");
                            break;
                        case "7":
                            Console.Write("Wpisz wiadomość do wysłania: ");
                            var message = Console.ReadLine();
                            notificationManager.SendNotification(message);
                            break;
                        case "8":
                            return;
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
