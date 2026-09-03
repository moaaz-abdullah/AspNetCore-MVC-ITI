using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models
{
    public class Employee
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int Salary { get; set; }

        public string JobTitle { get; set; }

        public string ImgURL { get; set; }

        public string Address { get; set; }

        [ForeignKey("Department")]
        public int DepartmentID { get; set; }

        public Department Department { get; set; }
    }
}
