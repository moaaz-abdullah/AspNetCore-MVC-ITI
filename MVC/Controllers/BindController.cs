using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class BindController : Controller
    {
        // GET: /Bind/TestPrimitive?name=John&age=30&ID=123&color=red&color=blue
        public IActionResult TestPrimitive(string name, int age, int ID, string[] color)
        {
            return Content($"{name} \t {age} \t {ID} \t {string.Join(", ", color)}");
        }

        // GET: /Bind/TestDic?name=John&age=30&ID=123
        public IActionResult TestDic(Dictionary<string, string> dic)
        {
            return Content($"{dic["name"]} \t {dic["age"]} \t {dic["ID"]}");
        }

        // GET: /Bind/TestObj?ID=1&Name=HR&ManagerName=Alice
        public IActionResult TestObj(Department department)
        {
            return Content($"{department.ID} \t {department.Name} \t {department.ManagerName}");
        }
    }
}
