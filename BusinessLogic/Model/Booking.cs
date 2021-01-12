
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Model
{
    public class Booking
    {
        public int ID { get; set; }
        public Customer Customer { get; set; }
        public Car Car { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public override string ToString()
        {
            return $"{Customer} {Car} {From} {To} ({ID})";
        }
    }
}
