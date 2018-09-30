using System;
using System.Threading;

namespace StackMemoryManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleMethod();
            ComplexMethod();

            Console.WriteLine("Waiting 10 minutes...");
            Thread.Sleep(TimeSpan.FromMinutes(10));
            Console.WriteLine("Done");
        }

        static void SimpleMethod()
        {
            var modem = new SimpleModem();
            var phoneNumber = GetPhoneNumber();
            modem.Call(phoneNumber);
            modem.SendMessage(phoneNumber);
        }

        static void ComplexMethod()
        {
            var modem = new ComplexModem();
            var phoneNumber = GetPhoneNumber();
            var called = modem.Call(phoneNumber);
            var messageSent = modem.SendMessage(phoneNumber);
            if (!called || !messageSent)
            {
                Console.WriteLine("Something went wrong");
            }
        }

        static PhoneNumber GetPhoneNumber()
        {
            Console.Write("Enter the phone number: ");
            var number = Console.ReadLine();
            return new PhoneNumber(number);
        }
    }

    public struct PhoneNumber
    {
        public string Number { get; set; }

        public PhoneNumber(string number)
        {
            Number = number;
        }
    }

    public class SimpleModem
    {
        public void Call(PhoneNumber number)
        {
            Console.WriteLine("Calling " + number.Number);
        }

        public void SendMessage(PhoneNumber number)
        {
            Console.WriteLine("Sending message to " + number.Number);
        }
    }

    public class ComplexModem
    {
        public bool Call(PhoneNumber number)
        {
            Console.WriteLine("Calling " + number.Number);
            return Console.ReadKey(true).Key == ConsoleKey.Enter;
        }

        public bool SendMessage(PhoneNumber number)
        {
            Console.WriteLine("Sending message to " + number.Number);
            return Console.ReadKey(true).Key == ConsoleKey.Enter;
        }
    }
}