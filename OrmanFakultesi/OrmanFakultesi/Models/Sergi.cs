namespace OrmanFakultesi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sergi")]
    public partial class Sergi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sergi()
        {
            AltSergi = new HashSet<AltSergi>();
            Randevu = new HashSet<Randevu>();
        }

        public int sergiID { get; set; }

        [StringLength(150)]
        public string adi { get; set; }

        [StringLength(500)]
        public string kisaAciklama { get; set; }

        [StringLength(2000)]
        public string aciklama { get; set; }

        [StringLength(100)]
        public string resimYolu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AltSergi> AltSergi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Randevu> Randevu { get; set; }
    }
}
