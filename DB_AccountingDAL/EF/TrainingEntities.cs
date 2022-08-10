using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DB_AccountingDAL.EF
{
    public partial class TrainingEntities : DbContext
    {
        public TrainingEntities()
            : base("name=TrainingEntities")
        {
        }

        public virtual DbSet<Course> TrainingLists { get; set; }
        public virtual DbSet<TrainingRoster> TrainingRosters { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .Property(e => e.TrainingListName)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.TrainingListDescription)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.TrainingListInstructor)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.TestRefIDs)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.Creator)
                .IsUnicode(false);

            modelBuilder.Entity<TrainingRoster>()
                .Property(e => e.RosterEmployee)
                .IsUnicode(false); 
        }
    }
}
