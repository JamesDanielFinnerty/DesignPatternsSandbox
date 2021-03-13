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
        public override InnerFlightFilter SetModelCollection(IList<Flight> modelsToWorkWith)
        {
            return new InnerFlightFilter(modelsToWorkWith).RemovePlaneType("737MAX");
        }
    }
}
