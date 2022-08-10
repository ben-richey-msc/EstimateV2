using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstimateV2.Core.XmlComponents
{
    public class VesselBerthItem
    {
        public int ID { get; set; }
        public string? Terminal { get; set; }
        public string? ArrivalBerthTime { get; set; }
        public string? DepartureBerthTime { get; set; }
        public List<string>? CallType { get; set; }
        public FromTo? DryDock { get; set; }
    }
}
