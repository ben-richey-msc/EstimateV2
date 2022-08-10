using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;


namespace EstimateV2.Core.EF
{
    public partial class VesselEntities : DbContext
    {
        public VesselEntities()
            : base("name=VesselEntities")
        {
        }


        public virtual DbSet<DueToday> DueTodays { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DueToday>()
                .Property(e => e.Port)
                .IsUnicode(false);

            modelBuilder.Entity<DueToday>()
                .Property(e => e.Vessel)
                .IsUnicode(false);

            modelBuilder.Entity<DueToday>()
                .Property(e => e.Voyage)
                .IsUnicode(false);

            modelBuilder.Entity<DueToday>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<DueToday>()
                .Property(e => e.Days_Overdue_VCI)
                .IsUnicode(false);

            modelBuilder.Entity<DueToday>()
                .Property(e => e.Less_Holiday)
                .IsUnicode(false);

            modelBuilder.Entity<DueToday>()
                .Property(e => e.Days_Overdue_PVE)
                .IsUnicode(false);

            modelBuilder.Entity<DueToday>()
                .Property(e => e.Notes)
                .IsUnicode(false);

            modelBuilder.Entity<DueToday>()
                .Property(e => e.Problems)
                .IsUnicode(false);

            modelBuilder.Entity<DueToday>()
                .Property(e => e.LINK_Processed)
                .IsUnicode(false);

            modelBuilder.Entity<DueToday>()
                .Property(e => e.Potential_Corrections)
                .IsUnicode(false);

            modelBuilder.Entity<DueToday>()
                .Property(e => e.Submitted)
                .IsUnicode(false);

            modelBuilder.Entity<DueToday>()
                .Property(e => e.Submission_Date)
                .IsUnicode(false);

            modelBuilder.Entity<DueToday>()
                .Property(e => e.Submitted_By)
                .IsUnicode(false);

            modelBuilder.Entity<DueToday>()
                .Property(e => e.DA_number)
                .IsUnicode(false);

            modelBuilder.Entity<DueToday>()
                .Property(e => e.LinkIM_)
                .IsUnicode(false);

            modelBuilder.Entity<DueToday>()
                .Property(e => e.LinkEX_)
                .IsUnicode(false);

            modelBuilder.Entity<DueToday>()
                .Property(e => e.Detail)
                .IsUnicode(false);

            modelBuilder.Entity<DueToday>()
                .Property(e => e.PVE_Status_Date)
                .IsUnicode(false);

            modelBuilder.Entity<DueToday>()
                .Property(e => e.Ready_To_Process)
                .IsUnicode(false);

            modelBuilder.Entity<DueToday>()
                .Property(e => e.TERMINAL)
                .IsUnicode(false);
        }
    }
}
