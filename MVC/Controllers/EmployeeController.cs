using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class EmployeeController : Controller
    {
        ITIContext context = new ITIContext();

        public EmployeeController()
        {

        }

        public IActionResult Details(int ID)
        {
            List<String> branches = new List<String>();
            branches.Add("Branch 1");
            branches.Add("Branch 2");

            ViewData["Message"] = "Employee Message";
            ViewData["Branches"] = branches;

            ViewBag.Temp = 50;
            ViewBag.Color = "Red";

            Employee employeeModel = context.Employee.FirstOrDefault(e => e.ID == ID);
            return View("Details", employeeModel);
        }
    }
}
