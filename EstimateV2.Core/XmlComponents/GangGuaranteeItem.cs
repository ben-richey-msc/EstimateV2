using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstimateV2.Core.XmlComponents
{
    public class GangGuaranteeItem
    {
        public string? ID { get; set; }
        public string? From { get; set; }
        public string? To { get; set; }
        public string? Quantity { get; set; }
        public string? ShoreCrane { get; set; }
        public string? Comment { get; set; }

        public GangGuaranteeItem(string? id, string? from, string? to, string? quantity, string? shoreCrane, string? comment)
        {
            ID = id;
            From = from;
            To = to;
            Quantity = quantity;
            ShoreCrane = shoreCrane;
            Comment = comment;
        }

        public GangGuaranteeItem()
        {

        }
    }
}
