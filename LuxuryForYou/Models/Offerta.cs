namespace LuxuryForYou.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Offerta")]
    public partial class Offerta
    {
        [Key]
        public int idOfferta { get; set; }

        public int? idUtente { get; set; }

        public int? idAuto { get; set; }

        [Column(TypeName = "money")]
        public decimal? OffertaFatta { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DataOfferta { get; set; }

        public int? idAsta { get; set; }

        public virtual Asta Asta { get; set; }

        public virtual Autovettura Autovettura { get; set; }

        public virtual Utente Utente { get; set; }
    }
}
