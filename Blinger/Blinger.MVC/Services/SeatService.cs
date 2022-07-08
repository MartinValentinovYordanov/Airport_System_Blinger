using Blinger.MVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blinger.MVC.Services
{
    public class SeatService
    {
        private BlingerDbContext _blingerDbContext;
        public SeatService(BlingerDbContext context)
        {
            _blingerDbContext = context;
        }

        public IEnumerable<Seat> GetAllSeatsByFlightId(int Flightid)
        {
            
            return _blingerDbContext.Seat.Where(x=>x.FlightId== Flightid).OrderBy(x=>x.SeatClass).ThenBy(x=>x.Row).ThenBy(x=>x.Col);
        }

        public int Book(int id)
        {
            var seat = _blingerDbContext.Seat.FirstOrDefault(x => x.Id == id);
            if (seat.IsBooked==false)
            {
                seat.IsBooked = true;
                _blingerDbContext.SaveChanges();
            }
            return seat.FlightId;
        }
        public int UnBook(int id)
        {
            var seat = _blingerDbContext.Seat.FirstOrDefault(x => x.Id == id);
            if (seat.IsBooked == true)
            {
                seat.IsBooked = false;
                _blingerDbContext.SaveChanges();
            }
            return seat.FlightId;
        }
        public void Create(Seat seat)
        {
            _blingerDbContext.Add(seat);
            _blingerDbContext.SaveChanges();
        }

        public void Add(uint Rows, uint Cols, string Class)
        {
            var flId = _blingerDbContext.Flight.OrderBy(f => f.Id).Last().Id;
            for (int row = 1; row <= Rows; row++)
            {
                for (int col = 1; col <= Cols; col++)
                {
                    _blingerDbContext.Seat.Add(new Seat { FlightId = flId, Row = row, Col = (char)(col + 64), SeatClass = Class });
                }
            }
            _blingerDbContext.SaveChanges();
        }
    }
}
