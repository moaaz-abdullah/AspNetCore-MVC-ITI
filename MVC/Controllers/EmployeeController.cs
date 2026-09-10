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
            List<string> branches = new List<string>();
            branches.Add("Branch 1");
            branches.Add("Branch 2");

            ViewData["Message"] = "Employee Message";
            ViewData["Branches"] = branches;

            ViewBag.Temp = 50;
            ViewBag.Color = "Red";

            Employee employeeModel = context.Employee
                .FirstOrDefault(e => e.ID == ID);

            return View("Details", employeeModel);
        }

        public IActionResult DetailsVM(int ID)
        {
            List<string> branches = new List<string>();
            branches.Add("Branch 1");
            branches.Add("Branch 2");

            Employee employeeModel = context.Employee
                .Include(e => e.Department)
                .FirstOrDefault(e => e.ID == ID);

            if (employeeModel == null)
            {
                return NotFound();
            }

            EmployeeDebtColorTempVM employeeViewModel = new EmployeeDebtColorTempVM();

            employeeViewModel.EmpName = employeeModel.Name;
            employeeViewModel.DeptName = employeeModel.Department.Name;
            employeeViewModel.Temp = 12;
            employeeViewModel.Message = "Message";
            employeeViewModel.Color = "Red";
            employeeViewModel.Branches = branches;

            return View("DetailsVM", employeeViewModel);
        }

        public IActionResult Index()
        {
            List<Employee> employees = context.Employee
                .Include(e => e.Department)
                .ToList();

            return View("Index", employees);
        }

        // GET: Employee/Edit/5
        [HttpGet]
        public IActionResult Edit(int ID)
        {
            Employee employeeModel = context.Employee
                .FirstOrDefault(e => e.ID == ID);

            if (employeeModel == null)
            {
                return NotFound();
            }

            return View("Edit", employeeModel);
        }

        // POST: Employee/Update
        [HttpPost]
        public IActionResult Update(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", employee);
            }

            Employee existingEmployee = context.Employee
                .FirstOrDefault(e => e.ID == employee.ID);

            if (existingEmployee == null)
            {
                return NotFound();
            }

            existingEmployee.Name = employee.Name;
            existingEmployee.Salary = employee.Salary;
            existingEmployee.ImgURL = employee.ImgURL;
            existingEmployee.JobTitle = employee.JobTitle;

            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}