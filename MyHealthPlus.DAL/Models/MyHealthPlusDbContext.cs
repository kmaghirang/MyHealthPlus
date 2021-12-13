using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MyHealthPlus.DAL.Models
{
    public partial class MyHealthPlusDbContext : DbContext
    {
        public MyHealthPlusDbContext()
            : base("name=MyHealthPlusDbContext")
        {
        }

        public virtual DbSet<Appointments> Appointments { get; set; }
        public virtual DbSet<ErrorLogs> ErrorLogs { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<CheckUpTypes> CheckUpTypes { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<TimeRangeList> TimeRangeList { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointments>()
                .Property(e => e.UserNotes)
                .IsUnicode(false);

            modelBuilder.Entity<Appointments>()
                .Property(e => e.DoctorNotes)
                .IsUnicode(false);

            modelBuilder.Entity<Appointments>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Appointments>()
                .Property(e => e.UpdatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<ErrorLogs>()
                .Property(e => e.Level)
                .IsUnicode(false);

            modelBuilder.Entity<ErrorLogs>()
                .Property(e => e.CallSite)
                .IsUnicode(false);

            modelBuilder.Entity<ErrorLogs>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<ErrorLogs>()
                .Property(e => e.Message)
                .IsUnicode(false);

            modelBuilder.Entity<ErrorLogs>()
                .Property(e => e.StackTrace)
                .IsUnicode(false);

            modelBuilder.Entity<ErrorLogs>()
                .Property(e => e.InnerException)
                .IsUnicode(false);

            modelBuilder.Entity<ErrorLogs>()
                .Property(e => e.AdditionalInfo)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.MiddleName)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Extension)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.UpdatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Appointments)
                .WithRequired(e => e.Users)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CheckUpTypes>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<CheckUpTypes>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<CheckUpTypes>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<CheckUpTypes>()
                .Property(e => e.UpdatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Roles>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Roles>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Roles>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Roles>()
                .Property(e => e.UpdatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Status>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Status>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Status>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Status>()
                .Property(e => e.UpdatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<TimeRangeList>()
                .Property(e => e.Period)
                .IsUnicode(false);

            modelBuilder.Entity<TimeRangeList>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<TimeRangeList>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<TimeRangeList>()
                .Property(e => e.UpdatedBy)
                .IsUnicode(false);
        }
    }
}
