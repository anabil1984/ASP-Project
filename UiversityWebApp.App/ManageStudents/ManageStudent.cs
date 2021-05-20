using System;
using System.Collections.Generic;
using System.Text;
using UiversityWebApp.Data;
using UiversityWebApp.Domain;
using System.Linq;
using UiversityWebApp.App.ManageUniversity;

namespace UiversityWebApp.App.ManageStudents
{
    public class ManageStudent : IManageStudent
    {
        private readonly UniversityContext context;
        public Student Student { get; set; }
        public ManageStudent(UniversityContext context)
        {
            this.context = context;
        }
        public List<StudentDTO> GetStudentByName(string name)
        {
            var students = context.Students.Where(st => st.Name.Contains(name)).ToList();
            List<StudentDTO> StudentDtoList = new List<StudentDTO>();
            foreach (var st in students)
            {
                StudentDtoList.Add(new StudentDTO()
                {
                    StudentId = st.StudentId,
                    Name = st.Name,
                    Department = st.Department,
                    NoOfCourses= context.StudentCourses.
                Count(sc => sc.StudentId == st.StudentId)
                });
            }
  
            return StudentDtoList;
        }


        public List<StudentDTO> GetAllStudents(int uniId)
        {
            return context.Students.Where(student => student.UniversityId == uniId).
                Select(st => new StudentDTO()
            {
                StudentId = st.StudentId,
                Name = st.Name,
                Department = st.Department,
                UniversityId = st.UniversityId,
                NoOfCourses = context.StudentCourses.
                Count(sc =>sc.StudentId==st.StudentId)
            }).ToList();
        }

        public StudentDTO GetStudentById(int studentId)
        {
            //var student = context.Students.SingleOrDefault(st => st.StudentId == studentId);
            // return student;
            var student = context.Students.Where(st => st.StudentId == studentId).
                Select(st => new StudentDTO()
                {
                    StudentId = studentId,
                    Name = st.Name,
                    Department = st.Department,
                    UniversityId = st.UniversityId,
                    StudentCourses = st.StudentCourses,
                }).SingleOrDefault();
            return student;
        }

        public void DeleteById(int studentId)
        {
            var st= context.Students.SingleOrDefault(st => st.StudentId == studentId);
            context.Students.Remove(st);
            context.SaveChanges();
        }

        public void AddNewStudent(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
        }
        public void AddNewStudent(StudentDTO student)
        {
            context.Students.Add(
                new Student()
                {
                    Name=student.Name,
                    Department=student.Department,
                    UniversityId=student.UniversityId
                });
            context.SaveChanges();
        }

        public List<Course> GetStudentCourses(int stID)
        {
            var x = context.StudentCourses.Where(sc => sc.StudentId == stID).ToList();
            List<Course> courses = new List<Course>();
            foreach(var i in x)
            {
                var course = context.Courses.SingleOrDefault(c => c.CourseId == i.CourseId);
                 courses.Add(course);
            }
            return courses;
            // return context.Courses.Where(c => c.CourseId == x.CourseId).ToList();
        }
        public void EditStudent(StudentDTO student)
        {
            var s = context.Students.SingleOrDefault(st => st.StudentId == student.StudentId);
            if (s != null)
            {
                s.Name = student.Name;
                s.Department = student.Department;
                s.UniversityId = student.UniversityId; // this depends on the business logic
                context.SaveChanges();
            }

        }
        public void EditStudent(Student student)
        {
            var s = context.Students.SingleOrDefault(st => st.StudentId == student.StudentId);
            if (s != null)
            {
                s.Name = student.Name;
                s.Department = student.Department;
                s.UniversityId = student.UniversityId; // this depends on the business logic
                context.SaveChanges();
            }

        }
    }
}
