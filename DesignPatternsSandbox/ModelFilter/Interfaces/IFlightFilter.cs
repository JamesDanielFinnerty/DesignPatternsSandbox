using System;
using System.Collections.Generic;
using System.Text;
using DesignPatternsSandbox.Models;

namespace DesignPatternsSandbox.ModelFilter.Interfaces
{
    public interface IFlightFilter
    {
        public InnerFlightFilter SetModelCollection(IList<Flight> modelsToWorkWith);
    }
}
