namespace APP_THI_TRAC_NGHIEM_DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class StudentAnswer
    {
        [Key]
        public int AnswerID { get; set; }

        public int? ExamID { get; set; }

        public int? UserID { get; set; }

        public int? QuestionID { get; set; }

        [StringLength(50)]
        public string SelectedOption { get; set; }

        public virtual Account Account { get; set; }

        public virtual Exam Exam { get; set; }

        public virtual Question Question { get; set; }
    }
}
