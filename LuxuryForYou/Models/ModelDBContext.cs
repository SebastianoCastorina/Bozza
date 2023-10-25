using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace LuxuryForYou.Models
{
    public partial class ModelDBContext : DbContext
    {
        public ModelDBContext()
            : base("name=ModelDBContext")
        {
        }

        public virtual DbSet<Asta> Asta { get; set; }
        public virtual DbSet<Autovettura> Autovettura { get; set; }
        public virtual DbSet<CasaMadre> CasaMadre { get; set; }
        public virtual DbSet<Offerta> Offerta { get; set; }
        public virtual DbSet<Utente> Utente { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autovettura>()
                .Property(e => e.Costo)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Offerta>()
                .Property(e => e.OffertaFatta)
                .HasPrecision(19, 4);
        }
    }
}
