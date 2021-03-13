using DesignPatternsSandbox.ModelFilter.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsSandbox.Factories.Interfaces
{
    public interface IFlightFilterFactory
    {
        public IFlightFilter GetFilter();

    }
}
