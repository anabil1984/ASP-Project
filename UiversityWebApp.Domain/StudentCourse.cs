﻿using System;
using System.Collections.Generic;
using System.Text;

namespace UiversityWebApp.Domain
{
    public class StudentCourse
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
