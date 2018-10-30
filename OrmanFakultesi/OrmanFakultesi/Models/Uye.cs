namespace OrmanFakultesi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Uye")]
    public partial class Uye
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Uye()
        {
            Randevu = new HashSet<Randevu>();
        }

        public int uyeID { get; set; }

        [StringLength(150)]
        public string kurumAdi { get; set; }

        [StringLength(50)]
        public string adi { get; set; }

        [StringLength(50)]
        public string soyadi { get; set; }

        [StringLength(50)]
        public string tc { get; set; }

        [StringLength(100)]
        public string mail { get; set; }

        [StringLength(50)]
        public string sifre { get; set; }

        [StringLength(30)]
        public string tel { get; set; }

        public bool? onay { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Randevu> Randevu { get; set; }
    }
}
