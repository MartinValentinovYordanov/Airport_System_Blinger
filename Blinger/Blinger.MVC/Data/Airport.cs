using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blinger.MVC.Data
{
    public class Airport
    {
        public int Id { get; set; }
        public string Airport_id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string  Adress { get; set; }
    }
}
