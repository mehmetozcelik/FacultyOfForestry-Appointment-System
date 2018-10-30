namespace OrmanFakultesi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Mail")]
    public partial class Mail
    {
        public int mailID { get; set; }

        [StringLength(100)]
        public string gonderen { get; set; }

        [StringLength(100)]
        public string alan { get; set; }

        public DateTime? tarih { get; set; }

        [StringLength(2000)]
        public string icerik { get; set; }
    }
}
