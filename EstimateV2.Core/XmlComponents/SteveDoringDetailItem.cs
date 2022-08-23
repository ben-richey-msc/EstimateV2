using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EstimateV2.Core.XmlComponents
{
    [XmlRootAttribute(ElementName = "d", IsNullable = false)]
    public class SteveDoringDetailItem
    {
        [XmlIgnore]
        public string? ID { get; set; }
        
        [XmlIgnore]
        public string? OperationType { get; set; }
        
        [XmlIgnore]
        public string? SteveDoringHoursType { get; set; } 
                
        [XmlIgnore]
        public string? ShoreCrane { get; set; }
        
        [XmlAttribute("from")]
        public string? From { get; set; }
        
        [XmlAttribute("to")]
        public string? To { get; set; }
        
        [XmlIgnore]
        public string? Duration { get; set; }
        
        [XmlIgnore]
        public string? Reason { get; set; }
        
        [XmlAttribute("number")]
        public string? NumberOfGang { get; set; }
        
        [XmlAttribute("workingperiodpayrate")]
        public string? WorkingPeriodPayRate { get; set; }   

        public SteveDoringDetailItem(string? iD, string? operationType, string? steveDoringHoursType, string? numberOfGang, string? shoreCrane, string? from, string? to, string? duration, string? reason)
        {
            ID = iD;
            OperationType = operationType;
            SteveDoringHoursType = steveDoringHoursType;
            NumberOfGang = numberOfGang;
            ShoreCrane = shoreCrane;
            From = from;
            To = to;
            Duration = duration;
            Reason = reason;
            WorkingPeriodPayRate = GetHoursCode(steveDoringHoursType);
        }

        public SteveDoringDetailItem()
        {

        }

        //calculate overtime pay code from SteveDoringHoursType
        private string GetHoursCode(string hourType)
        {
            switch (hourType)
            {
                case "Overtime":
                    return "OT";
                case "Normal Hours / Straight Time":
                    return "ST";
                case "Premium Time":
                    return "PT";
                default:
                    return "PT";
            }
        }


    }
}
