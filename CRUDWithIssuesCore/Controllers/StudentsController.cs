using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDWithIssuesCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDWithIssuesCore.Controllers
{
    public class StudentsController : Controller
    {
        private readonly SchoolContext context;

        public StudentsController(SchoolContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<Student> stu = StudentDb.GetStudents(context);
            return View(stu);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student stu)
        {
            if (ModelState.IsValid)
            {
                StudentDb.Add(stu, context);
                ViewData["Message"] = $"{stu.Name} was added!";
                return RedirectToAction(nameof(Index));
            }

            //Show web page with errors
            return View(stu);
        }

        public IActionResult Edit(int id)
        {
            //get the product by id
            Student stu = StudentDb.GetStudentId(context, id);

            //show it on web page
            return View(stu);
        }

        [HttpPost]
        public IActionResult Edit(Student stu)
        {
            if (ModelState.IsValid)
            {
                StudentDb.Update(context, stu);
                ViewData["Message"] = "Product Updated!";
                return RedirectToAction(nameof(Index));
            }
            //return view with errors
            return View(stu);
        }

        public IActionResult Delete(int id)
        {
            Student p = StudentDb.GetStudentId(context, id);

            return View(p);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            //Get Product from database
            Student p = StudentDb.GetStudentId(context, id);

            StudentDb.Delete(context, p);

            return RedirectToAction("Index");
        }
    }
}