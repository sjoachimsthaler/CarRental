using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BusinessLogic.Data;
using BusinessLogic.Model;

using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        public IRepository Repository { get; }

        public BookingController(IRepository repository)
        {
            Repository = repository;
        }

        // GET: api/<BookingsController>
        [HttpGet]
        public IEnumerable<Booking> Get()
        {
            return Repository.GetAllBookings(); ;
        }

        // GET api/<BookingsController>/5
        [HttpGet("{id}")]
        public Booking Get(int id)
        {
            return Repository.GetBooking(id); ;
        }

        // POST api/<BookingsController>
        [HttpPost]
        public void Post([FromBody] Booking booking)
        {
            Repository.AddBooking(booking);
        }

        // PUT api/<BookingsController>/5
        [HttpPut]
        public void Put([FromBody] Booking booking)
        {
            Repository.EditBooking(booking);
        }

        // DELETE api/<BookingsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Repository.DeleteBooking(id);
        }
    }
}
