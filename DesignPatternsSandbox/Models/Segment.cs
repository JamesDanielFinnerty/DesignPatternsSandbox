using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsSandbox.Models
{
    public class Segment
    {
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
        public string PlaneType { get; set; }

        public bool ArrivesBeforeDeparture()
        {
            return Arrival < Departure;
        }

        public override string ToString()
        {
            var results = new StringBuilder();

            results.AppendLine("Departs " + Departure.ToString());
            results.AppendLine("Arrives " + Arrival.ToString());
            results.AppendLine("Plane " + PlaneType);

            return results.ToString();
        }
    }
}
