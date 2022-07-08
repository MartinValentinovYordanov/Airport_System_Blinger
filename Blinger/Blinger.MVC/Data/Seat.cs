namespace Blinger.MVC.Data
{
    public class Seat
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public string SeatClass { get; set; }
        public bool IsBooked { get; set; }
        public int Row { get; set; }
        public char Col { get; set; }
         }
}
