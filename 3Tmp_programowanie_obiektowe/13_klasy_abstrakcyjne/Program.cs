namespace _13_klasy_abstrakcyjne
{
    internal class Program
    {
        interface IRefundable
        {
            void Refund();
        }
        enum PaymentStatus
        {
            Pending,
            Completed,
            Failed
        }
        abstract class Payment
        {
            public decimal Amount { get; set; }

            public PaymentStatus Status { get; protected set; }

            protected Payment(decimal amount)
            {
                Amount = amount;
            }

            public void PrintSummary()
            {
                Console.WriteLine($"Kwota: {Amount} zł");
            }

            public abstract void ProcessPayment();

            public virtual void SendConfirmation()
            {
                Console.WriteLine("Wysłano standardowe potwierdzenie");
            }
        }

        class CardPayment : Payment, IRefundable
        {
            public CardPayment(decimal amount) : base(amount)
            {
            }

            public override void ProcessPayment()
            {
                Status = PaymentStatus.Completed;

                Console.WriteLine("Płatność kartą została wykonana");
            }

            public override void SendConfirmation()
            {
                Console.WriteLine("Wysłano potwierdzenie SMS dla karty");
            }

            public void Refund()
            {
                Console.WriteLine("Zwrot środków na kartę");
            }
        }

        class BlikPayment : Payment
        {
            public BlikPayment(decimal amount) : base(amount)
            {
            }
            public override void ProcessPayment()
            {
                Status = PaymentStatus.Completed;
                Console.WriteLine("Płatność BLIK została wykonana");
            }
        }

        class PayPalPayment : Payment, IRefundable
        {
            public string Email { get; set; }
            public PayPalPayment(decimal amount, string email) : base(amount)
            {
                Email = email;
            }

            public override void ProcessPayment()
            {
                Status = PaymentStatus.Completed;
                Console.WriteLine($"Płatność PayPal wykonana dla: {Email}");
            }

            public override void SendConfirmation()
            {
                Console.WriteLine($"Wysłano email potwierdzający do: {Email}");
            }

            public void Refund()
            {
                Console.WriteLine("Zwrot środków PayPal");
            }
        }

        static void Main(string[] args)
        {
            List<Payment> payments = new List<Payment>()
            { 
                new CardPayment(150),
                new BlikPayment(80),
                new PayPalPayment(220, "janusz@gmail.pl")
            };


            // polimorfizm
            // każdy obiekt wykonuje swoją własną wersję metod

            foreach (Payment payment in payments)
            {
                payment.PrintSummary();
                Console.WriteLine($"Status: {payment.Status}");
                payment.ProcessPayment();
                payment.SendConfirmation();
                Console.WriteLine($"Nowy status: {payment.Status}");

                Console.WriteLine();
            }

            Console.WriteLine("=== Zwroty ===");

            // sprawdzenie czy obiekt implementuje interfejs
            foreach (Payment payment in payments)
            {
                if (payment is IRefundable refundable)
                {
                    refundable.Refund();
                }
            }

        }
    }
}
