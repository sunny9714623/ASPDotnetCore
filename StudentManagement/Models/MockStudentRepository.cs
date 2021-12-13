﻿using System;
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
                new Student(){ Id=1,Name="张三",ClassName=ClassNameEnum.FirstGrade,Email="jdkas@das.com"},
                new Student(){ Id=2,Name="李四",ClassName=ClassNameEnum.SecondGrade,Email="sdadsadsa@123.com"},
                new Student(){ Id=3,Name="王二麻子",ClassName=ClassNameEnum.GradeThree,Email="dsa@42321.com"},
            };
        }

        public Student Add(Student student)
        {
            student.Id = _studentList.Max(s => s.Id) + 1;
            _studentList.Add(student);
            return student;
        }

        public Student Delete(int id)
        {
            Student student = _studentList.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                _studentList.Remove(student);
            }
            return student;
        }

        public Student GetStudent(int id)
        {
            return _studentList.FirstOrDefault(t => t.Id == id); 
        }

        public IEnumerable<Student> GetStudents()
        {
            return _studentList;
        }

        public Student Update(Student updateStudent)
        {
            Student student = _studentList.FirstOrDefault(s => s.Id == updateStudent.Id);
            if (student != null)
            {
                student.Name = updateStudent.Name;
                student.Email = updateStudent.Email;
                student.ClassName = updateStudent.ClassName;
            }
            return student;
        }
    }
}
