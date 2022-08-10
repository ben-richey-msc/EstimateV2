using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstimateV2.Core.XmlComponents
{
    public class Container
    {
        public List<ContainerDetailsOperationItem>? ContainersDetailsOperation { get; set; }
        public List<RestowItem>? Restow { get; set; }
        public List<HatchCoverItem>? HatchCover { get; set; }
    }
}
