using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult ShowAll()
        {
            StudentBL studentBL = new StudentBL();
            List<Student> studentsLM = studentBL.GetAll();
            return View("ShowAll", studentsLM);
        }

        public IActionResult ShowById(int id)
        {
            StudentBL studentBL = new StudentBL();
            Student studentLM = studentBL.GetById(id);
            return View("ShowById", studentLM);
        }
    }
}
