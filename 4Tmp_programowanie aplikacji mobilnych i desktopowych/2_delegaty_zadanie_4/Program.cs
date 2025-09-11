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
        static void Main(string[] args)
        {
            //tworzenie instancji klas powiadomień
            var emailNotifier = new EmailNotifier();
            var smsNotifier = new SMSNotifier();
            var pushNotifier = new PushNotifier();

            //tworzenie instancji klasy NotificationManager
            var notificationManager = new NotificationManager();

            //dodawanie metod powiadomień do delegata
            notificationManager.AddNotificationMethod(emailNotifier.SendEmail);
            notificationManager.AddNotificationMethod(smsNotifier.SendSMS);
            notificationManager.AddNotificationMethod(pushNotifier.SendPush);

            //wysyłanie powiadomienia 
            notificationManager.SendNotification("Witaj, testowa wiadomość nr 1");


            //usuwanie metody powiadomienia SMS z delegata
            notificationManager.RemoveNotificationMethod(smsNotifier.SendSMS);


            //wysyłanie powiadomienia 
            notificationManager.SendNotification("Witaj, testowa wiadomość nr 2");

        }
    }
}
