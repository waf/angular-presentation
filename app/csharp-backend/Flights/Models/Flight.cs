using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Flights.Models
{
    /// <summary>
    /// Flight item entity
    /// </summary>
    public class Flight
    {
        public int Id { get; set; }
        public Airport DepartureAirport { get; set; }
        public Airport DestinationAirport { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public decimal Price { get; set; }
        public String Seat { get; set; }
        public bool MealProvided { get; set; }
    }
}