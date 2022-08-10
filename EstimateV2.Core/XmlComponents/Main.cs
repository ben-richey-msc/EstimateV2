using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstimateV2.Core.XmlComponents
{
    public class Main
    {
        public string? Port { get; set; }
        public string? Terminal { get; set; }
        public string? Vessel { get; set; }
        public string? Voyage { get; set; }
        public VesselInfo? vesselInfo { get; set; }
        public int? CanalNetTonage { get; set; }
        public int? PanamaTeuCapacity { get; set; }
        public int? Sueztier { get; set; }
        public List<string>? CallType { get; set; }
        public List<string>? BowThruster { get; set; }
        public FromTo? DryDockRepair { get; set; }
        public string? Comment { get; set; }
        public string? VciStatus { get; set; }
    }
}
