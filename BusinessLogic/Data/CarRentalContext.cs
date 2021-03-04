using System;
using System.Collections.Generic;
using System.Text;

using BusinessLogic.Model;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BusinessLogic.Data
{
    public class CarRentalContext : DbContext
    {

        public CarRentalContext(DbContextOptions<CarRentalContext> options)
        : base(options)
        {

        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
