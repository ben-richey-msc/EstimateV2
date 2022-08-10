using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstimateV2.Core.XmlComponents
{
    public class Draft
    {
        public string? Fwd { get; set; }
        public string? Aft { get; set; }

        public Draft(string? f, string? a)
        {
            Fwd = f;
            Aft = a;
        }

        public Draft()
        {

        }
    }
}
