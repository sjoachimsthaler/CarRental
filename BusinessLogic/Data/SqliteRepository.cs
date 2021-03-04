using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BusinessLogic.Model;

namespace BusinessLogic.Data
{
    public class SqliteRepository : IRepository
    {
        private readonly CarRentalContext context;

        public SqliteRepository()
        {

        }

        public SqliteRepository(CarRentalContext context)
        {
            this.context = context;
        }

        public void AddBooking(Booking booking)
        {
           
                context.Add<Booking>(booking);
                context.SaveChanges();
            
        }

        public void AddCar(Car car)
        {

            context.Add<Car>(car);
            context.SaveChanges();
            
        }

        public void AddCustomer(Customer customer)
        {

            context.Add<Customer>(customer);
            context.SaveChanges();
            
        }

        public void DeleteBooking(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteCar(int id)
        {
           
            var car = context.Find<Car>(id);
            context.Remove<Car>(car);
            context.SaveChanges();
            
        }

        public void DeleteCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public void EditBooking(Booking bookingToEdit)
        {
            throw new NotImplementedException();
        }

        public void EditCar(Car car)
        {
            throw new NotImplementedException();
        }

        public void EditCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Booking> GetAllBookings()
        {

            return context.Bookings.ToArray();
            
        }

        public IEnumerable<Car> GetAllCars()
        {
            return context.Cars.ToArray();
        }

        public IEnumerable<Customer> GetAllCustomers()
        {

                return context.Customers.ToArray();
            
        }

        public Booking GetBooking(int id)
        {

                return context.Find<Booking>(id);
            
        }

        public Car GetCar(int id)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomer(int id)
        {
            throw new NotImplementedException();
        }
    }
}
