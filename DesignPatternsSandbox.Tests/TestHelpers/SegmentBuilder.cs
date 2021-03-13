using DesignPatternsSandbox.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsSandbox.Tests.TestHelpers
{
    class SegmentBuilder
    {
        private Segment _model;

        public SegmentBuilder()
        {
            this._model = new Segment();
            this._model.Departure = new System.DateTime(2030, 01, 01);
            this._model.Arrival = new System.DateTime(2030, 01, 02);
            this._model.PlaneType = "ABC";
        }

        public SegmentBuilder SetPlaneType(string type)
        {
            this._model.PlaneType = type;
            return this;
        }
        public SegmentBuilder SetDeparture(DateTime departure)
        {
            this._model.Departure = departure;
            return this;
        }


        public Segment Build()
        {
            return _model;
        }
    }
}
