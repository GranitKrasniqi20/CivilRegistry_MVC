namespace CivilRegistry_MVC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MarriageCertificate
    {
        [Key]
        public int MarriageCertificateID { get; set; }

        [Column(TypeName = "date")]
        public DateTime RegistrationDate { get; private set; } = DateTime.Now;

        [Column(TypeName = "date")]
        public DateTime ExpirationDate { get; private set; } = DateTime.Now.AddYears(6);

        [Column(TypeName = "date")]
        private DateTime _MarriageDate;
        public DateTime MarriageDate
        {
            get { return _MarriageDate; }
            set
            {
                if (value <= DateTime.Now)
                {
                    _MarriageDate = value;
                }
                else throw new Exception();
            }
        }

        public int? Partner1ID { get; set; }

        public int? Partner2ID { get; set; }

        public virtual Person Partner1 { get; set; }

        public virtual Person Partner2 { get; set; }
    }
}
