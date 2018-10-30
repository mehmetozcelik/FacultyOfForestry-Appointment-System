namespace OrmanFakultesi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sorumluluk")]
    public partial class Sorumluluk
    {
        public int ID { get; set; }

        public int? altSergiID { get; set; }

        public int? sorumluID { get; set; }

        public virtual AltSergi AltSergi { get; set; }

        public virtual SergiSorumlulari SergiSorumlulari { get; set; }
    }
}
