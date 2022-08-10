using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstimateV2.Core.XmlComponents
{
    public class Lash
    {
        public string? Completed { get; set; }
        public string? DoneBy { get; set; }

        public Lash(string? c, string? d)
        {
            Completed = c;
            DoneBy = d;
        }
        public Lash()
        {

        }
    }
}
