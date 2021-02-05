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
    public class CustomerController : ControllerBase
    {
        public IRepository Repository { get; }

        public CustomerController(IRepository repository)
        {
            Repository = repository;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return Repository.GetAllCustomers();
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            return Repository.GetCustomer(id);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public void Post([FromBody] Customer customer)
        {
            Repository.AddCustomer(customer);
        }

        // PUT api/<CustomerController>/5
        [HttpPut]
        public void Put([FromBody] Customer customer)
        {
            Repository.EditCustomer(customer);
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Repository.DeleteCustomer(id);
        }
    }
}
