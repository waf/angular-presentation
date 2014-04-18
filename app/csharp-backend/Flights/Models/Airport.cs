using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Flights.Models
{
    public class Airport
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}