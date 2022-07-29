using Microsoft.AspNetCore.Mvc;
using PruebaMeta.Models;
using System.Diagnostics;
using PruebaMeta.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace PruebaMeta.Controllers
{
    public class HomeController : Controller
    {
        private readonly collageContext _DBContext;

        public HomeController(collageContext context)
        {
            _DBContext = context;
        }

        public IActionResult Index()
        {
            List<Student> list = _DBContext.Students.ToList();
            return View(list);
            
        }

        [HttpGet]
        public IActionResult Student_detail(int id)
        {
            StudentVM oStudentVM = new StudentVM()
            {
                oStudent = new Student()
            };
            if(id != 0)
            {
                oStudentVM.oStudent = _DBContext.Students.Find(id);
            }
            return View(oStudentVM);
        }

        [HttpPost]
        public IActionResult Student_detail(StudentVM oStudentVM)
        {
            if(oStudentVM.oStudent.Id == 0)
            {
                if (ModelState.IsValid)
                {
                    _DBContext.Students.Add(oStudentVM.oStudent);
                }
                
            }
            else
            {
                if (ModelState.IsValid)
                {
                    _DBContext.Students.Update(oStudentVM.oStudent);
                }
                
            }
            _DBContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Student oStudent = _DBContext.Students.Where(e => e.Id == id).FirstOrDefault();
            
            return View(oStudent);
        }
        [HttpPost]
        public IActionResult Delete(StudentVM oStudentVM)
        {
            if (oStudentVM.oStudent.Id != 0)
            {
                _DBContext.Students.Update(oStudentVM.oStudent);
            }

            _DBContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}