using Blinger.MVC.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blinger.MVC.Models.FlightModels
{
    public record FlightCreateModel
    {
        [Required] public string AirlineName { get; set; }
        [Required] public string AirportOriginName { get; set; }
        [Required] public string AirportDestinationName { get; set; }
        [Required] public DateTime TakeOffDate { get; set; }
        [Required] public DateTime LandingDate { get; set; }
        [Required] public uint RowsEconomy { get; set; }
        [Required] public uint ColsEconomy { get; set; }
        [Required] public uint RowsBusiness { get; set; }
        [Required] public uint ColsBusiness { get; set; }
        [Required] public uint RowsFirst { get; set; }
        [Required] public uint ColsFirst { get; set; }
        public List<Airline> AllAirlines { get; set; }
        public List<Airport> AllAirports { get; set; }

    }
}
