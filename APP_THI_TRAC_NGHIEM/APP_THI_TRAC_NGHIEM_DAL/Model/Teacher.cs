namespace APP_THI_TRAC_NGHIEM_DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Teacher")]
    public partial class Teacher
    {
        [StringLength(50)]
        public string TeacherID { get; set; }

        public int UserID { get; set; }

        [StringLength(150)]
        public string TeacherName { get; set; }

        public int TeacherSubjectsID { get; set; }

        [StringLength(150)]
        public string AddRess { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [Column(TypeName = "date")]
        public DateTime Birth { get; set; }

        [StringLength(150)]
        public string Email { get; set; }

        public int PerMisID { get; set; }

        public virtual Account Account { get; set; }

        public virtual PerMission PerMission { get; set; }

        public virtual Subject Subject { get; set; }
    }
}
