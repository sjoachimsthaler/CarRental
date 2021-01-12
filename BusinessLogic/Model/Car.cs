
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Model
{
    public class Car
    {
        public int ID { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }


        public override string ToString()
        {
            return $"ID: {ID} Manufacturer: {Manufacturer} Model: {Model}";
        }
    }
}
