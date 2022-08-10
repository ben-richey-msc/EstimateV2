using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstimateV2.Core.XmlComponents
{
    public class VCI
    {
        public Header? Header { get; set; }
        public Operation? Operation { get; set; }
        public Container? Container { get; set; }
    }
}
