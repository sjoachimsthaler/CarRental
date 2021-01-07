using System.Collections.Generic;

namespace Konsolenanwendung.Data
{
    internal interface IRepository
    {
        void AddCar(Car car);
        IEnumerable<Car> GetAllCars();
        Car GetCars(int index);
        void AddCustomer(Customer customer);
        IEnumerable<Customer> GetAllCustomer();
        Customer GetCustomer(int index);
        void AddBooking(Booking booking);
        IEnumerable<Booking> GetAllBookings();
    }
}