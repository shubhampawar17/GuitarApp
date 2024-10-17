using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarApp.Models
{
    public class Guitar
    {
        public string SerialNumber { get; }
        public double Price { get; set; }
        private GuitarSpec spec;

        public Guitar(string serialNumber, double price, GuitarSpec spec)
        {
            SerialNumber = serialNumber;
            Price = price;
            this.spec = spec;
        }

        public GuitarSpec GetSpec()
        {
            return spec;
        }

        public override string ToString()
        {
            return $"Serial Number: {SerialNumber}, Price: {Price}, Builder: {spec.Builder}, Model: {spec.Model}, Type: {spec.Type}, BackWood: {spec.BackWood}, TopWood: {spec.TopWood}";
        }
    }
}
