namespace APP_THI_TRAC_NGHIEM_DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Result
    {
        public int ResultID { get; set; }

        public int? ExamID { get; set; }

        public int UserID { get; set; }

        public double Score { get; set; }

        public DateTime? SubmittedAt { get; set; }

        public virtual Account Account { get; set; }

        public virtual Exam Exam { get; set; }
    }
}
