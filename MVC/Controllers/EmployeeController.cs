using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Models;
using MVC.ViewModel;

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

        public IActionResult DetailsVM(int ID)
        {
            List<String> branches = new List<String>();
            branches.Add("Branch 1");
            branches.Add("Branch 2");

            Employee employeeModel = context.Employee.Include(e => e.Department).FirstOrDefault(e => e.ID == ID);

            EmployeeDebtColorTempVM employeeViewModel = new EmployeeDebtColorTempVM();

            employeeViewModel.EmpName = employeeModel.Name;
            employeeViewModel.DeptName = employeeModel.Department.Name;
            employeeViewModel.Temp = 12;
            employeeViewModel.Message = "Message";
            employeeViewModel.Color = "Red";
            employeeViewModel.Branches = branches;

            return View("DetailsVM", employeeViewModel);
        }
    }
}
