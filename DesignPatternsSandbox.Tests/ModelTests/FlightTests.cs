using Microsoft.VisualStudio.TestTools.UnitTesting;
using DesignPatternsSandbox.Models;
using DesignPatternsSandbox.Tests.TestHelpers;

namespace DesignPatternsSandbox.Tests.ModelTests
{
    [TestClass]
    public class FlightModelTests
    {
        [TestMethod]
        public void Test1_GetInitialDeparture_1Segment()
        {
            // generate a date time to work with
            var departureDateToTest = new System.DateTime(2030, 01, 01);

            var flight = new Flight();

            // create our segment with it's departure set to be the target data
            var segment1 = new SegmentBuilder().SetDeparture(departureDateToTest).Build();

            flight.Segments.Add(segment1);

            // call our function to test
            var result = flight.GetDeparture();

            Assert.AreEqual(result, departureDateToTest);
        }

        [TestMethod]
        public void Test2_GetInitialDeparture_2Segments()
        {
            // generate a date time to work with
            var departureDateToTest = new System.DateTime(2030, 01, 01);

            var flight = new Flight();

            // create two segments, one with target date, one a day later.
            var segment1 = new SegmentBuilder().SetDeparture(departureDateToTest).Build();
            var segment2 = new SegmentBuilder().SetDeparture(departureDateToTest.AddDays(2)).Build();

            // add them in the in correct order to check we are getting the earliest
            flight.Segments.Add(segment2);
            flight.Segments.Add(segment1);

            // call our function to test
            var result = flight.GetDeparture();

            Assert.AreEqual(result, departureDateToTest);
        }
    }
}
