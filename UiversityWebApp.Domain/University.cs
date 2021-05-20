using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UiversityWebApp.Domain
{
    public class University
    {
        public int UniversityId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        public List <Student> Students { get; set; }
        

    }
}
