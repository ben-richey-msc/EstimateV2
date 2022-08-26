using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EstimateV2.Core.XML_Output
{
    public class OutputHelper
    {
        public readonly string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        public void Helper()
        {

            using (var con = new SqlConnection("Server=usasqllogistics.interlink-intranet.net;Database=DB_MARINE_OPS;Trusted_Connection=True"))
            {
                con.Open();
                string sql = @"Select *
                                    FROM [DB_MARINE_OPS].[dbo].[a_tFleet_List]";
                SqlCommand myCommand = new SqlCommand(sql, con);

                // Obtain a data reader a la ExecuteReader().
                using (SqlDataReader myDataReader = myCommand.ExecuteReader())
                {
                    // Loop over the results.
                    while (myDataReader.Read())
                    {
                        Debug.WriteLine($"-> Make: {myDataReader["Flag"]}, PetName: {myDataReader["Built"]}.");
                    }
                }
            }

        }
        

        public List<Vendor> GetVendorList()
        {
            List<Vendor> vendorList = new List<Vendor>();
            using (var con = new SqlConnection("Server=usasqllogistics.interlink-intranet.net;Database=DB_ESTIMATES;Trusted_Connection=True"))
            {
                con.Open();
                string sql = @"	USE DB_ESTIMATES
	                            SELECT B.VENDOR_TYPE, B.[TERMINAL_CODE], COUNT(B.[VENDOR_TYPE]) AS [COUNT]
		                        FROM VENDORS_ESTIMATED B 
	                            WHERE B.[ACTIVE_RECORD] = 0
	                            GROUP BY B.[VENDOR_TYPE], B.[TERMINAL_CODE]
		                        HAVING B.[TERMINAL_CODE] = 'USBALPP'";
                using (SqlCommand myCommand = new SqlCommand(sql, con))
                {
                    using (SqlDataReader reader = myCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            vendorList.Add(new Vendor(reader.GetString((reader.GetOrdinal("VENDOR_TYPE"))), reader.GetString(reader.GetOrdinal("TERMINAL_CODE")), reader.GetInt32(reader.GetOrdinal("COUNT"))));
                        }
                        reader.Close();

                        foreach (var vendor in vendorList)
                        {
                            GetNameAndSAP(vendor, con);
                        }

                        foreach (var vendor in vendorList)
                        {
                            switch (vendor.VendorType)
                            {
                                case "SEA PILOT":
                                    GetPilotXML();
                                    break;
                                case "DOCKING PILOT":
                                    // TODO
                                    break;
                                case "MOORING/UNMOORING":
                                    // TODO
                                    break;
                                case "TOWAGE":
                                    // TODO
                                    break;
                                default:
                                    break;
                            }
                        }

                        //GetPilotXML();
                    }
                }
            }
            foreach (var item in vendorList)
            {
                Debug.WriteLine(item.VendorType);   
            }

            return vendorList;
        }

        //add Vendor Name and SAP to Vendor object
        private void GetNameAndSAP(Vendor vendor, SqlConnection con)
        {
            string sql = @"	USE DB_ESTIMATES
	                        SELECT [VENDOR_NAME], [SAP_ACCOUNT_CODE] 
		                    FROM VENDORS_ESTIMATED WHERE [TERMINAL_CODE] = @tc 
		                    AND [VENDOR_TYPE] = @vt 
		                    AND [ACTIVE_RECORD] = 0";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@tc", vendor.TerminalCode);
            cmd.Parameters.AddWithValue("@vt", vendor.VendorType);
            using (cmd)
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        vendor.VendorName = reader.GetString(reader.GetOrdinal("VENDOR_NAME"));
                        vendor.SAPCode = reader.GetDouble(reader.GetOrdinal("SAP_ACCOUNT_CODE"));
                    }
                }
                
            }
        }

        private void GetPilotXML()
        {
            Debug.WriteLine("test");
            string path = @"C:\Users\benjamin.richey\source\repos\EstimateV2\USBAL-MSC MICHAELA-IX227R-25JUL2022-131619.xml";
            XElement root = XElement.Load(path);
            IEnumerable<XElement> address =
                from el in root.Elements("header").Elements("arrival").Elements("pilotage").Elements("pilotageitem")
                where (string)el.Element("pilottype") == "Sea"
                select el;
            foreach (XElement el in address)
                //Debug.WriteLine(el);
                System.Windows.MessageBox.Show((string)el.Attribute("id"));
        }


    }
}
    
