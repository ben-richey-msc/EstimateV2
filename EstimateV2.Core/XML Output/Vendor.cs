using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstimateV2.Core.XML_Output
{
    public class Vendor
    {
        public Vendor(string vendorType, string terminalCode, int vendorCount)
        {
            this.VendorType = vendorType;
            this.TerminalCode = terminalCode;
            this.VendorCount = vendorCount;
            this.VendorName = "";
            this.SAPCode = -1;
        }

        //B.VENDOR_TYPE, B.[TERMINAL_CODE], COUNT(B.[VENDOR_TYPE]) AS [COUNT]
        public string VendorType { get; set; }
        public string TerminalCode { get; set; }
        public int VendorCount { get; set; }
        public string VendorName { get; set; }
        public double SAPCode { get; set; }
    }
}
