using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WPSPApi.Models
{
    public partial class WPSPOrigContext : DbContext
    {
        public WPSPOrigContext()
        {
        }

        public WPSPOrigContext(DbContextOptions<WPSPOrigContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Apply> Apply { get; set; }
        public virtual DbSet<Coordinator> Coordinator { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Econtact> Econtact { get; set; }
        public virtual DbSet<Elective> Elective { get; set; }
        public virtual DbSet<Patrol> Patrol { get; set; }
        public virtual DbSet<Patroller> Patroller { get; set; }
        public virtual DbSet<PatrollerCoordinator> PatrollerCoordinator { get; set; }
        public virtual DbSet<Patroltype> Patroltype { get; set; }
        public virtual DbSet<Phone> Phone { get; set; }
        public virtual DbSet<State> State { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=xxxxx\WORKTEST;Database=WPSPOrig;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apply>(entity =>
            {
                entity.ToTable("apply");

                entity.Property(e => e.ApplyId).HasColumnName("applyId");

                entity.Property(e => e.BirthDate)
                    .IsRequired()
                    .HasColumnName("birthDate")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Class)
                    .IsRequired()
                    .HasColumnName("class")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .IsRequired()
                    .HasColumnName("createdDate")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EMail)
                    .IsRequired()
                    .HasColumnName("eMail")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnName("gender")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("lastName")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.PatrollerNum).HasColumnName("patrollerNum");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasColumnName("state")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.StreetAddress)
                    .IsRequired()
                    .HasColumnName("streetAddress")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UniqueId)
                    .IsRequired()
                    .HasColumnName("uniqueID")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Zip)
                    .IsRequired()
                    .HasColumnName("zip")
                    .HasMaxLength(9)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Coordinator>(entity =>
            {
                entity.ToTable("coordinator");

                entity.Property(e => e.CoordinatorId).HasColumnName("coordinator_id");

                entity.Property(e => e.CoordinatorType)
                    .HasColumnName("coordinatorType")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.PatrollerId).HasColumnName("patrollerId");

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasColumnName("position")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.Type);

                entity.ToTable("course");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Econtact>(entity =>
            {
                entity.ToTable("econtact");

                entity.Property(e => e.EContactId).HasColumnName("eContactId");

                entity.Property(e => e.EAddress)
                    .IsRequired()
                    .HasColumnName("eAddress")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.EEmail)
                    .IsRequired()
                    .HasColumnName("eEmail")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.EName)
                    .IsRequired()
                    .HasColumnName("eName")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ENotes)
                    .IsRequired()
                    .HasColumnName("eNotes")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EPhone)
                    .IsRequired()
                    .HasColumnName("ePhone")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.ERelationship)
                    .IsRequired()
                    .HasColumnName("eRelationship")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PatrollerId).HasColumnName("patrollerId");
            });

            modelBuilder.Entity<Elective>(entity =>
            {
                entity.ToTable("elective");

                entity.Property(e => e.ElectiveId).HasColumnName("electiveId");

                entity.Property(e => e.CourseType)
                    .IsRequired()
                    .HasColumnName("course_type")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PatrollerId).HasColumnName("patrollerId");

                entity.Property(e => e.Year)
                    .IsRequired()
                    .HasColumnName("year")
                    .HasMaxLength(4)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Patrol>(entity =>
            {
                entity.HasKey(e => e.PatrolKey);

                entity.ToTable("patrol");

                entity.Property(e => e.PatrolKey)
                    .HasColumnName("patrolKey")
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Ahc).HasColumnName("AHC");

                entity.Property(e => e.Hc).HasColumnName("HC");
            });

            modelBuilder.Entity<Patroller>(entity =>
            {
                entity.ToTable("patroller");

                entity.Property(e => e.PatrollerId).HasColumnName("patroller_id");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.EMail)
                    .HasColumnName("eMail")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Family)
                    .HasColumnName("family")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.JoinYear)
                    .HasColumnName("joinYear")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("lastName")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Partner)
                    .HasColumnName("partner")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PatrolKey)
                    .HasColumnName("patrolKey")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.PatrolType)
                    .IsRequired()
                    .HasColumnName("patrolType")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PictureLink)
                    .HasColumnName("pictureLink")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PriPhId).HasColumnName("priPhId");

                entity.Property(e => e.SkipatrolNumber).HasColumnName("skipatrolNumber");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('OR')");

                entity.Property(e => e.StreetAddress)
                    .HasColumnName("streetAddress")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Zip)
                    .HasColumnName("zip")
                    .HasMaxLength(9)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PatrollerCoordinator>(entity =>
            {
                entity.ToTable("patroller_coordinator");

                entity.Property(e => e.PatrollerCoordinatorId).HasColumnName("patroller_coordinator_id");

                entity.Property(e => e.CoordinatorId)
                    .IsRequired()
                    .HasColumnName("coordinator_id")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.PatrollerId).HasColumnName("patroller_id");
            });

            modelBuilder.Entity<Patroltype>(entity =>
            {
                entity.ToTable("patroltype");

                entity.Property(e => e.PatrolTypeId).HasColumnName("patrolTypeId");

                entity.Property(e => e.PatrolType1)
                    .IsRequired()
                    .HasColumnName("patrolType")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Phone>(entity =>
            {
                entity.HasKey(e => e.PhId);

                entity.ToTable("phone");

                entity.Property(e => e.PhId).HasColumnName("phId");

                entity.Property(e => e.PatrollerId).HasColumnName("patrollerId");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasColumnName("phoneNumber")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(14)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.ToTable("state");

                entity.Property(e => e.StateId).HasColumnName("stateId");

                entity.Property(e => e.State1)
                    .IsRequired()
                    .HasColumnName("state")
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });
        }
    }
}
