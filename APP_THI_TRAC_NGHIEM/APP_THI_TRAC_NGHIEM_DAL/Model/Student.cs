namespace APP_THI_TRAC_NGHIEM_DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Student")]
    public partial class Student
    {
        [StringLength(50)]
        public string StudentID { get; set; }

        public int UserID { get; set; }

        [StringLength(150)]
        public string StudentName { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        [Column(TypeName = "date")]
        public DateTime Birt { get; set; }

        [StringLength(150)]
        public string School { get; set; }

        [StringLength(50)]
        public string Class { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateStart { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateEnd { get; set; }

        [StringLength(150)]
        public string Image { get; set; }

        public virtual Account Account { get; set; }
    }
}
