using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_AccountingDAL.DisconnectedLayer
{
    public class TrainingListDALDC
    {
        // Field data.
        private string _connectionString;
        private SqlDataAdapter _adapter = null;

        public TrainingListDALDC(string connectionString)
        {
            _connectionString = connectionString;
            // Configure the SqlDataAdapter.
            ConfigureAdapter(out _adapter);
        }

        private void ConfigureAdapter(out SqlDataAdapter adapter)
        {
            // Create the adapter and set up the SelectCommand.
            string strSQL = "";
            strSQL = strSQL + "SELECT [ID_ESTIMATE], ";
            strSQL = strSQL + "[Vessel], ";
            strSQL = strSQL + "[Voyage], ";
            strSQL = strSQL + "[Port], ";
            strSQL = strSQL + "[Departure Date] ";
            strSQL = strSQL + "FROM [DueToday] ";
            strSQL = strSQL + "WHERE ([PVE Due Date] <= GETDATE() ";
            strSQL = strSQL + " AND [Status] = 'VALIDATED' ";
            strSQL = strSQL + " AND ( [Ready To Process] <> 'Complete' OR [Ready To Process] IS NULL ) )";
            

            adapter = new SqlDataAdapter(strSQL, _connectionString);
            // Obtain the remaining command objects dynamically at runtime
            // using the SqlCommandBuilder.
            var builder = new SqlCommandBuilder(adapter);
        }

        //Returns datatable object with all rows
        public DataTable GetAllCourses()
        {
            DataTable courseData = new DataTable("TrainingList");
            _adapter.Fill(courseData);
            return courseData;
        }
 
        
        //Updates table by accepting a new datatable object
        public void UpdateCourses(DataTable modifiedTable)
        {
            _adapter.Update(modifiedTable);
        }
    }
}   