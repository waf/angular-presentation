using Flights.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Flights.Controllers
{
    /// <summary>
    /// Destination Airport lookup service
    /// </summary>
    public class DestinationsController : ApiController
    {
        /// <summary>
        /// Return a list of all destination airports
        /// </summary>
        public IEnumerable<Airport> GetDestinations()
        {
            return InMemoryFlightData.DestinationAirports;
        }
    }
}
