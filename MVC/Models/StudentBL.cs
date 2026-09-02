namespace MVC.Models
{
    public class StudentBL
    {
        private List<Student> students;

        public StudentBL()
        {
            students = new List<Student>();
            students.Add(new Student() { Id = 1, Name = "Moaaz", ImageUrl = "batman.webp" });
            students.Add(new Student() { Id = 2, Name = "Fox", ImageUrl = "superman.webp" });
        }

        public List<Student> GetAll()
        {
            return students;
        }

        public Student GetById(int id)
        {
            return students.FirstOrDefault(student => student.Id == id);
        }

    }
}
