using System;
using System.Collections.Generic;
using System.Text;
using DesignPatternsSandbox.ModelFilter.Interfaces;
using DesignPatternsSandbox.Models;
using System.Linq;

namespace DesignPatternsSandbox.ModelFilter
{
    public class InnerFlightFilter
    {
        private IEnumerable<Flight> _modelsToWorkWith = new List<Flight>();

        public InnerFlightFilter(IEnumerable<Flight> modelsToWorkWith)
        {
            this._modelsToWorkWith = modelsToWorkWith;
        }

        public InnerFlightFilter DepartAfter(DateTime targetDateTime)
        {
            this._modelsToWorkWith = this._modelsToWorkWith
                .Where(x => x.GetDeparture() > targetDateTime);

            return this;
        }

        public InnerFlightFilter RemovePlaneType(string planeType)
        {
            this._modelsToWorkWith = this._modelsToWorkWith
                .Where(x => x.Segments.Where(y => y.PlaneType != planeType).Any());

            return this;
        }

        public InnerFlightFilter RemoveErroneusFlights()
        {
            this._modelsToWorkWith = this._modelsToWorkWith
                .Where(x => x.ContainsErroneousSegment() == false);

            return this;
        }

        public InnerFlightFilter RemoveLongLayover(Double maxSecondsOnGround)
        {
            this._modelsToWorkWith = this._modelsToWorkWith
                .Where(x => x.SecondsSpentOnGround() < maxSecondsOnGround);

            return this;
        }

        public virtual IList<Flight> Evaluate()
        {
            return this._modelsToWorkWith.ToList();
        }

    }
}
