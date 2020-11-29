namespace CivilRegistry_MVC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Passport
    {
        [Key]
        public int PassportID { get; set; }

        [Column(TypeName = "date")]
        public DateTime RegistrationDate { get; private set; } = DateTime.Now;

        [Column(TypeName = "date")]
        public DateTime ExpirationDate { get; private set; } = DateTime.Now.AddYears(10);

        [Required]
        [StringLength(50)]
        public string EyeColor { get; set; }

        [Required]
        [StringLength(50)]
        public string MigrationPlace { get; set; }

        public int? PersonID { get; set; }

        public virtual Person Person { get; set; }
    }
}
