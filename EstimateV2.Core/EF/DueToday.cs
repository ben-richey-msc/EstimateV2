namespace EstimateV2.Core.EF
{


    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    [Table("DueToday")]
    public partial class DueToday
    {
        public int ID { get; set; }

        [StringLength(60)]
        public string Port { get; set; }

        [StringLength(255)]
        public string Vessel { get; set; }

        [StringLength(255)]
        public string Voyage { get; set; }

        [Column("Departure Date")]
        public DateTime? Departure_Date { get; set; }

        [StringLength(255)]
        public string Status { get; set; }

        [Column("VCI Due Date")]
        public DateTime? VCI_Due_Date { get; set; }

        [Column("Days Overdue VCI")]
        [StringLength(255)]
        public string Days_Overdue_VCI { get; set; }

        [Column("PVE Due Date")]
        public DateTime? PVE_Due_Date { get; set; }

        [Column("Less Holiday")]
        [StringLength(255)]
        public string Less_Holiday { get; set; }

        [Column("Days Overdue PVE")]
        [StringLength(255)]
        public string Days_Overdue_PVE { get; set; }

        [StringLength(255)]
        public string Notes { get; set; }

        [StringLength(255)]
        public string Problems { get; set; }

        [Column("LINK Processed")]
        [StringLength(255)]
        public string LINK_Processed { get; set; }

        [Column("Potential Corrections")]
        [StringLength(255)]
        public string Potential_Corrections { get; set; }

        [StringLength(255)]
        public string Submitted { get; set; }

        [Column("Submission Date")]
        [StringLength(255)]
        public string Submission_Date { get; set; }

        [Column("Submitted By")]
        [StringLength(255)]
        public string Submitted_By { get; set; }

        [Column("DA number")]
        [StringLength(255)]
        public string DA_number { get; set; }

        [Column("LinkIM#")]
        [StringLength(255)]
        public string LinkIM_ { get; set; }

        [Column("LinkEX#")]
        [StringLength(255)]
        public string LinkEX_ { get; set; }

        [StringLength(255)]
        public string Detail { get; set; }

        [Column("PVE Status Date")]
        [StringLength(255)]
        public string PVE_Status_Date { get; set; }

        public int? ID_ESTIMATE { get; set; }

        public bool IC_REVALIDATED { get; set; }

        [Column("Ready To Process")]
        [StringLength(550)]
        public string Ready_To_Process { get; set; }

        [StringLength(60)]
        public string TERMINAL { get; set; }

        public bool Double_Call { get; set; }

        [Column("VCI Validated")]
        public DateTime? VCI_Validated { get; set; }
    }
}