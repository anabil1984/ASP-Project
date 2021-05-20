using System.Collections.Generic;
using UiversityWebApp.App.ManageUniversity;
using UiversityWebApp.Domain;

namespace UiversityWebApp.App.ManageStudents
{
    public interface IManageStudent
    {
        List<StudentDTO> GetAllStudents(int uniId);
        StudentDTO GetStudentById(int studentId);
        
        List<StudentDTO> GetStudentByName(string name);
        void EditStudent(StudentDTO student);
        void EditStudent(Student student);
        void DeleteById(int studentId);
        void AddNewStudent(Student student);
        void AddNewStudent(StudentDTO student);
        List<Course> GetStudentCourses(int stID);
      
    }
}
