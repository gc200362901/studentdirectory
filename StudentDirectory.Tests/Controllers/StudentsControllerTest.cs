using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentDirectory.Controllers;
using Moq;
using StudentDirectory.Models;
using System.Linq;
using System.Web.Mvc;

namespace StudentDirectory.Tests.Controllers
{
    /// <summary>
    /// Summary description for StudentsControllerTest
    /// </summary>
    [TestClass]
    public class StudentsControllerTest
    {
        StudentsController controller;
        //StudentsController controller2;
        Mock<IMockStudentsRepository> mock;
        //Mock<IMockStudentsRepository> mockCourses;
        List<Student> students;
        //List<Enrollment> courses;

        [TestInitialize]
        public void TestInit()
        {
            
            mock = new Mock<IMockStudentsRepository>();

            //mockCourses = new Mock<IMockStudentsRepository>();

            students = new List<Student>
            {
                new Student { StudentId = 1, FirstName = "Student 1"},
                new Student { StudentId = 2, FirstName = "Student 2"},
                new Student { StudentId = 3, FirstName = "Student 3"}
            };

            //courses = new List<Enrollment>
            //{
            //    new Enrollment {EnrollmentId = 1, CourseCode = "FAKE1001"},
            //    new Enrollment {EnrollmentId = 2, CourseCode = "FAKE2001"},
            //    new Enrollment {EnrollmentId = 3, CourseCode = "FAKE3001"}
            //};

            mock.Setup(m => m.Students).Returns(students.AsQueryable());

            //mockCourses.Setup(mc => mc.Enrollments).Returns(courses.AsQueryable());

            controller = new StudentsController(mock.Object);

            //controller2 = new StudentsController(mockCourses.Object);
        }

       [TestMethod]
       public void IndexViewLoads()
        {
            //act
            var actual = controller.Index();

            //assert
            Assert.IsNotNull(actual);
        }

        // GET: Students
        [TestMethod]
        public void IndexLoadsStudents()
        {
            //act 
            var actual = (List<Student>)((ViewResult)controller.Index()).Model;

            //assert
            CollectionAssert.AreEqual(students, actual);
        }

        // GET: Students/Details
        [TestMethod]
        public void DetailsValidStudentId()
        {
            //act
            var actual = (Student)((ViewResult)controller.Details(1)).Model;

            //assert
            Assert.AreEqual(students[0], actual);
        }

        [TestMethod]
        public void DetailsNotValidStudentId()
        {

            //act
            var actual = (ViewResult)controller.Details(4);

            //assert
            Assert.AreEqual("Error", actual.ViewName);
        }

        [TestMethod]
        public void DetailsNullId()
        {
            //act
            var actual = (ViewResult)controller.Details(null);

            //assert
            Assert.AreEqual("Error", actual.ViewName);
        }

        //// GET: Students/Courses
        //[TestMethod]
        //public void CoursesStudnetValidStudentId()
        //{
        //    //act
        //    var actual = (Student)((ViewResult)controller2.Courses(1)).Model;

        //    //assert
        //    Assert.AreEqual(courses[0], actual);
        //}

        //[TestMethod]
        //public void CoursesStudentNotValidStudentId()
        //{

        //    //act
        //    var actual = (ViewResult)controller2.Courses(4);

        //    //assert
        //    Assert.AreEqual("Error", actual.ViewName);
        //}

        //[TestMethod]
        //public void CoursesStudentNullId()
        //{
        //    //act
        //    var actual = (ViewResult)controller2.Courses(null);

        //    //assert
        //    Assert.AreEqual("Error", actual.ViewName);
        //}

        // GET: Students/Create
        [TestMethod]
        public void CreateStudentViewLoads()
        {
            //act
            var actual = (ViewResult)controller.Create();

            //assert
            Assert.AreEqual("Create", actual.ViewName);
        }

        [TestMethod]
        public void CreateStudentValid()
        {
            //arrange
            Student s = new Student
            {
                FirstName = "New Artist"
            };

            //act
            var actual = (RedirectToRouteResult)controller.Create(s);

            //assert
            Assert.AreEqual("Index", actual.RouteValues["action"]);
        }

        [TestMethod]
        public void CreateInvalid()
        {
            //arrange
            Student s = new Student
            {
                FirstName = "New Artist"
            };

            controller.ModelState.AddModelError("key", "create error");

            //act
            var actual = (ViewResult)controller.Create(s);

            //assert
            Assert.AreEqual("Create", actual.ViewName);
        }

        // GET: Students/Edit
        [TestMethod]
        public void EditGetStudentValidId()
        {
            //act 
            var actual = ((ViewResult)controller.Edit(1)).Model;

            //assert
            Assert.AreEqual(students[0], actual);
        }

        [TestMethod]
        public void EditGetStudentInvalidId()
        {
            //act
            var actual = (ViewResult)controller.Edit(4);

            //assert
            Assert.AreEqual("Error", actual.ViewName);
        }

        [TestMethod]
        public void EditGetStudentNoId()
        {
            int? id = null;

            //act
            var actual = (ViewResult)controller.Edit(id);

            //assert
            Assert.AreEqual("Error", actual.ViewName);
        }

        // POST: Students/Edit
        [TestMethod]
        public void EditPostStudentValid()
        {
            //act
            var actual = (RedirectToRouteResult)controller.Edit(students[0]);

            //assert
            Assert.AreEqual("Index", actual.RouteValues["action"]);
        }

        [TestMethod]
        public void EditPostStudentInvalid()
        {
            //arrange
            controller.ModelState.AddModelError("key", "update error");

            //act
            var actual = (ViewResult)controller.Edit(students[0]);

            //assert
            Assert.AreEqual("Edit", actual.ViewName);
        }

        // GET: Students/Delete
        [TestMethod]
        public void DeleteGetStudentValidId()
        {
            //act 
            var actual = ((ViewResult)controller.Delete(1)).Model;

            //assert
            Assert.AreEqual(students[0], actual);
        }

        [TestMethod]
        public void DeleteGetStudentInvalidId()
        {
            //act
            var actual = (ViewResult)controller.Delete(4);

            //assert
            Assert.AreEqual("Error", actual.ViewName);
        }

        [TestMethod]
        public void DeleteGetStudentWithNoId()
        {
            //act
            var actual = (ViewResult)controller.Delete(null);

            //assert
            Assert.AreEqual("Error", actual.ViewName);
        }

        // POST: Students/Delete
        [TestMethod]
        public void DeletePostStudentValid()
        {
            //act
            var actual = (RedirectToRouteResult)controller.DeleteConfirmed(1);

            //assert
            Assert.AreEqual("Index", actual.RouteValues["action"]);
        }
    }
}
