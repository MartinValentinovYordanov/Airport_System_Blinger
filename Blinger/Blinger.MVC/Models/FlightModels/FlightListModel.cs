using Blinger.MVC.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blinger.MVC.Models.FlightModels
{
    public record FlightListModel([Required] string AirlineName, string AirportOriginName, string AirportDestinationName, DateTime TakeOffDate,  DateTime LandingDate,  int AllSeats,  int FreeSeats,int Id);
    
}
