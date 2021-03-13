using System;
using System.Collections.Generic;
using System.Text;
using DesignPatternsSandbox.ModelFilter.Interfaces;
using DesignPatternsSandbox.Models;
using System.Linq;

namespace DesignPatternsSandbox.ModelFilter
{
    public class FlightFilter : IFlightFilter
    {
        public FlightFilter()
        { }
        public virtual InnerFlightFilter SetModelCollection(IList<Flight> modelsToWorkWith)
        {
            return new InnerFlightFilter(modelsToWorkWith);
        }

    }
}
