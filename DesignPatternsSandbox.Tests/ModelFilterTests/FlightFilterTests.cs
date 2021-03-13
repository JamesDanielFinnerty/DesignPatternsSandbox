using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using DesignPatternsSandbox.ModelFilter;
using DesignPatternsSandbox.Models;

namespace DesignPatternsSandbox.Tests.ModelFilterTests
{
    [TestClass]
    public class FlightFilterTests
    {
        [TestMethod]
        public void Test1_DepartAfter_AddOneValidFlight()
        {
            // generate a date time to work with
            var departureDateToTest = new System.DateTime(2030, 01, 01);

            var flight = new Flight();

            // create our segment with it's departure set to be the target data
            var segment1 = new Segment();
            segment1.Departure = departureDateToTest;

            flight.Segments.Add(segment1);

            var flights = new List<Flight>();
            flights.Add(flight);

            // call our function to test
            var filterToTest = new FlightFilter();

            var results = filterToTest.SetModelCollection(flights).DepartAfter(departureDateToTest.AddDays(-1)).Evaluate();

            Assert.AreEqual(results.Count, 1);
        }

        [TestMethod]
        public void Test2_DepartAfter_AddTwoFlightsWhereOneIsInvalid()
        {
            // generate a date time to work with
            var departureDateToTest = new System.DateTime(2030, 01, 01);

            var flight1 = new Flight();
            var flight2 = new Flight();

            // create one flight departing after the date
            var segment1 = new Segment();
            segment1.Departure = departureDateToTest.AddDays(1);
            flight1.Segments.Add(segment1);

            // and one before
            var segment2 = new Segment();
            segment2.Departure = departureDateToTest.AddDays(-1);
            flight2.Segments.Add(segment2);

            var flights = new List<Flight>();
            flights.Add(flight1);
            flights.Add(flight2);

            // call our function to test
            var filterToTest = new FlightFilter();

            var results = filterToTest.SetModelCollection(flights).DepartAfter(departureDateToTest).Evaluate();

            Assert.AreEqual(results.Count, 1);
        }

    }
}
