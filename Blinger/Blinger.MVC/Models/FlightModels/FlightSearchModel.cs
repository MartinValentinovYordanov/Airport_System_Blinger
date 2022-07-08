using Blinger.MVC.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blinger.MVC.Models.FlightModels
{
    public record FlightSearchModel(string AirlineName,
            string AirportOriginName,
            string AirportDestinationName,
            List<Airline> AllAirlines,
            List<Airport> AllAirports,
            DateTime TakeOffDate);
}
