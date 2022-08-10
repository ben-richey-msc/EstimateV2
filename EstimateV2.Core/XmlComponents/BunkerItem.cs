using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstimateV2.Core.XmlComponents
{
    public class BunkerItem
    {
        public string? ID { get; set; }
        public string? Type { get; set; }
        public string? Arrival { get; set; }
        public string? Purchase { get; set; }
        public string? Price { get; set; }
        public string? Departure { get; set; }
        public string? BunkerRemark { get; set; }

        public BunkerItem(string? id, string? type, string? arrival, string? purchase, string? price, string? departure, string? bunkerRemark)
        {
            ID = id;
            Type = type;
            Arrival = arrival;
            Purchase = purchase;
            Price = price;
            Departure = departure;
            BunkerRemark = bunkerRemark;
        }

        public BunkerItem()
        {

        }
    }
}
