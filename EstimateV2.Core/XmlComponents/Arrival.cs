using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstimateV2.Core.XmlComponents
{
    public class Arrival
    {
        public string? VesselArrivesAtPilotStationRoads { get; set; }
        public FromTo? Drifitng { get; set; }
        public FromTo? DropAnchor { get; set; }
        public FromTo? LayByBerth { get; set; }
        public string? VesselBerth { get; set; }
        public bool CommencedTransitConvoy { get; set; }
        public Draft? Draft { get; set; }
        public string? Watchmen { get; set; }
        public List<PilotageItem>? Pilotage { get; set; }
        public List<TowageItem>? Towage { get; set; }
        public string? PilotageExtraCost { get; set; }
        public string? GangWayDown { get; set; }
        public string? AnchorageReason { get; set; }
    }
}
