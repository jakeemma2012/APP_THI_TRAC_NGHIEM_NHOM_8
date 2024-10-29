namespace APP_THI_TRAC_NGHIEM_DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Feedback")]
    public partial class Feedback
    {
        public int FeedbackID { get; set; }

        public int? ExamID { get; set; }

        public int? UserID { get; set; }

        [StringLength(255)]
        public string Comments { get; set; }

        public int? Rating { get; set; }

        public virtual Account Account { get; set; }

        public virtual Exam Exam { get; set; }
    }
}
