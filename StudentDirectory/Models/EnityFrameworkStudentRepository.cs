using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentDirectory.Models
{
    public class EnityFrameworkStudentRepository : IMockStudentsRepository
    {
        private StudentDirectoryModel db = new StudentDirectoryModel();
        public IQueryable<Student> Students { get { return db.Students; } }

        //public IQueryable<Enrollment> Enrollments { get { return db.Enrollments; } }

        public void Delete(Student student)
        {
            throw new NotImplementedException();
        }

        public Student Save(Student student)
        {
            if (student.StudentId != null)
            {
                db.Students.Remove(student);
                db.SaveChanges();
            }
            else
            {
                db.Students.Add(student);
            }
            db.SaveChanges();
            return student;
        }
    }
}