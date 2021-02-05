
using BusinessLogic.Data;
using BusinessLogic.Model;

using System;

namespace Konsolenanwendung
{
    class Program
    {
        
        private static IRepository Repository = new InMemoryRepository();
        private static string exitString = "7";

        static void Main(string[] args)
        {

            string input;
            do
            {
                Console.WriteLine("Bitte auswählen...");
                Console.WriteLine("(1) Auto anlegen");
                Console.WriteLine("(2) Autos ausgeben");
                Console.WriteLine("(3) Kunde anlegen");
                Console.WriteLine("(4) Kunden ausgeben");
                Console.WriteLine("(5) Buchung anlegen");
                Console.WriteLine("(6) Buchungen ausgeben");
                Console.WriteLine($"({exitString}) Beenden");

                input = Console.ReadLine();

                if (input == "1")
                {
                    Car car = CreateCar();
                    Repository.AddCar(car);
                    Console.WriteLine(car);
                    
                }
                else if (input == "2")
                {
                    PrintCars();
                }
                else if (input == "3")
                {
                    Customer customer = CreateCustomer();
                    Console.WriteLine(customer);
                    Repository.AddCustomer(customer);
                }
                else if (input == "4")
                {
                    PrintCustomers();
                }
                else if (input == "5")
                {
                    Booking booking = CreateBooking();
                    Console.WriteLine(booking);
                    Repository.AddBooking(booking);
                }
                else if (input == "6")
                {
                    foreach (var booking in Repository.GetAllBookings())
                    {
                        Console.WriteLine(booking);
                    }
                }
                else if (input == exitString)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Keine gültige Eingabe");
                }
            } while (input != exitString);
        }

        private static void PrintCustomers()
        {
            foreach (Customer customer in Repository.GetAllCustomers())
            {
                Console.WriteLine(customer);
            }
        }

        private static void PrintCars()
        {
            foreach (var car in Repository.GetAllCars())
            {
                Console.WriteLine(car);
            }
        }

        private static Booking CreateBooking()
        {
            Booking booking = new Booking();
            Console.WriteLine("Bitte Auto auswählen...");
            PrintCars();
            int index = int.Parse(Console.ReadLine());
            booking.Car = Repository.GetCar(index);
            Console.WriteLine("Bitte Kunde auswählen...");
            PrintCustomers();
            index = int.Parse(Console.ReadLine());
            booking.Customer = Repository.GetCustomer(index);

            Console.WriteLine("In wievielen Tagen möchten sie das Auto ausleihen?");
            var days = int.Parse(Console.ReadLine());
            booking.From = DateTime.Now.AddDays(days).Date;

            Console.WriteLine("Wie viele Tagen möchten sie das Auto ausleihen?");
            days = int.Parse(Console.ReadLine());
            booking.To = booking.From.AddDays(days);

            return booking;
        }

        private static Customer CreateCustomer()
        {
            Customer customer = new Customer();
            Console.WriteLine("Bitte Vorname angeben...");
            customer.FirstName = Console.ReadLine();
            Console.WriteLine("Bitte Nachname angeben...");
            customer.LastName = Console.ReadLine();
            return customer;
        }

        private static Car CreateCar()
        {
            Car car = new Car();

            Console.WriteLine("Bitte Hersteller angeben...");
            car.Manufacturer = Console.ReadLine();
            Console.WriteLine("Bitte Modell angeben...");
            car.Model = Console.ReadLine();
            return car;
        }
    }
}
