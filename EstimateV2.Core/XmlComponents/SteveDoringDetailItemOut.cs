using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EstimateV2.Core.XmlComponents
{
    [Serializable, XmlRoot("gangworkingtimes")]
    public class SteveDoringDetailItemOut//: SteveDoringDetailItem

    {                
        [XmlAttribute]
        public string? from2 { get; set; }

        [XmlAttribute]
        public string? to2 { get; set; }

        [XmlAttribute]
        public string? number2 { get; set; }

        [XmlAttribute]
        public string? workingperiodpayrate2 { get; set; }



        public SteveDoringDetailItemOut()
        {
            //from2 = GlobalVCI.
            //to2 = item.To;
            //number2 = item.NumberOfGang;
            //workingperiodpayrate2 = GetHoursCode(item.SteveDoringHoursType);    
        }
        
        //empty contructor required for serialization
        //public SteveDoringDetailItemOut()
        //{

        //}

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
                    throw new Exception("SteveDoringHoursType not found");
            }
        }

    }
}
