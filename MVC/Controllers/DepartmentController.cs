using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class DepartmentController : Controller
    {
        ITIContext context = new ITIContext();

        public IActionResult Index()
        {
            List<Department> departments = context.Department.ToList();
            return View("Index", departments);
        }

        public IActionResult Create()
        {
            return View("Create");
        }

        public IActionResult Save(Department department)
        {
            if (department.Name != null && department.ManagerName != null)
            {
                context.Department.Add(department);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Create", department);
        }
    }
}
