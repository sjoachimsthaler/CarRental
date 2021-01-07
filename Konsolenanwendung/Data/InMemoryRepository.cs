using System.Collections.Generic;

namespace Konsolenanwendung.Data
{
    internal class InMemoryRepository : IRepository
    {
        private List<Car> cars = new List<Car>();
        private static List<Customer> customers = new List<Customer>();
        private static List<Booking> bookings = new List<Booking>();

        public void AddCar(Car car)
        {
            cars.Add(car);
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
        }

        public IEnumerable<Booking> GetAllBookings()
        {
            return bookings;
        }
    }
}