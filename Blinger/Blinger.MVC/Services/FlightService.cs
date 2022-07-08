using Blinger.MVC.Data;
using Blinger.MVC.Models.FlightModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blinger.MVC.Services
{
    public class FlightService
    {
        private BlingerDbContext _blingerDbContext;
        public FlightService(BlingerDbContext context)
        {
            _blingerDbContext = context;
        }

        public IEnumerable<FlightListModel> GetAll()
        {
            
                return _blingerDbContext.Flight.Select(f => new FlightListModel(
                _blingerDbContext.Airline.FirstOrDefault(a => a.Name == f.AirlineName).Name,
                _blingerDbContext.Airports.FirstOrDefault(a => a.Name == f.AirportOriginName).Name,
                _blingerDbContext.Airports.FirstOrDefault(a => a.Name == f.AirportDestinationName).Name,
                f.TakeOffDate, f.LandingDate, _blingerDbContext.Seat.Where(s => s.FlightId == f.Id).Count(), _blingerDbContext.Seat.Where(s => s.FlightId == f.Id && !s.IsBooked).Count(), f.Id));
            
        }
        public Flight GetFlight(int flightId)
        {
            return _blingerDbContext.Flight.FirstOrDefault(x => x.Id == flightId);
        }
        public void Add(Flight flight)
        {
            _blingerDbContext.Add(flight);
            _blingerDbContext.SaveChanges();
        }

        public void Delete(int? id)
        {
            var flight = _blingerDbContext.Flight.FirstOrDefault(x => x.Id == id);
            _blingerDbContext.Remove(flight);
            _blingerDbContext.SaveChanges();
        }

        public IEnumerable<FlightSearchModel> GetAll(FlightSearchModel flightfound)
        {
            return _blingerDbContext.Flight.Select(flight => new FlightSearchModel(
                _blingerDbContext.Airline.FirstOrDefault(a => a.Name == flight.AirlineName).Name,
            _blingerDbContext.Airports.FirstOrDefault(a => a.Name == flight.AirportOriginName).Name,
            _blingerDbContext.Airports.FirstOrDefault(a => a.Name == flight.AirportDestinationName).Name,
            _blingerDbContext.Airline.ToList(),
            _blingerDbContext.Airports.ToList(),
            flight.TakeOffDate));
        }

        public IEnumerable<Flight> FindFlight(FlightSearchModel flightfound)
        {
            return _blingerDbContext.Flight.Where(x => x.AirlineName == flightfound.AirlineName &&
            x.AirportDestinationName==flightfound.AirportDestinationName &&
            x.AirportOriginName==flightfound.AirportOriginName &&
            x.TakeOffDate==flightfound.TakeOffDate 
            );
        }

        public IEnumerable<FlightListModel> GetAllFoundFlights(List<Flight> flight)
        {
            return flight.Select(f => new FlightListModel(
            _blingerDbContext.Airline.FirstOrDefault(a => a.Name == f.AirlineName).Name,
            _blingerDbContext.Airports.FirstOrDefault(a => a.Name == f.AirportOriginName).Name,
            _blingerDbContext.Airports.FirstOrDefault(a => a.Name == f.AirportDestinationName).Name,
            f.TakeOffDate, f.LandingDate, _blingerDbContext.Seat.Where(s => s.FlightId == f.Id).Count(), _blingerDbContext.Seat.Where(s => s.FlightId == f.Id && !s.IsBooked).Count(), f.Id));
        }
    }
    
}
