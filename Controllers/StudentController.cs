using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApplication1.DataLayer;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{

    public class StudentController : Controller
    {

        private readonly ApplicationDbContext context;

        public StudentController(ApplicationDbContext _context)
        {
            context = _context;
        }

        public IActionResult Index()
        {
          var stu =   context.Students.ToList();
            if (stu!=null)
            {
                return View(stu);
            }
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            Student S = new Student()
            {
                Name= student.Name,
                Family= student.Family,
                Lesson= student.Lesson,
                Grade = student.Grade,
            };

            context.Students.Add(S);
         context.SaveChanges();
            return View();
        }


        public IActionResult Edit(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }

            var student =  context.Students.Find(ID);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

         [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit( Student student)
        {
 

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(student);
                 context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

 public IActionResult Delete(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }

            var student =  context.Students.Find(ID);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

         [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete( Student student)
        {
           

            if (ModelState.IsValid)
            {

                try
                {
                    context.Remove(student);
                 context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}