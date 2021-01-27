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

        public Booking BookingToEdit { get; set; }
        public Booking BookingToCreate { get; set; }

        protected override void OnInitialized()
        {
            BookingsCollection = Repository.GetAllBookings();

            base.OnInitialized();
        }

        protected void Edit(int id)
        {
            BookingToEdit = BookingsCollection.Single(c => c.ID == id);
        }

        protected void Delete(int id)
        {
            // Delete Car in repository
            Repository.DeleteBooking(id);
        }

        protected void HandleValidEdit()
        {
            // Edit Car in repository
            Repository.EditBooking(BookingToEdit);
            BookingToEdit = null;
        }

        protected void AddBooking()
        {
            BookingToCreate = new Booking();
        }

        protected void HandleValidCreate()
        {
            // Edit Car in repository
            Repository.AddBooking(BookingToCreate);
            BookingToCreate = null;
        }
    }
}
