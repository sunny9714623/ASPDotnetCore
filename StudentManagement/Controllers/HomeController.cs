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
        public ViewResult Details(int id)
        {

            throw new Exception("此异常发生在Details视图中");
            Student student = _studentRepository.GetStudent(id);
            if (student == null)
            {
                Response.StatusCode = 404;
                return View("StudentNotFound", id);
            }
            // return $"id=={id},并且名字为{name}";
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Student = student,
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
                string uniqueFileName = ProcessUploadFile(model);
                
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

        [HttpGet]
        public ViewResult Edit(int id)
        {
            Student student = _studentRepository.GetStudent(id);
            if (student != null)
            {
                StudentEditViewModel studentEditView = new StudentEditViewModel
                {
                    Id = student.Id,
                    Name = student.Name,
                    Email = student.Email,
                    ClassName = student.ClassName,
                    ExistingPhotoPath = student.Photo
                };
                return View(studentEditView); 
            }
            throw new Exception();
        }

        [HttpPost]
        public IActionResult Edit(StudentEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Student student = _studentRepository.GetStudent(model.Id);
                student.Email = model.Email;
                student.Name = model.Name;
                student.ClassName = model.ClassName;
                if (model.Photo != null) 
                {
                    if (model.ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine(_hostEnvironment.WebRootPath, "images", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    student.Photo = ProcessUploadFile(model);
                }

                Student updateStudent = _studentRepository.Update(student);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        /// <summary>
        /// 将照片保存的指定的路径，并返回唯一的文件名
        /// </summary>
        /// <returns></returns>
        private string ProcessUploadFile(StudentCreateViewModel model)
        {
            string uniqueFileName = null;

            string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "images");
            uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
            string filePath1 = Path.Combine(uploadsFolder, uniqueFileName);
            // 需要手动释放。
            using (var fileStream = new FileStream(filePath1, FileMode.Create))
            {
                model.Photo.CopyTo(fileStream);
            }
            return uniqueFileName;
        }
    }
}
