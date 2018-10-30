namespace OrmanFakultesi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ZiyaretKapsam")]
    public partial class ZiyaretKapsam
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ZiyaretKapsam()
        {
            Randevu = new HashSet<Randevu>();
        }

        public int ziyaretKapsamID { get; set; }

        [StringLength(150)]
        public string adi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Randevu> Randevu { get; set; }
    }
}
