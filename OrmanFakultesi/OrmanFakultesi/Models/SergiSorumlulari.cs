namespace OrmanFakultesi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SergiSorumlulari")]
    public partial class SergiSorumlulari
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SergiSorumlulari()
        {
            Sorumluluk = new HashSet<Sorumluluk>();
        }

        [Key]
        public int sorumluID { get; set; }

        [StringLength(250)]
        public string adi { get; set; }

        [StringLength(500)]
        public string mail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sorumluluk> Sorumluluk { get; set; }
    }
}
