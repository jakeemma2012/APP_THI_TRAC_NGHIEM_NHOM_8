namespace APP_THI_TRAC_NGHIEM_DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Question
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Question()
        {
            ExamQuestions = new HashSet<ExamQuestion>();
            StudentAnswers = new HashSet<StudentAnswer>();
        }

        public int QuestionID { get; set; }

        [Required]
        [StringLength(255)]
        public string QuestionText { get; set; }

        public int? SubjectID { get; set; }

        [Required]
        [StringLength(20)]
        public string QuestionType { get; set; }

        [Required]
        public string AnswerOptions { get; set; }

        public int Answer { get; set; }

        [Required]
        [StringLength(50)]
        public string TeacherID { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateCreate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExamQuestion> ExamQuestions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentAnswer> StudentAnswers { get; set; }

        public virtual Subject Subject { get; set; }
    }
}
