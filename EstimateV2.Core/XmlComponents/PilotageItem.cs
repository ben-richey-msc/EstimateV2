using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstimateV2.Core.XmlComponents
{
    public class PilotageItem
    {
        public int? ID { get; set; }
        public string? PilotType { get; set; }
        public string? Number { get; set; }
        public string? From { get; set; }
        public string? To { get; set; }
        public string? Duration { get; set; }
        public string? Comment { get; set; }

        public PilotageItem(int? i, string? p, string? n, string? f, string? t, string? d, string? c)
        {
            ID = i;
            PilotType = p;
            Number = n;
            From = f;
            To = t;
            Duration = d;
            Comment = c;
     
        }
        public PilotageItem()
        {

        }
    }


    
}
