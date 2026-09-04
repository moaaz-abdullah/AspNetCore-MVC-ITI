using Microsoft.EntityFrameworkCore;

namespace MVC.Models
{
    public class ITIContext : DbContext
    {
        // dbms ? 
        // server ?
        // db name ?
        // login ?

        public DbSet<Employee> Employee { get; set; }

        public DbSet<Department> Department { get; set; }

        public ITIContext() : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=.;" +
                "Initial Catalog=MVC_D4;" +
                "Integrated Security=True;" +
                "Encrypt=False;" +
                "Trust Server Certificate=True");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
