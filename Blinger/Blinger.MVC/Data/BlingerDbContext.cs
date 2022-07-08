using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blinger.MVC.Data;
using Blinger.MVC.Models.FlightModels;

namespace Blinger.MVC.Data
{
    public class BlingerDbContext : DbContext
    {
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Airline> Airline { get;  set; }
        public DbSet<Flight> Flight { get; set; }
        public DbSet<Seat> Seat { get; set; }

        public BlingerDbContext(DbContextOptions<BlingerDbContext> options)
          : base(options)
        {
        }

        public DbSet<Blinger.MVC.Models.FlightModels.FlightListModel> FlightListModel { get; set; }
        
    }
}
