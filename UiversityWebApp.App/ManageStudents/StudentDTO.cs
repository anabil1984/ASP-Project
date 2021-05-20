using System;
using System.Collections.Generic;
using System.Text;
using UiversityWebApp.Domain;

namespace UiversityWebApp.App.ManageUniversity
{
    public class StudentDTO
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public int UniversityId { get; set; }
        public List<StudentCourse> StudentCourses { get; set; }
        public int NoOfCourses { get; set; }

    }
}
