namespace StudentDirectory.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StudentDirectoryModel : DbContext
    {
        public StudentDirectoryModel()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Enrollment> Enrollments { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .Property(e => e.CourseCode)
                .IsFixedLength();

            modelBuilder.Entity<Course>()
                .Property(e => e.Day)
                .IsFixedLength();

            modelBuilder.Entity<Course>()
                .Property(e => e.Time)
                .IsFixedLength();

            modelBuilder.Entity<Course>()
                .HasMany(e => e.Enrollments)
                .WithRequired(e => e.Course)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Enrollment>()
                .Property(e => e.CourseCode)
                .IsFixedLength();

            modelBuilder.Entity<Student>()
                .Property(e => e.Province)
                .IsFixedLength();

            modelBuilder.Entity<Student>()
                .Property(e => e.Postal)
                .IsFixedLength();

            modelBuilder.Entity<Student>()
                .Property(e => e.Phone)
                .IsFixedLength();

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Enrollments)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);
        }
    }
}
