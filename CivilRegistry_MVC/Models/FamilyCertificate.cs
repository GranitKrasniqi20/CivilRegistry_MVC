namespace CivilRegistry_MVC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FamilyCertificate
    {
        [Key]
        public int FamilyCertificatesID { get; set; }

        [Column(TypeName = "date")]
        public DateTime RegistrationDate { get; private set; } = DateTime.Now;

        [Column(TypeName = "date")]
        public DateTime ExpirationDate { get; private set; } = DateTime.Now.AddMonths(6);

        public string FamilyMembers { get; set; }

        public int? PersonID { get; set; }

        public virtual Person Person { get; set; }
    }
}
