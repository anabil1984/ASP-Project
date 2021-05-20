using System;
using System.Collections.Generic;
using System.Text;
using UiversityWebApp.Domain;

namespace UiversityWebApp.App.ManageUniversity
{
    public interface IManageUniversity
    {
        UinversityDTOList GetUniversities();
         University GetUniversityById(int universityId);
        UniversityDTO GetUniversityDtoById(int universityId);

        UinversityDTOList GetUniversitiesByName(string searchName);
         void DeleteUniversity(int id);
        void AddNewUniversity(University uni);
        void AddNewUniversity(UniversityDTO uni);
        void EditUniversity(University uni);
        void EditUniversity(UniversityDTO uni);


    }
}
