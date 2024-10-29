namespace APP_THI_TRAC_NGHIEM_DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Setting
    {
        public int SettingID { get; set; }

        [Required]
        [StringLength(100)]
        public string SettingName { get; set; }

        [Required]
        [StringLength(255)]
        public string SettingValue { get; set; }
    }
}
