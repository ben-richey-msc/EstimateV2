using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstimateV2.Core.XmlComponents
{
    public class RestowItem
    {
        public string? ID { get; set; }
        public string? Terminal { get; set; }
        public string? MovementType { get; set; }
        public string? SizeType { get; set; }
        public string? FullEmpty { get; set; }
        public bool Operator { get; set; }
        public string? RestowAmount { get; set; }
        public string? ReasonType { get; set; }
        public string? Weight { get; set; }
        public string? OOG { get; set; }
        public string? Imo { get; set; }
        public string? Damaged { get; set; }
        public string? NotFormsAccount { get; set; }
        public string? Comment { get; set; }
    }
}
