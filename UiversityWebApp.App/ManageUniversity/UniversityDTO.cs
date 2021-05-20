using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using UiversityWebApp.Domain;

namespace UiversityWebApp.App.ManageUniversity
{
    public class UniversityDTO
    {
        public int Id { get; set; }
      
        //[Required]
        public string Name { get; set; }
      
        public string Address { get; set; }
        
        public int StudentCount { get; set; }
    }
    public class UinversityDTOList
    {
        public List<UniversityDTO>Universities { get; set; }
        public int UniversitiesCount { get; set; }
    }
}
