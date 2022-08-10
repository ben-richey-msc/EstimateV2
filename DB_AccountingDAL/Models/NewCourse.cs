 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_AccountingDAL.Models
{
    public class NewCourse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Instructor { get; set; }
        public string CourseDate { get; set; }
        public string MeetingSentDate { get; set; }
        public string TestRefIDs { get; set; }
        public string Creator { get; set; }
        public string DateAdded { get; set; }
    }
}
