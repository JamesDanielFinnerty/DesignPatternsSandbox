using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsSandbox.Models
{
    public class Segment
    {
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }

        public bool ArrivesBeforeDeparture()
        {
            return Arrival < Departure;
        }
    }
}
