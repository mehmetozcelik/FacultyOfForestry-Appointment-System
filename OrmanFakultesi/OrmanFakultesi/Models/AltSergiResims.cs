namespace OrmanFakultesi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AltSergiResims
    {
        [Key]
        public int resimID { get; set; }

        public int? SergiID { get; set; }

        [StringLength(150)]
        public string path { get; set; }

        public virtual AltSergi AltSergi { get; set; }
    }
}
