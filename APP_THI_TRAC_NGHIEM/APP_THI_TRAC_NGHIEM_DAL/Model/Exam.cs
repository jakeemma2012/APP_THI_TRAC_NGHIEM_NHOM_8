namespace APP_THI_TRAC_NGHIEM_DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Exam
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Exam()
        {
            Attempts = new HashSet<Attempt>();
            ExamQuestions = new HashSet<ExamQuestion>();
            Feedbacks = new HashSet<Feedback>();
            Results = new HashSet<Result>();
            StudentAnswers = new HashSet<StudentAnswer>();
        }

        public int ExamID { get; set; }

        [Required]
        [StringLength(100)]
        public string ExamName { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int Duration { get; set; }

        [StringLength(255)]
        public string Rules { get; set; }

        public int? CreatedBy { get; set; }

        public int SubjectID { get; set; }

        public int NumQuestion { get; set; }

        public virtual Account Account { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Attempt> Attempts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExamQuestion> ExamQuestions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Feedback> Feedbacks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Result> Results { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentAnswer> StudentAnswers { get; set; }

        public virtual Subject Subject { get; set; }
    }
}
