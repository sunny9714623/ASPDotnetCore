using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public class MockStudentRepository : IStudentRepository
    {
        private List<Student> _studentList;
        public MockStudentRepository()
        {
            _studentList = new List<Student>
            {
                new Student(){ Id=1,Name="张三",ClassName="一年级",Email="jdkas@das.com"},
                new Student(){ Id=2,Name="李四",ClassName="二年级",Email="sdadsadsa@123.com"},
                new Student(){ Id=3,Name="王二麻子",ClassName="三年级",Email="dsa@42321.com"},
            };
        }
        public Student GetStudent(int id)
        {
            return _studentList.FirstOrDefault(t => t.Id == id); 
        }
    }
}
