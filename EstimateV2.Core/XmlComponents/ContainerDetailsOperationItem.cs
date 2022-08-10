using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstimateV2.Core.XmlComponents
{
    public class ContainerDetailsOperationItem
    {
        public string? ID { get; set; }
        public string? Terminal { get; set; }
        public string? MovementType { get; set; }
        public string? ContainerIso { get; set; }
        public string? FullEmpty { get; set; }
        public string? Operator { get; set; }
        public string? Amount { get; set; }
        public string? Weight { get; set; }
        public string? OOGCargo { get; set; }
        public string? DamagedCargo { get; set; }
        public string? Imo { get; set; }
        public string? Soc { get; set; }
        public string? CoastalCargo { get; set; }
        public string? FromToRail { get; set; }
        public string? FromToBarge { get; set; }
        public string? FromToTpf { get; set; }
        public string? FromToTruck { get; set; }
    }
}
