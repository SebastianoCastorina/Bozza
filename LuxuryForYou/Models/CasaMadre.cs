namespace LuxuryForYou.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CasaMadre")]
    public partial class CasaMadre
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CasaMadre()
        {
            Autovettura = new HashSet<Autovettura>();
        }

        [Key]
        public int idCasaMadre { get; set; }

        [StringLength(50)]
        public string NomeCasaMadre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Autovettura> Autovettura { get; set; }
    }
}
