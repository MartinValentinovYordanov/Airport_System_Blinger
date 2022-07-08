using Blinger.MVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blinger.MVC.Services
{
    public class AirlineService
    {
        private BlingerDbContext _blingerDbContext;
        public AirlineService(BlingerDbContext context)
        {
            _blingerDbContext = context;
        }

        public List<Airline> GetAll()
        {
           return _blingerDbContext.Airline.ToList();
        }

        public void Add(Airline airline)
        {
            _blingerDbContext.Add(airline);
            _blingerDbContext.SaveChanges();
        }

        public bool IsThisNameAlreadyExist(string airlineName)
        {
            return !_blingerDbContext.Airline.Any(a => a.Name == airlineName);
        }

        internal void Delete(int id)
        {
            var airline = _blingerDbContext.Airline.FirstOrDefault(x=>x.Id==id);
            _blingerDbContext.Remove(airline);
            _blingerDbContext.SaveChanges();
        }
    }
}
