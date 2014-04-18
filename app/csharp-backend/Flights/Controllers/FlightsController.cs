using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Flights.Models;

namespace Flights.Controllers
{
    /// <summary>
    /// Provides endpoints for looking up flight information.
    /// </summary>
    public class FlightsController : ApiController
    {
        /// <summary>
        /// Get a list of flights, optionally filtered by departure/destination airport.
        /// </summary>
        /// <param name="departureCode">Departure airport code</param>
        /// <param name="destinationCode">Destination airport code</param>
        public IEnumerable<Flight> GetFlightList(String departureCode = null, String destinationCode = null)
        {
            return InMemoryFlightData.Flights
                .OrderBy(f => f.Id)
                .Where(flight => (departureCode == null || flight.DepartureAirport.Code == departureCode) &&
                                 (destinationCode == null || flight.DestinationAirport.Code == destinationCode));
        }

        /// <summary>
        /// Lookup information about a specific flight.
        /// </summary>
        /// <param name="id">the flight ID</param>
        public Flight GetFlight(int id)
        {
            return InMemoryFlightData.Flights
                .FirstOrDefault(f => f.Id == id);
        }
    }
}