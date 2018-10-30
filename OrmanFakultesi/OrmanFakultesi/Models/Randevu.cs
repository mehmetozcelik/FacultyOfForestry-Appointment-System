namespace OrmanFakultesi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Randevu")]
    public partial class Randevu
    {
        public int randevuID { get; set; }

        public int? uyeID { get; set; }

        public DateTime? tarih { get; set; }

        [StringLength(50)]
        public string saat { get; set; }

        [StringLength(500)]
        public string ziyaretSebebi { get; set; }

        public int? ziyaretciSayisi { get; set; }

        public int? ziyaretKapsamID { get; set; }

        public int? sergiID { get; set; }

        [StringLength(2000)]
        public string altSergiIDS { get; set; }

        [StringLength(50)]
        public string durum { get; set; }

        public DateTime? onayTarih { get; set; }

        public int? kullaniciID { get; set; }

        public int? yasGrubuID { get; set; }

        [StringLength(500)]
        public string aciklama { get; set; }

        public virtual Kullanici Kullanici { get; set; }

        public virtual Sergi Sergi { get; set; }

        public virtual Uye Uye { get; set; }

        public virtual YasGrubu YasGrubu { get; set; }

        public virtual ZiyaretKapsam ZiyaretKapsam { get; set; }
    }
}
