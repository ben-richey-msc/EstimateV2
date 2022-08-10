using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EstimateV2.Core.XmlComponents
{
    public class Operation
    {
        [XmlArray("gangworsdfkingtimes")]
        [XmlArrayItem("gansdfg")]
        public List<SteveDoringOperationItem>? SteveDoringOperation { get; set; }
        public List<ServiceItem>? Service { get; set; }
        public List<BunkerItem>? Bunker { get; set; }
    }
}
