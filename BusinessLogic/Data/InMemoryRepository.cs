
using BusinessLogic.Model;

using System.Collections.Generic;

namespace BusinessLogic.Data
{
    public class InMemoryRepository : IRepository
    {
        private static int carIndex = 1;
        private static int customerIndex = 1;
        private static int bookingIndex = 1;

        private List<Car> cars = new List<Car>();
        private static List<Customer> customers = new List<Customer>();
        private static List<Booking> bookings = new List<Booking>();

        public void AddCar(Car car)
        {
            car.ID = carIndex++;
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
            customer.ID = customerIndex++;
            customers.Add(customer);
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return customers;
        }

        public Customer GetCustomer(int index)
        {
            return customers[index - 1];
        }

        public void AddBooking(Booking booking)
        {
            booking.ID = bookingIndex++;
            bookings.Add(booking);
        }

        public IEnumerable<Booking> GetAllBookings()
        {
            return bookings;
        }
    }
}