using System;
using System.Collections.Generic;
using University.Common.Models;

namespace University.BAL.Repositories
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        IEnumerable<Student> GetStudents();
        Student GetStudentByID(int studentId);
        void InsertStudent(Student student);
        void DeleteStudent(int studentID);
        void UpdateStudent(Student student);
    }
}
