using System;
using System.Collections.Generic;

namespace Konsolenanwendung
{
    class Program
    {
        private static int i = 1;
        private static string exitString = "3";
        private static List<Car> cars = new List<Car>();
        static void Main(string[] args)
        {
            string input;
            do
            {
                Console.WriteLine("Bitte auswählen...");
                Console.WriteLine("(1) Auto anlegen");
                Console.WriteLine("(2) Autos ausgeben");
                Console.WriteLine($"({exitString}) Beenden");

                input = Console.ReadLine();

                if (input == "1")
                {
                    Car car = CreateCar();
                    Console.WriteLine(car);
                    cars.Add(car);
                }
                else if (input == "2")
                {
                    foreach (var car in cars)
                    {
                        Console.WriteLine(car);
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

        private static Car CreateCar()
        {
            Car car = new Car();
            car.ID = i++;

            Console.WriteLine("Bitte Hersteller angeben...");
            car.Manufacturer = Console.ReadLine();
            Console.WriteLine("Bitte Modell angeben...");
            car.Model = Console.ReadLine();
            return car;
        }
    }
}
