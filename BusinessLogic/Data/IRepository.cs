
using BusinessLogic.Model;

using System.Collections.Generic;

namespace BusinessLogic.Data
{
    public interface IRepository
    {
        void AddCar(Car car);
        IEnumerable<Car> GetAllCars();
        Car GetCars(int index);
        void AddCustomer(Customer customer);
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomer(int index);
        void AddBooking(Booking booking);
        IEnumerable<Booking> GetAllBookings();

        void EditCar(Car car);
        void DeleteCar(int id);
    }
}