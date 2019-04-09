using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exercises.Models.Data;
using Exercises.Models.ViewModels;
namespace Exercises.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        //**************************************DISPLAY STUDENTS***************************************
        [HttpGet]
        public ActionResult List()
        {
            var model = StudentRepository.GetAll();
            return View(model);
        }
        //**************************************ADD STUDENTS***************************************
        [HttpGet]
        public ActionResult Add()
        {
            var viewModel = new StudentVM();
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Add(StudentVM studentVM)
        {
            //studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);
            if (ModelState.IsValid)
            {
                studentVM.Student.Courses = new List<Course>();
                foreach (var id in studentVM.SelectedCourseIds)
                    studentVM.Student.Courses.Add(CourseRepository.Get(id));
                studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);
                StudentRepository.Add(studentVM.Student);
                return RedirectToAction("List");
            }
            else
            {
                studentVM.SetCourseItems(CourseRepository.GetAll());
                studentVM.SetMajorItems(MajorRepository.GetAll());
                return View(studentVM);
            }
        }
        //**************************************DELETE STUDENTS***************************************
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Student student = StudentRepository.Get(id);
            return View(student);
        }
        [HttpPost]
        public ActionResult Delete(Student student)
        {
            StudentRepository.Delete(student.StudentId);
            return RedirectToAction("List");
        }
        //**************************************EDIT STUDENTS***************************************
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Student student = StudentRepository.Get(id);
            var viewModel = new StudentVM();
            viewModel.Student = student;
            viewModel.SetStateItems(StateRepository.GetAll());
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Edit(StudentVM studentVM)
        {        
            if (studentVM.Student.FirstName != null && studentVM.Student.LastName != null && (studentVM.Student.Major.MajorName!=null?0:studentVM.Student.Major.MajorId) != 0 && (studentVM.Student.GPA >= 0.0M && studentVM.Student.GPA <= 4.0M))
            {
                studentVM.Student.Courses = new List<Course>();
                foreach (var id in studentVM.SelectedCourseIds)
                    studentVM.Student.Courses.Add(CourseRepository.Get(id));
                studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);          
                StudentRepository.Edit(studentVM.Student);
                StudentRepository.SaveAddress(studentVM.Student.StudentId, studentVM.Student.Address);
                return RedirectToAction("List");
            }
            else
            {
                studentVM.SetCourseItems(CourseRepository.GetAll());
                studentVM.SetMajorItems(MajorRepository.GetAll());
                studentVM.SetStateItems(StateRepository.GetAll());
                return View(studentVM);
            }
        }
    }
}