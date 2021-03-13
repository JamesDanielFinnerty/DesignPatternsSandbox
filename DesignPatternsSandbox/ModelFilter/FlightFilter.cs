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

        private IEnumerable<Flight> _modelsToWorkWith;

        public void SetModelCollection(IList<Flight> modelsToWorkWith)
        {
            this._modelsToWorkWith = modelsToWorkWith;
        }

        public FlightFilter DepartAfter(DateTime targetDateTime)
        {
            this._modelsToWorkWith = this._modelsToWorkWith
                .Where(x => x.GetDeparture() > targetDateTime);

            return this;
        }

        public FlightFilter RemoveErroneusFlights()
        {
            this._modelsToWorkWith = this._modelsToWorkWith
                .Where(x => x.ContainsErroneousSegment() == false);

            return this;
        }

        public FlightFilter RemoveLongLayover(Double maxSecondsOnGround)
        {
            this._modelsToWorkWith = this._modelsToWorkWith
                .Where(x => x.SecondsSpentOnGround() < maxSecondsOnGround);

            return this;
        }

        public IList<Flight> Evaluate()
        {
            return this._modelsToWorkWith.ToList();
        }

    }
}
