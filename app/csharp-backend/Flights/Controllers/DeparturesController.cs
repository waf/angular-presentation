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
    /// Departure Airport lookup service
    /// </summary>
    public class DeparturesController : ApiController
    {
        /// <summary>
        /// Return a list of all departure airports
        /// </summary>
        public IEnumerable<Airport> GetDepartures()
        {
            return InMemoryFlightData.DepartureAirports;
        }
    }
}
