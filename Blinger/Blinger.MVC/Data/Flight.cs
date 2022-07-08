using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Blinger.MVC.Data
{
    public class Flight
    {
        public int Id { get; set; }
        public string AirlineName { get; set; }
        public string AirportOriginName { get; set; }
        public string AirportDestinationName { get; set; }
        public DateTime TakeOffDate { get; set; }
        public DateTime LandingDate { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
    }
}