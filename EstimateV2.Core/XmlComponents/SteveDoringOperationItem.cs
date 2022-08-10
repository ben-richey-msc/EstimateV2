using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EstimateV2.Core.XmlComponents
{
    [XmlRoot ]
    public class SteveDoringOperationItem
    {
        [XmlIgnore]
        public string? ID { get; set; }
        [XmlIgnore]
        public string? Terminal { get; set; }
        [XmlIgnore]
        public string? OperationStarted { get; set; }
        [XmlIgnore]
        public string? OperationCompleted { get; set; }
        [XmlIgnore]
        public Lash? UnLashing { get; set; }
        [XmlIgnore]
        public Lash? Lashing { get; set; }
        [XmlArray("gangworkingtimes")]
        [XmlArrayItem("gang")]
        public List<SteveDoringDetailItem>? SteveDoringDetail { get; set; }
        [XmlIgnore]
        public List<StoppageDetailItem>? StoppageDetail { get; set; }
        [XmlIgnore]
        public List<GangGuaranteeItem>? GangGuarantee { get; set; }
    }
}
