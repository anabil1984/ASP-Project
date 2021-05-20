using System;
using System.Collections.Generic;
using System.Text;

namespace UiversityWebApp.Domain
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public int  UniversityId { get; set; }
        public List<StudentCourse> StudentCourses { get; set; }

    }
}
