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
    public class CarController : ControllerBase
    {
        public IRepository Repository { get; }

        public CarController(IRepository repository)
        {
            Repository = repository;
        }

        // GET: api/<CarController>
        [HttpGet]
        public IEnumerable<Car> Get()
        {
            return Repository.GetAllCars();
        }

        // GET api/<CarController>/5
        [HttpGet("{id}")]
        public Car Get(int id)
        {
            return Repository.GetCar(id);
        }

        // POST api/<CarController>
        [HttpPost]
        public void Post([FromBody] Car car)
        {
            Repository.AddCar(car);
        }

        // PUT api/<CarController>/5
        [HttpPut]
        public void Put([FromBody] Car car)
        {
            Repository.EditCar(car);
        }

        // DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        [ProducesErrorResponseType(typeof(NotFoundResult))]
        public ActionResult Delete(int id)
        {
            try
            {
                Repository.DeleteCar(id);
                return new OkResult();
            }
            catch (IndexOutOfRangeException )
            {
                return new NotFoundResult();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new NotFoundResult();
            }
        }
    }
}
