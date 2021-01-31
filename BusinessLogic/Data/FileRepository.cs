
using BusinessLogic.Model;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace BusinessLogic.Data
{
    public class FileRepository : IRepository
    {
        private static int carIndex = 1;
        private static int customerIndex = 1;
        private static int bookingIndex = 1;

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
            carIndex = cars.Max(c => c.ID) + 1;

            var customersJson = File.ReadAllText(CustomersJsonPath);
            customers = JsonSerializer.Deserialize<List<Customer>>(customersJson);
            customerIndex = customers.Max(c => c.ID) + 1;

            var bookingsJson = File.ReadAllText(BookingsJsonPath);
            bookings = JsonSerializer.Deserialize<List<Booking>>(bookingsJson);
            bookingIndex = bookings.Max(b => b.ID) + 1;
        }

        public void AddCar(Car car)
        {
            car.ID = carIndex++;
            cars.Add(car);
            SaveData();
        }

        public IEnumerable<Car> GetAllCars()
        {
            return cars;
        }

        public Car GetCars(int index)
        {
            return cars.SingleOrDefault(c => c.ID == index);
        }

        public void AddCustomer(Customer customer)
        {
            customer.ID = customerIndex++;
            customers.Add(customer);
            SaveData();
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return customers;
        }

        public Customer GetCustomer(int index)
        {
            return customers.SingleOrDefault(c => c.ID == index);
        }

        public void AddBooking(Booking booking)
        {
            booking.ID = bookingIndex++;
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

        public void EditCar(Car car)
        {
            var carToEdit = cars.Single(c => c.ID == car.ID);
            carToEdit.Manufacturer = car.Manufacturer;
            carToEdit.Model = car.Model;
            SaveData();
        }

        public void DeleteCar(int id)
        {
            var carToDelete = cars.Single(c => c.ID == id);
            cars.Remove(carToDelete);
            SaveData();
        }

        public void EditCustomer(Customer customer)
        {
            var customerToEdit = customers.Single(c => c.ID == customer.ID);
            customerToEdit.FirstName = customer.FirstName;
            customerToEdit.LastName = customer.LastName;
            SaveData();
        }

        public void DeleteCustomer(int id)
        {
            var customerToDelete = customers.Single(c => c.ID == id);
            customers.Remove(customerToDelete);
            SaveData();
        }

        public void DeleteBooking(int id)
        {
            throw new System.NotImplementedException();
        }

        public void EditBooking(Booking bookingToEdit)
        {
            throw new System.NotImplementedException();
        }
    }
}