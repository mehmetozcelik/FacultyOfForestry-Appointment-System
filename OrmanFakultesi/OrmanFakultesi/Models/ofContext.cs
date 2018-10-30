namespace OrmanFakultesi.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ofContext : DbContext
    {
        public ofContext()
            : base("name=ofContext")
        {
        }

        public virtual DbSet<AltSergi> AltSergi { get; set; }
        public virtual DbSet<AltSergiResims> AltSergiResims { get; set; }
        public virtual DbSet<Ayarlar> Ayarlar { get; set; }
        public virtual DbSet<BolumTanimi> BolumTanimi { get; set; }
        public virtual DbSet<Kullanici> Kullanici { get; set; }
        public virtual DbSet<Mail> Mail { get; set; }
        public virtual DbSet<Randevu> Randevu { get; set; }
        public virtual DbSet<Sergi> Sergi { get; set; }
        public virtual DbSet<SergiSorumlulari> SergiSorumlulari { get; set; }
        public virtual DbSet<Sorumluluk> Sorumluluk { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Uye> Uye { get; set; }
        public virtual DbSet<YasGrubu> YasGrubu { get; set; }
        public virtual DbSet<Yetki> Yetki { get; set; }
        public virtual DbSet<ZiyaretKapsam> ZiyaretKapsam { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AltSergi>()
                .HasMany(e => e.AltSergiResims)
                .WithOptional(e => e.AltSergi)
                .HasForeignKey(e => e.SergiID);
        }
    }
}
