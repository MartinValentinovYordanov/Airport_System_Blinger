using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blinger.MVC.Models
{
    public class AirportCreateModel {


        [Required]
        [Remote("IsThisIdAlreadyExist", "Airports", HttpMethod = "POST", ErrorMessage = "Airport with that name already exist.")]
        public string Airport_id { get; set; }
        [Required]
        [Remote("IsThisNameAlreadyExist", "Airports", HttpMethod = "POST", ErrorMessage = "Airport with that name already exist.")]
        public string Name { get; set; }
        public string Country { get; set; }
        [Required]
        [Remote("IsThisCityAlreadyExist", "Airports", HttpMethod = "POST", ErrorMessage = "Airport with that name already exist.")]
        public string City { get; set; }
        [Required]
        [Remote("IsThisAdressAlreadyExist", "Airports", HttpMethod = "POST", ErrorMessage = "Airport with that name already exist.")]
        public string Adress { get; set; }
    }
}
