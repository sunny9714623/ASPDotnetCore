using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    Name = "george",
                    ClassName = ClassNameEnum.FirstGrade,
                    Email = "1@2.com"
                },
                new Student
                {
                    Id = 2,
                    Name = "乔治",
                    ClassName = ClassNameEnum.SecondGrade,
                    Email = "2@3.com"
                }
                );
        }
    }
}
