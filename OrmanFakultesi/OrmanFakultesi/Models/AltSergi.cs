namespace OrmanFakultesi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AltSergi")]
    public partial class AltSergi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AltSergi()
        {
            AltSergiResims = new HashSet<AltSergiResims>();
            Sorumluluk = new HashSet<Sorumluluk>();
        }

        public int altSergiID { get; set; }

        public int? sergiID { get; set; }

        [StringLength(500)]
        public string adi { get; set; }

        public int? bolumID { get; set; }

        [StringLength(500)]
        public string sergilendigiYer { get; set; }

        [StringLength(250)]
        public string sergiFirma { get; set; }

        [StringLength(2000)]
        public string sergiAciklama { get; set; }

        public int? sergiSorumlulariID { get; set; }

        public virtual BolumTanimi BolumTanimi { get; set; }

        public virtual Sergi Sergi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AltSergiResims> AltSergiResims { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sorumluluk> Sorumluluk { get; set; }
    }
}
