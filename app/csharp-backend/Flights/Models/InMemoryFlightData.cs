using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flights.Models
{
    /// <summary>
    /// Generates some random flight data and stores it in memory
    /// </summary>
    public class InMemoryFlightData
    {
        // Holds the randomly generated data
        public static IEnumerable<Flight> Flights { get; private set; }
        public static IEnumerable<Airport> DepartureAirports { get; private set; }
        public static IEnumerable<Airport> DestinationAirports { get; private set; }

        private static readonly Random random = new Random();

        static InMemoryFlightData()
        {
            DepartureAirports = new[] {
                new Airport { Code = "BKK", Name = "Suvarnabhumi Airport"},
                new Airport { Code = "DMK", Name = "Don Mueang Airport"},
                new Airport { Code = "HKT", Name = "Phuket Airport"},
                new Airport { Code = "CNX", Name = "Chiang Mai Airport"},
                new Airport { Code = "HDY", Name = "Hat Yai Airport"},
                new Airport { Code = "USM", Name = "Samui Airport"},
            };
            DestinationAirports  = new[] {
                new Airport { Code = "PEK", Name = "Beijing Capital International Airport"},
                new Airport { Code = "CAN", Name = "Guangzhou Baiyun International Airport"},
                new Airport { Code = "PVG", Name = "Shanghai Pudong International Airport"},
                new Airport { Code = "SHA", Name = "Shanghai Hongqiao International Airport"},
                new Airport { Code = "CTU", Name = "Chengdu Shuangliu International Airport"},
                new Airport { Code = "SZX", Name = "Shenzhen Bao'an International Airport"},
            };

            var randomFlights = RandomFlightGenerator();
            // generate three iterations of random flights;
            Flights = randomFlights.Concat(randomFlights).Concat(randomFlights).ToList();
        }

        /// <summary>
        /// Create a lazy ienumerable that generates random flights when ToList()'d
        /// </summary>
        private static IEnumerable<Flight> RandomFlightGenerator()
        {
            const int MinutesInHour = 60;
            const int MinutesInDay = 24 * MinutesInHour;
            int id = 1;
            var randomFlights =
                (from departure in DepartureAirports
                 from destination in DestinationAirports
                 let departureTime = DateTime.Now.AddMinutes(RandomBetween(MinutesInDay * 10, MinutesInDay * 20))
                 let arrivalTime = departureTime.AddMinutes(RandomBetween(0, MinutesInHour * 4))
                 select new Flight()
                 {
                     Id = id++,
                     DepartureAirport = departure,
                     DestinationAirport = destination,
                     DepartureTime = departureTime,
                     ArrivalTime = arrivalTime,
                     Price = RandomBetween(300, 800),
                     Seat = RandomBetween(1, 25).ToString() + (char)RandomBetween(65, 70),
                     MealProvided = random.NextDouble() > 0.5
                 });
            return randomFlights;
        }

        private static int RandomBetween(int min, int max)
        {
            return random.Next(max - min) + min;
        }
    }
}