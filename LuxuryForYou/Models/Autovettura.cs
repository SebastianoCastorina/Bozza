namespace LuxuryForYou.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Autovettura")]
    public partial class Autovettura
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Autovettura()
        {
            Asta = new HashSet<Asta>();
            Offerta = new HashSet<Offerta>();
        }

        [Key]
        public int idAuto { get; set; }

        [StringLength(50)]
        public string NomeModello { get; set; }

        [StringLength(50)]
        public string Colore { get; set; }

        [Column(TypeName = "money")]
        public decimal? Costo { get; set; }

        [StringLength(50)]
        public string Chilometraggio { get; set; }

        [StringLength(50)]
        public string Luogo { get; set; }

        [StringLength(50)]
        public string Anno { get; set; }

        public bool? HasAsta { get; set; }

        public int? idCasaMadre { get; set; }

        public bool? HasEpoca { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Asta> Asta { get; set; }

        public virtual CasaMadre CasaMadre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Offerta> Offerta { get; set; }
    }
}
