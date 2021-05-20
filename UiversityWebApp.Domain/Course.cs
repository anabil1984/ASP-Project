using System;
using System.Collections.Generic;
using System.Text;

namespace UiversityWebApp.Domain
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public int Grade { get; set; }
        public List<StudentCourse> StudentCourses { get; set; }

    }
}
