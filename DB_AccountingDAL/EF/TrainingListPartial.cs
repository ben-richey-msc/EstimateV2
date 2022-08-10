using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace DB_AccountingDAL.EF
{
    public partial class Course
    {
        public override string ToString()
        {
            //return this.TrainingListDescription.Replace("\r\n", "~");
            return this.TrainingListDescription;
        }
    

        public static void PrintAllCourses()
        {
            using (var context = new TrainingEntities())
            {
                foreach (Course t in context.TrainingLists)
                {
                    //WriteLine(t.ToString());
                }
                foreach (Course t in context.TrainingLists.Where(t => t.TrainingListName == "OneDrive"))
                {
                    WriteLine(t);
                }
            }
        }
        
        public static void RemoveRecord(int courseId)
        {
            //find course to delete with primary key
            using (var context = new TrainingEntities())
            {
                Course courseToDelete = context.TrainingLists.Find(courseId);
                if (courseToDelete != null)
                {
                    context.TrainingLists.Remove(courseToDelete);
                    context.SaveChanges();
               
                }
            }
        } 

        public static void UpdateRecord(int courseId, string newVal)
        {
            //find course to update with primary key
            using (var context = new TrainingEntities())
            {
                Course courseToUpdate = context.TrainingLists.Find(courseId);
                if (courseToUpdate != null)
                {
                    WriteLine(context.Entry(courseToUpdate).State);
                    courseToUpdate.TrainingListDescription = newVal;
                    WriteLine(context.Entry(courseToUpdate).State);
                    context.SaveChanges();
                }
            }
        }

        public static void UpdateRecordCell(int courseId, string newVal)
        {
            //find course to update with primary key
            using (var context = new TrainingEntities())
            {
                Course courseToUpdate = context.TrainingLists.Find(courseId);
                if (courseToUpdate != null)
                {
                    WriteLine(context.Entry(courseToUpdate).State);
                    courseToUpdate.TrainingListDescription = newVal;
                    WriteLine(context.Entry(courseToUpdate).State);
                    context.SaveChanges();
                }
            }
        }
    }


}
