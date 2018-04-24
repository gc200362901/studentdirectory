using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDirectory.Models
{
    public interface IMockStudentsRepository
    {
        IQueryable<Student> Students { get; }

        //IQueryable<Enrollment> Enrollments { get; }

        Student Save(Student student);
        void Delete(Student student);

    }
}
