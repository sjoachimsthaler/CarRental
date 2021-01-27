using System.Collections.Generic;
using System.Linq;

using BusinessLogic.Data;
using BusinessLogic.Model;

using Microsoft.AspNetCore.Components;

namespace BlazorUI.Pages
{
    public class CarsBase : ComponentBase
    {
        [Inject]
        public IRepository Repository { get; set; }

        public IEnumerable<Car> CarsCollection { get; set; }

        public Car CarToEdit { get; set; }
        public Car CarToCreate { get; set; }

        protected override void OnInitialized()
        {
            CarsCollection = Repository.GetAllCars();

            base.OnInitialized();
        }

        public void Edit(int id)
        {
            CarToEdit = CarsCollection.Single(c => c.ID == id);
        }

        public void Delete(int id)
        {
            // Delete Car in repository
            Repository.DeleteCar(id);
        }

        protected void HandleValidEdit()
        {
            // Edit Car in repository
            Repository.EditCar(CarToEdit);
            CarToEdit = null;
        }

        protected void AddCar()
        {
            CarToCreate = new Car();
        }

        protected void HandleValidCreate()
        {
            // Edit Car in repository
            Repository.AddCar(CarToCreate);
            CarToCreate = null;
        }
    }
}
