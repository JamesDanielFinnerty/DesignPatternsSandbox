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
                CreateFlight(fiveDaysFromNow, fiveDaysFromNow.AddHours(2)),
                CreateFlight(fiveDaysFromNow, fiveDaysFromNow.AddHours(2), fiveDaysFromNow.AddHours(3), fiveDaysFromNow.AddHours(5)),
                CreateFlight(fiveDaysFromNow.AddDays(-6), fiveDaysFromNow),
                CreateFlight(fiveDaysFromNow, fiveDaysFromNow.AddHours(-6)),
                CreateFlight(fiveDaysFromNow, fiveDaysFromNow.AddHours(2), fiveDaysFromNow.AddHours(5), fiveDaysFromNow.AddHours(6)),
                CreateFlight(fiveDaysFromNow, fiveDaysFromNow.AddHours(2), fiveDaysFromNow.AddHours(3), fiveDaysFromNow.AddHours(4), fiveDaysFromNow.AddHours(6), fiveDaysFromNow.AddHours(7))
            };
        }

        private static Flight CreateFlight(params DateTime[] dates)
        {
            if (dates.Length % 2 != 0)
                throw new ArgumentException("Needs even input count,", "dates");

            var departureDates = dates.Where((date, index) => index % 2 == 0);
            var arrivalDates = dates.Where((date, index) => index % 2 == 1);

            var segments = departureDates
                .Zip(arrivalDates, (departureDate, arrivalDate) => new Segment { Departure = departureDate, Arrival = arrivalDate })
                .ToList();

            return new Flight { Segments = segments };
        }
    }
}

