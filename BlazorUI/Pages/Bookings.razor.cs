using System;
using System.Collections.Generic;
using System.Linq;

using BusinessLogic.Data;
using BusinessLogic.Model;

using Microsoft.AspNetCore.Components;

namespace BlazorUI.Pages
{
    public class BookingsBase : ComponentBase
    {
        [Inject]
        public IRepository Repository { get; set; }

        public IEnumerable<Booking> BookingsCollection { get; set; }
        public IEnumerable<Car> AllCars { get; set; }
        public IEnumerable<Customer> AllCustomers { get; set; }

        public Booking BookingToEdit { get; set; }
        public Booking BookingToCreate { get; set; }
        protected bool ShowBookingCreate { get => BookingToCreate != null; }
        protected bool ShowBookingEdit { get => BookingToEdit != null; }

        protected int selectedCarId { get; set; }
        protected int selectedCustomerId { get; set; }


        protected override void OnInitialized()
        {
            BookingsCollection = Repository.GetAllBookings();

            base.OnInitialized();
        }

        protected void Edit(int id)
        {
            AllCars = Repository.GetAllCars();
            AllCustomers = Repository.GetAllCustomers();
            var selectedBookingForEdit = BookingsCollection.Single(c => c.ID == id);
            selectedCarId = selectedBookingForEdit.Car.ID;
            selectedCustomerId = selectedBookingForEdit.Customer.ID;
            BookingToEdit = selectedBookingForEdit;
        }

        protected void Delete(int id)
        {
            // Delete Car in repository
            Repository.DeleteBooking(id);
        }

        protected void HandleValidEdit()
        {
            BookingToEdit.Customer = Repository.GetCustomer(selectedCustomerId);
            BookingToEdit.Car = Repository.GetCars(selectedCarId);
            // Edit Car in repository
            Repository.EditBooking(BookingToEdit);
            BookingToEdit = null;
        }

        protected void AddBooking()
        {
            BookingToCreate = new Booking()
            {
                From = DateTime.Now,
                To = DateTime.Now.AddDays(3)
            };
        }

        protected void HandleValidCreate()
        {
            // Edit Car in repository
            BookingToCreate.Customer = Repository.GetCustomer(selectedCustomerId);
            BookingToCreate.Car = Repository.GetCars(selectedCarId);
            Repository.AddBooking(BookingToCreate);
            BookingToCreate = null;
        }
    }
}
