using Blinger.MVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blinger.MVC.Services
{
    public class AirportService
    {
        private BlingerDbContext _blingerDbContext;
        public AirportService(BlingerDbContext blingerDbContext)
        {
            _blingerDbContext = blingerDbContext;
        }
        public List<Airport> GetAll()
        {
            return _blingerDbContext.Airports.ToList();
        }
        public void Add(Airport airport)
        {
            _blingerDbContext.Add(airport);
            _blingerDbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            var airport = _blingerDbContext.Airports.FirstOrDefault(x => x.Id == id);
            _blingerDbContext.Remove(airport);
            _blingerDbContext.SaveChanges();
        }
        public Airport GetAirportId(string id)
        {
            return _blingerDbContext.Airports.FirstOrDefault(x => x.Airport_id == id); 
        }
        public bool IsThisIdAlreadyExist(string Airport_id)
        {
            return !_blingerDbContext.Airports.Any(a => a.Airport_id == Airport_id);
        }
        public bool IsThisNameAlreadyExist(string Name)
        {
            return !_blingerDbContext.Airports.Any(a => a.Name == Name);
        }
        public bool IsThisCityAlreadyExist(string City)
        {
            return !_blingerDbContext.Airports.Any(a => a.City == City);
        }
        public bool IsThisAdressAlreadyExist(string Adress)
        {
            return !_blingerDbContext.Airports.Any(a => a.Adress == Adress);
        }
    }
}
