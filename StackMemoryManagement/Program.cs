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
            Thread.Sleep(TimeSpan.FromMinutes(10));
        }

        static void SimpleMethod()
        {
            var modem = new SimpleModem();
            var phoneNumber = new PhoneNumber();
            modem.Call(phoneNumber);
            modem.SendMessage(phoneNumber);
        }

        static void ComplexMethod()
        {
            var modem = new ComplexModem();
            var phoneNumber = new PhoneNumber();
            var called = modem.Call(phoneNumber);
            var messageSent=modem.SendMessage(phoneNumber);
            if (!called || !messageSent)
            {
                Console.WriteLine("Something went wrong");
            }
        }
    }

    public struct PhoneNumber
    {
    }

    public class SimpleModem
    {
        public void Call(PhoneNumber number)
        {
        }

        public void SendMessage(PhoneNumber number)
        {
        }
    }

    public class ComplexModem
    {
        public bool Call(PhoneNumber number)
        {
            return true;
        }

        public bool SendMessage(PhoneNumber number)
        {
            return true;
        }
    }
}