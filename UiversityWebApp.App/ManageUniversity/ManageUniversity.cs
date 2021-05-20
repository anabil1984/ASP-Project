using System.Collections.Generic;
using UiversityWebApp.Domain;
using System.Linq;
using UiversityWebApp.Data;
using Microsoft.EntityFrameworkCore;

namespace UiversityWebApp.App.ManageUniversity
{
    public class ManageUniversity : IManageUniversity
    {
        
        
        private readonly UniversityContext context;
        public ManageUniversity(UniversityContext context)
        {
            this.context = context;
        }

        public void DeleteUniversity(int uniId)
        {
            var u=context.Universities.SingleOrDefault(uni => uni.UniversityId == uniId);
            context.Universities.Remove(u);
            context.SaveChanges();
        }


        public UinversityDTOList GetUniversities()
        {
            #region
            //UinversityDTOList uinversityDTOList = new UinversityDTOList();
            //uinversityDTOList.Universities = new List<UniversityDTO>();
            //var universities = context.Universities.ToList();
            //foreach (var uni in universities)
            //{
            //    var uniDto = new UniversityDTO();
            //    uniDto.Id = uni.Id;
            //    uniDto.Address = uni.Address;
            //    uniDto.Name = uni.Name;
            //    uniDto.StudentCount = context.Universities.Include(st => st.Students)
            //        .Where(un => un.Id == uni.Id).FirstOrDefault().
            //        Students.
            //        Count();
            //    //  uniDto.StudentCount = context.Students.Count(st => st.UniversityId == uni.Id);
            //    uinversityDTOList.Universities.Add(uniDto);
            //}
            //uinversityDTOList.UniversitiesCount = universities.Count;
            //return uinversityDTOList;
            #endregion
            var unis = context.Universities;
           var uinversities= new UinversityDTOList()
            {
                Universities = unis.ToList().Select(c => new UniversityDTO {
                    Id = c.UniversityId, Name = c.Name, Address = c.Address,
                    StudentCount = unis.Include(st => st.Students).
                      Where(un => un.UniversityId == c.UniversityId).FirstOrDefault().
                      Students.
                      Count() }).ToList(),
                UniversitiesCount = unis.ToList().Count
            };
            return uinversities;

        }



        public UinversityDTOList GetUniversitiesByName(string searchName)
        {
            var unis = context.Universities;
            var uinversities = new UinversityDTOList()
            {
                Universities = unis.ToList().Select(c => new UniversityDTO
                {
                    Id = c.UniversityId,
                    Name = c.Name,
                    Address = c.Address,
                    StudentCount = unis.Include(st => st.Students).
                      Where(un => un.UniversityId == c.UniversityId).FirstOrDefault().
                      Students.Count()
                }).Where(uni => uni.Name.Contains(searchName)).ToList(),

                UniversitiesCount = unis.ToList().Count
            };
            return uinversities;
        }

        public University GetUniversityById(int universityId)
        {
            return context.Universities.SingleOrDefault(uni => uni.UniversityId == universityId);
           //var university = context.Universities.Where(uni => uni.UniversityId == universityId).
           //    Select(uni => new UniversityDTO()
           //    {
           //        Id = universityId,
           //        Address = uni.Address,
           //        Name = uni.Name,
           //        StudentCount = context.Students.Count(st => st.UniversityId == uni.UniversityId)
           //    }).SingleOrDefault();
           // return university;

        }
        public UniversityDTO GetUniversityDtoById(int universityId)
        {
            var university = context.Universities.Where(uni => uni.UniversityId == universityId).
                Select(uni => new UniversityDTO()
                {
                    Id = universityId,
                    Address = uni.Address,
                    Name = uni.Name,
                    StudentCount = context.Students.Count(st => st.UniversityId == uni.UniversityId)
                }).SingleOrDefault();
            return university;

        }

        public void AddNewUniversity(University uni)
        {
            
            var university = new University() { Name = uni.Name, Address = uni.Address };
             context.Universities.Add(university);
            context.SaveChanges();
        }
        public void AddNewUniversity(UniversityDTO uni)
        {

            var university = new University() { Name = uni.Name, Address = uni.Address };
            context.Universities.Add(university);
            context.SaveChanges();
        }

        public void EditUniversity(University uni)
        {
            var u = context.Universities.SingleOrDefault(un => un.UniversityId == uni.UniversityId);
            if (u != null)
            {
                u.Name = uni.Name;
                u.Address = uni.Address;
                context.SaveChanges();
            }
        }
        public void EditUniversity(UniversityDTO uni)
        {
            var u = context.Universities.SingleOrDefault(un => un.UniversityId == uni.Id);
            if (u != null)
            {
                u.Name = uni.Name;
                u.Address = uni.Address;
                context.SaveChanges();
            }
        }

    }
}

