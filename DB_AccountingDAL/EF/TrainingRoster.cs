namespace DB_AccountingDAL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TrainingRoster")]
    public partial class TrainingRoster
    {
        [Key]
        public int RosterID { get; set; }

        public int TrainingID { get; set; }

        [Required]
        [StringLength(50)]
        public string RosterEmployee { get; set; }

        [Column("Absent?")]
        public bool Absent_ { get; set; }

        public bool Mandatory { get; set; }
    }
}
