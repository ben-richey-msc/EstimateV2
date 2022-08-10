using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstimateV2.Core.XmlComponents
{
    public class Departure
    {
        public Draft? Draft { get; set; }
        public string? LocomotiveService { get; set; }
        public bool CompletedTransitConvoy { get; set; }
        public string? SailedFromBerth { get; set; }
        public FromTo? AnchorageOut { get; set; }
        public FromTo? LayByBerth { get; set; }
        public List<PilotageItem>? Pilotage { get; set; }
        public string? PilotageExtraCost { get; set; }
        public List<TowageItem>? Towage { get; set; }
    }
}
