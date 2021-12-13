using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public class SQLStudentRepository : IStudentRepository
    {
        private readonly AppDbContext _dbcontext;
        public SQLStudentRepository(AppDbContext context)
        {
            _dbcontext = context;
        }
        public Student Add(Student student)
        {
            _dbcontext.Students.Add(student);
            _dbcontext.SaveChanges();
            return student;
        }

        public Student Delete(int id)
        {
            Student student = _dbcontext.Students.Find(id);
            if (student != null)
            {
                _dbcontext.Students.Remove(student);
                _dbcontext.SaveChanges();
            }
            return student;
        }

        public Student GetStudent(int id)
        {
            return _dbcontext.Students.Find(id);
        }

        public IEnumerable<Student> GetStudents()
        {
            return _dbcontext.Students;
        }

        public Student Update(Student updateStudent)
        {
            var student = _dbcontext.Students.Attach(updateStudent);
            student.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dbcontext.SaveChanges();
            return updateStudent;
        }
    }
}
