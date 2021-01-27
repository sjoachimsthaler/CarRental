using System.Collections.Generic;
using System.Linq;

using BusinessLogic.Data;
using BusinessLogic.Model;

using Microsoft.AspNetCore.Components;

namespace BlazorUI.Pages
{
    public class CustomersBase : ComponentBase
    {
        [Inject]
        public IRepository Repository { get; set; }

        public IEnumerable<Customer> CustomerCollection { get; set; }

        public Customer CustomerToEdit { get; set; }
        public Customer CustomerToCreate { get; set; }

        protected override void OnInitialized()
        {
            CustomerCollection = Repository.GetAllCustomers();

            base.OnInitialized();
        }

        protected void Edit(int id)
        {
            CustomerToEdit = CustomerCollection.Single(c => c.ID == id);
        }

        protected void Delete(int id)
        {
            // Delete Car in repository
            Repository.DeleteCustomer(id);
        }

        protected void HandleValidEdit()
        {
            // Edit Car in repository
            Repository.EditCustomer(CustomerToEdit);
            CustomerToEdit = null;
        }

        protected void AddCustomer()
        {
            CustomerToCreate = new Customer();
        }

        protected void HandleValidCreate()
        {
            // Edit Car in repository
            Repository.AddCustomer(CustomerToCreate);
            CustomerToCreate = null;
        }
    }
}
