using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstimateV2.Core.XmlComponents
{
    public class VesselShiftingItem
    {
        public int? ID { get; set; }
        public string? Type { get; set; }
        public string? From { get; set; }
        public string? To { get; set; }
        public string? Reason { get; set; }
        public string? PilotsNumber { get; set; }
        public string? TugsNumber { get; set; }
        public string? Mooring { get; set; }
        public string? TerminalFrom { get; set; }
        public string? TerminalTo { get; set; }

        public VesselShiftingItem(int? id, string? type, string? from, string? to, string? reason, string? pn, string? tn, string? m, string? terminalF, string? terminalT)
        {
            ID = id;
            Type = type;
            From = from;
            To = to;
            Reason = reason;
            PilotsNumber = pn;
            TugsNumber = tn;
            Mooring = m;
            TerminalFrom = terminalF;
            TerminalTo = terminalT;
        }
        public VesselShiftingItem()
        {

        }
    }
}
