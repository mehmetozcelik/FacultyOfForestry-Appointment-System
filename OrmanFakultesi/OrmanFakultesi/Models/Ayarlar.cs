namespace OrmanFakultesi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ayarlar")]
    public partial class Ayarlar
    {
        [Key]
        public int ayarID { get; set; }

        public int? MaxsaatlikRandevuKisiSayisi { get; set; }
    }
}
