using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blinger.MVC.Models
{
    public class AirlineCreateModel
    {
        [Required]
        [Remote("IsThisNameAlreadyExist", "Airlines", HttpMethod = "POST", ErrorMessage = "Airline with that name already exist.")]
        public string Name { get; set; }
    }
}
