using Blinger.MVC.Data;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blinger.MVC.Models.SeatModels
{
    public record SeatCreateModel([Required] int Row, [Required] char Col, [Required] string SeatClass, int FlightId);
}
