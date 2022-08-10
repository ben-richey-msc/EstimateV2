using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstimateV2.Core.XmlComponents
{
    public class TowageItem : PilotageItem
    {
        public string? TugType { get; set; }
        public string? DueToBowThrusterNotOperated { get; set; }

        public TowageItem(int? i, string? t, string? n, string? f, string? to, string? d, string? due, string? c) : base(i, t, n, f, to, d, c)
        {
            ID = i;
            TugType = t;
            Number = n;
            From = f;
            To = to;
            Duration = d;
            DueToBowThrusterNotOperated = due;
        }
        public TowageItem()
        {

        }
    }
}
