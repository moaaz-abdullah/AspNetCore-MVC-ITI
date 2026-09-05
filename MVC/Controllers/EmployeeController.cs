using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class EmployeeController : Controller
    {
        ITIContext context = new ITIContext();

        public IActionResult Details(int ID)
        {
            string msg = "Employee Message";
            int temp = 50;

            List<String> branches = new List<String>();
            branches.Add("Branch 1");
            branches.Add("Branch 2");

            ViewData["Message"] = msg;
            ViewData["Temp"] = temp;
            ViewData["Branches"] = branches;

            Employee employeeModel = context.Employee.FirstOrDefault(e => e.ID == ID);
            return View("Details", employeeModel);
        }
    }
}
