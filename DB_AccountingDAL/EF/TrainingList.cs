namespace DB_AccountingDAL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TrainingList")]
    public partial class Course: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [Key]
        public int TrainingListID { get; set; }

        [Required]
        [StringLength(50)]
        public string TrainingListName { get; set; }

        [Required]
        [StringLength(500)]
        public string TrainingListDescription { get; set; }

        [Required]
        [StringLength(50)]
        public string TrainingListInstructor { get; set; }

        public DateTime TrainingListDateTime { get; set; }

        public DateTime? MeetingSentDate { get; set; }

        [StringLength(4000)]
        public string TestRefIDs { get; set; }

        [StringLength(200)]
        public string Creator { get; set; }

        public DateTime? DateAdded { get; set; }
    }
}
