namespace CivilRegistry_MVC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DeathCertificate
    {
        [Key]
        public int DeathCertificatesID { get; set; }

        [Column(TypeName = "date")]
        public DateTime RegistrationDate { get; private set; } = DateTime.Now;

        [Column(TypeName = "date")]
        public DateTime ExpirationDate { get; private set; } = DateTime.Now.AddMonths(6);

        [Column(TypeName = "date")]
        private DateTime _DeathDate;
        public DateTime DeathDate
        {
            get { return _DeathDate; }
            set
            {
                if (value <= DateTime.Now)
                {
                    _DeathDate = value;
                }
                else throw new Exception();
            }
        }


        public int? PersonID { get; set; }

        public virtual Person Person { get; set; }
    }
}
