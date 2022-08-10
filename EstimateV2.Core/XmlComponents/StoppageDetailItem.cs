using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstimateV2.Core.XmlComponents
{
    public class StoppageDetailItem
    {
        public string? ID { get; set; }
        public string? OperationType { get; set; }
        public string? StoppageType { get; set; }
        public string? StoppageTypeGroup { get; set; }
        public string? NumberOfGang { get; set; }
        public string? ShoreCrane { get; set; }
        public string? From { get; set; }
        public string? To { get; set; }
        public string? Duration { get; set; }
        public string? Description { get; set; }

        public StoppageDetailItem(string? id, string? operationType, string? stoppageType, string? stoppageTGroup, string? numofGang, string? shoreCrane, string? from, string? to, string? duration, string? description)
        {
            ID = id;
            OperationType = operationType;
            StoppageType = stoppageType;
            StoppageTypeGroup = stoppageTGroup;
            NumberOfGang = numofGang;
            ShoreCrane = shoreCrane;
            From = from;
            To = to;
            Duration = duration;
            Description = description;
        }

        public StoppageDetailItem()
        {

        }
    }
}
