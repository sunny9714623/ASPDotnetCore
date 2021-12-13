using Microsoft.AspNetCore.Http;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.ViewModels
{
    public class StudentCreateViewModel : Student
    {
        [Display(Name ="图片")]
        public new IFormFile Photo { get; set; }
    }
}
