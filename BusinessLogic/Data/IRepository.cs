
using BusinessLogic.Model;

using System.Collections.Generic;

namespace BusinessLogic.Data
{
    public interface IRepository
    {
        void AddCar(Car car);
        IEnumerable<Car> GetAllCars();
        Car GetCar(int id);
        void AddCustomer(Customer customer);
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomer(int id);
        void AddBooking(Booking booking);
        IEnumerable<Booking> GetAllBookings();

        void EditCar(Car car);
        void DeleteCar(int id);
        void EditCustomer(Customer customer);
        void DeleteCustomer(int id);
        void DeleteBooking(int id);
        void EditBooking(Booking bookingToEdit);
        Booking GetBooking(int id);
    }
}