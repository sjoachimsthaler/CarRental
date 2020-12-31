using System;
using System.Collections.Generic;
using System.Text;

namespace Konsolenanwendung
{
    public class Customer
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName} ({ID})";
        }
    }
}
