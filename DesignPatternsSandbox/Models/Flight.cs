using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DesignPatternsSandbox.Models
{
    public class Flight
    {
        public Flight()
        {
            this.Segments = new List<Segment>();
        }

        public IList<Segment> Segments { get; set; }

        public DateTime GetDeparture()
        {
            return Segments
                .OrderBy(x => x.Departure)
                .First()
                .Departure;
        }

        public bool ContainsErroneousSegment()
        {
            return this.Segments.Where(x => x.ArrivesBeforeDeparture()).Any();
        }

        public Double SecondsSpentOnGround()
        {
            Double result = 0; // this also handles single segment flights

            // make sure segments are in order
            this.Segments = this.Segments.OrderBy(x => x.Departure).ToList();

            // loop through segments.
            // -1 on the final loop, as there's no segment after it
            for (int i = 0; i < this.Segments.Count - 1; i++)
            {
                var segmentALandingTime = this.Segments[i].Arrival;
                var segmentBTakeOffTime = this.Segments[i+1].Departure;

                var timeDiffInSeconds = (segmentBTakeOffTime - segmentALandingTime).TotalSeconds;

                // add seconds on this layover to our tally
                result += timeDiffInSeconds;
            }

            return result;
        }

        public override string ToString()
        {
            var results = new StringBuilder();

            // make sure segments are in order
            var segments = this.Segments.OrderBy(x => x.Departure).ToList();

            for(int i = 0; i < segments.Count; i++)
            {
                results.AppendLine("");
                results.AppendLine("Segment " + (i+1).ToString());
                results.AppendLine("----------");
                results.AppendLine("Departs " + segments[i].Departure.ToString());
                results.AppendLine("Arrives " + segments[i].Arrival.ToString());
            }

            return results.ToString();
        }
    }
}
