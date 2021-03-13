using DesignPatternsSandbox.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsSandbox.ModelFilter
{
    public class SafeFlightFilter : FlightFilter
    {
        public SafeFlightFilter()
        { 
            
        }

        public override IList<Flight> Evaluate()
        {
            base.RemovePlaneType("737MAX");
            return base.Evaluate();
        }
    }
}
