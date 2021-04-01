using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tema4.Models
{
    public class CarEntity
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public int HorsePower { get; set; }
        public bool Selected { get; set; }

    }
}
