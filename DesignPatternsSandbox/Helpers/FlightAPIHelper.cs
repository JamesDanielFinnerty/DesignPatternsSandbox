using System;
using System.Collections.Generic;
using System.Linq;
using DesignPatternsSandbox.Models;

namespace DesignPatternsSandbox.Helpers
{
    public class FlightAPIHelper
    {
        public IList<Flight> GetTestFlights()
        {
            var fiveDaysFromNow = DateTime.Now.AddDays(5);

            return new List<Flight>
            {
                CreateFlight("737MAX",true,fiveDaysFromNow, fiveDaysFromNow.AddHours(2)),
                CreateFlight("Concorde",true,fiveDaysFromNow, fiveDaysFromNow.AddHours(2), fiveDaysFromNow.AddHours(3), fiveDaysFromNow.AddHours(5)),
                CreateFlight("A380",true,fiveDaysFromNow.AddDays(-6), fiveDaysFromNow),
                CreateFlight("A380",true,fiveDaysFromNow.AddDays(-6), fiveDaysFromNow,fiveDaysFromNow.AddHours(1), fiveDaysFromNow.AddHours(7)),
                CreateFlight("737MAX",false,fiveDaysFromNow, fiveDaysFromNow.AddHours(-6)),
                CreateFlight("777",false,fiveDaysFromNow, fiveDaysFromNow.AddHours(2), fiveDaysFromNow.AddHours(5), fiveDaysFromNow.AddHours(6)),
                CreateFlight("747",true,fiveDaysFromNow, fiveDaysFromNow.AddHours(2), fiveDaysFromNow.AddHours(3), fiveDaysFromNow.AddHours(4), fiveDaysFromNow.AddHours(6), fiveDaysFromNow.AddHours(7))
            };
        }

        private static Flight CreateFlight(string planeType, bool buisnessClass, params DateTime[] dates)
        {
            if (dates.Length % 2 != 0)
                throw new ArgumentException("Needs even input count,", "dates");

            var departureDates = dates.Where((date, index) => index % 2 == 0);
            var arrivalDates = dates.Where((date, index) => index % 2 == 1);

            var segments = departureDates
                .Zip(arrivalDates, (departureDate, arrivalDate) => new Segment { 
                    Departure = departureDate, 
                    Arrival = arrivalDate, 
                    HasBusinessClass = buisnessClass,
                    PlaneType = planeType })
                .ToList();

            return new Flight { Segments = segments };
        }
    }
}

