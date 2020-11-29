namespace CivilRegistry_MVC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BirthCertificate
    {
        [Key]
        public int BirthCertificateID { get; set; }

        [Column(TypeName = "date")]
        public DateTime RegistrationDate { get; private set; } = DateTime.Now;

        [Column(TypeName = "date")]
        public DateTime ExpirationDate { get; private set; } = DateTime.Now.AddMonths(6);

        [Required]
        [StringLength(50)]
        public string CivilStatus { get; set; }

        public int? PersonID { get; set; }

        public int? FatherID { get; set; }

        public int? MotherID { get; set; }

        public virtual Person Person { get; set; }

        public virtual Person Father { get; set; }

        public virtual Person Mother { get; set; }
    }
}
