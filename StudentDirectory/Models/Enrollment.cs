namespace StudentDirectory.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Enrollment")]
    public partial class Enrollment
    {
        public int EnrollmentId { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Course Code")]
        public string CourseCode { get; set; }

        [Display(Name = "Student ID")]
        public int StudentId { get; set; }

        public virtual Course Course { get; set; }

        public virtual Student Student { get; set; }
    }
}
