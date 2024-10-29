namespace APP_THI_TRAC_NGHIEM_DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Result
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Result()
        {
            Attempts = new HashSet<Attempt>();
        }

        public int ResultID { get; set; }

        public int? ExamID { get; set; }

        public int UserID { get; set; }

        public double Score { get; set; }

        public DateTime? SubmittedAt { get; set; }

        public virtual Account Account { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Attempt> Attempts { get; set; }

        public virtual Exam Exam { get; set; }
    }
}
