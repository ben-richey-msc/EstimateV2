using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstimateV2.Core.XmlComponents
{
    public class Header
    {
        public Main? main { get; set; }
        public List<VesselBerthItem>? vesselBerth { get; set; }
        public Arrival? arrival { get; set; }
        public List<VesselShiftingItem>? vesselShifting { get; set; }
        public Departure? departure { get; set; }
    }
}
