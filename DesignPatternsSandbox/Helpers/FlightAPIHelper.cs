using System;
using System.Collections.Generic;
using System.Linq;
using DesignPatternsSandbox.Models;

namespace DesignPatternsSandbox.Helpers
{
    public class FlightAPIHelper
    {
        public IList<Flight> GetFlights()
        {
            var fiveDaysFromNow = DateTime.Now.AddDays(5);

            return new List<Flight>
            {
                CreateFlight("737MAX",fiveDaysFromNow, fiveDaysFromNow.AddHours(2)),
                CreateFlight("Concorde",fiveDaysFromNow, fiveDaysFromNow.AddHours(2), fiveDaysFromNow.AddHours(3), fiveDaysFromNow.AddHours(5)),
                CreateFlight("A380",fiveDaysFromNow.AddDays(-6), fiveDaysFromNow),
                CreateFlight("737MAX",fiveDaysFromNow, fiveDaysFromNow.AddHours(-6)),
                CreateFlight("777",fiveDaysFromNow, fiveDaysFromNow.AddHours(2), fiveDaysFromNow.AddHours(5), fiveDaysFromNow.AddHours(6)),
                CreateFlight("747",fiveDaysFromNow, fiveDaysFromNow.AddHours(2), fiveDaysFromNow.AddHours(3), fiveDaysFromNow.AddHours(4), fiveDaysFromNow.AddHours(6), fiveDaysFromNow.AddHours(7))
            };
        }

        private static Flight CreateFlight(string planeType, params DateTime[] dates)
        {
            if (dates.Length % 2 != 0)
                throw new ArgumentException("Needs even input count,", "dates");

            var departureDates = dates.Where((date, index) => index % 2 == 0);
            var arrivalDates = dates.Where((date, index) => index % 2 == 1);

            var segments = departureDates
                .Zip(arrivalDates, (departureDate, arrivalDate) => new Segment { Departure = departureDate, Arrival = arrivalDate, PlaneType = planeType })
                .ToList();

            return new Flight { Segments = segments };
        }
    }
}

