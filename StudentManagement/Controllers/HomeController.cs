using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models;
using StudentManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IWebHostEnvironment _hostEnvironment;

        public HomeController(IStudentRepository studentRepository,IWebHostEnvironment hostEnvironment)
        {
            _studentRepository = studentRepository;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            IEnumerable<Student> students = _studentRepository.GetStudents();
            return View(students);
        }
        public ViewResult Details(int? id)
        {
            // return $"id=={id},并且名字为{name}";
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Student = _studentRepository.GetStudent(id ?? 1),
                PageTitle = "学生详情"
            };
            return View(homeDetailsViewModel);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(StudentCreateViewModel model)
        { 
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (model.Photo != null)
                {
                    string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Photo.CopyTo(new FileStream(filePath,FileMode.Create));
                }
                Student newStudent = new Student
                {
                    Name = model.Name,
                    Email = model.Email,
                    ClassName = model.ClassName,
                    Photo = uniqueFileName,
                };
                _studentRepository.Add(newStudent);
                return RedirectToAction("Details", new { id = newStudent.Id });
            }
            return View();
        }
    }
}
