namespace CivilRegistry_MVC
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CivilRegistryModel : DbContext
    {
        public CivilRegistryModel()
            : base("name=crModel")
        {
        }

        public virtual DbSet<BirthCertificate> BirthCertificates { get; set; }
        public virtual DbSet<DeathCertificate> DeathCertificates { get; set; }
        public virtual DbSet<FamilyCertificate> FamilyCertificates { get; set; }
        public virtual DbSet<IdentityCard> IdentityCards { get; set; }
        public virtual DbSet<MarriageCertificate> MarriageCertificates { get; set; }
        public virtual DbSet<Passport> Passports { get; set; }
        public virtual DbSet<Person> People { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BirthCertificate>()
                .Property(e => e.CivilStatus)
                .IsUnicode(false);

            modelBuilder.Entity<FamilyCertificate>()
                .Property(e => e.FamilyMembers)
                .IsUnicode(false);

            modelBuilder.Entity<Passport>()
                .Property(e => e.EyeColor)
                .IsUnicode(false);

            modelBuilder.Entity<Passport>()
                .Property(e => e.MigrationPlace)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.PersonalNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.Gender)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.BirthPlace)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.Municipality)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.Nationality)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.EmploymentStatus)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.Qualification)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.HealthCondition)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.BirthCertificates)
                .WithOptional(e => e.Father)
                .HasForeignKey(e => e.FatherID);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.BirthCertificates1)
                .WithOptional(e => e.Mother)
                .HasForeignKey(e => e.MotherID);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.BirthCertificates2)
                .WithOptional(e => e.Person)
                .HasForeignKey(e => e.PersonID);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.MarriageCertificates)
                .WithOptional(e => e.Partner1)
                .HasForeignKey(e => e.Partner1ID);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.MarriageCertificates1)
                .WithOptional(e => e.Partner2)
                .HasForeignKey(e => e.Partner2ID);
        }
    }
}
