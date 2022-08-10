using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstimateV2.Core.XmlComponents
{
    public class FromTo
    {
        public bool From { get; set; }
        public bool To { get; set; }



        public FromTo(string? f, string? t)
        {
            From = f != null && f == "true" ? true : false;
            To = t != null && t == "true" ? true : false;
        }

        public FromTo() { }
    }
}
