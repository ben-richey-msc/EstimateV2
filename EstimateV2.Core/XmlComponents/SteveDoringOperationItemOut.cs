using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EstimateV2.Core.XmlComponents
{
    public class SteveDoringOperationItemOut
    {
        [XmlArray("gangworkingtimes")]
        [XmlArrayItem("gang")]
        public List<SteveDoringDetailItemOut>? SteveDoringDetail { get; set; }

        public SteveDoringOperationItemOut()
        {

        }
        
        public SteveDoringOperationItemOut(VCI vci)
        {
            //SteveDoringDetail = new List< new SteveDoringDetailItemOut(vci)>
        }
    }


    
}
