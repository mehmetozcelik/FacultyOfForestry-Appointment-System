namespace OrmanFakultesi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kullanici")]
    public partial class Kullanici
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kullanici()
        {
            Randevu = new HashSet<Randevu>();
        }

        public int kullaniciID { get; set; }

        [StringLength(150)]
        public string adi { get; set; }

        [StringLength(150)]
        public string soyadi { get; set; }

        [StringLength(250)]
        public string mail { get; set; }

        public int? yetkiID { get; set; }

        [StringLength(100)]
        public string sifre { get; set; }

        public virtual Yetki Yetki { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Randevu> Randevu { get; set; }
    }
}
