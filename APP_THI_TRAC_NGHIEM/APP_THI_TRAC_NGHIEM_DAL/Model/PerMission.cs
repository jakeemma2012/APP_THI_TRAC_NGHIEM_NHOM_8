namespace APP_THI_TRAC_NGHIEM_DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PerMission")]
    public partial class PerMission
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PerMission()
        {
            Teachers = new HashSet<Teacher>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PerMisID { get; set; }

        [Required]
        [StringLength(50)]
        public string PerMisName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
