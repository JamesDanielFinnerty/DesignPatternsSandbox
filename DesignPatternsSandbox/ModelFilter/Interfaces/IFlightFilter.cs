using System;
using System.Collections.Generic;
using System.Text;
using DesignPatternsSandbox.Models;

namespace DesignPatternsSandbox.ModelFilter.Interfaces
{
    public interface IFlightFilter
    {
        public void SetModelCollection(IList<Flight> modelsToWorkWith);
        public FlightFilter DepartAfter(DateTime targetDateTime);
        public IList<Flight> Evaluate();
    }
}
