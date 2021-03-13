using DesignPatternsSandbox.Factories.Interfaces;
using DesignPatternsSandbox.ModelFilter;
using DesignPatternsSandbox.ModelFilter.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsSandbox.Factories
{
    class FlightFilterFactory : IFlightFilterFactory
    {
        private bool _removeUnsafeFlights;

        public FlightFilterFactory(bool removeUnsafeFlights)
        {
            this._removeUnsafeFlights = removeUnsafeFlights;
        }

        public IFlightFilter GetFilter()
        {
            if(_removeUnsafeFlights)
            {
                return new SafeFlightFilter();
            }
            else
            {
                return new FlightFilter();
            }
        }

    }
}
