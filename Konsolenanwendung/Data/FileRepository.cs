using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Konsolenanwendung.Data
{
    internal class FileRepository : IRepository
    {
        private const string CarsJsonPath = "cars.json";
        private const string CustomersJsonPath = "customers.json";
        private const string BookingsJsonPath = "bookings.json";
        private List<Car> cars = new List<Car>();
        private static List<Customer> customers = new List<Customer>();
        private static List<Booking> bookings = new List<Booking>();

        public FileRepository()
        {
            var carsJson = File.ReadAllText(CarsJsonPath);
            cars = JsonSerializer.Deserialize<List<Car>>(carsJson);

            var customersJson = File.ReadAllText(CustomersJsonPath);
            customers = JsonSerializer.Deserialize<List<Customer>>(customersJson);

            var bookingsJson = File.ReadAllText(BookingsJsonPath);
            bookings = JsonSerializer.Deserialize<List<Booking>>(bookingsJson);
        }

        public void AddCar(Car car)
        {
            cars.Add(car);
            SaveData();
        }

        public IEnumerable<Car> GetAllCars()
        {
            return cars;
        }

        public Car GetCars(int index)
        {
            return cars[index - 1];
        }

        public void AddCustomer(Customer customer)
        {
            customers.Add(customer);
            SaveData();
        }

        public IEnumerable<Customer> GetAllCustomer()
        {
            return customers;
        }

        public Customer GetCustomer(int index)
        {
            return customers[index - 1];
        }

        public void AddBooking(Booking booking)
        {
            bookings.Add(booking);
            SaveData();
        }

        public IEnumerable<Booking> GetAllBookings()
        {
            return bookings;
        }

        private void SaveData()
        {
            var carJson = JsonSerializer.Serialize(cars);
            File.WriteAllText(CarsJsonPath, carJson);

            var customersJson = JsonSerializer.Serialize(customers);
            File.WriteAllText(CustomersJsonPath, customersJson);

            var bookingsJson = JsonSerializer.Serialize(bookings);
            File.WriteAllText(BookingsJsonPath, bookingsJson);
        }
    }
}