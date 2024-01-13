using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;
        public SQLEmployeeRepository(AppDbContext context)
        {
            this._context = context;
        }
        public Employee GetEmployee(int id)
        {
           return _context.employees.Find(id);

        }
        public IEnumerable<Employee> GetAllEmployees()
        {
            return _context.employees;

        }
        public Employee Add(Employee employee)
        {
            _context.employees.Add(employee);
            _context.SaveChanges();

            return employee;

        }
        public Employee Update(Employee employeeChanges)
        {
            var employee = _context.employees.Attach(employeeChanges);
            employee.State = EntityState.Modified;
            _context.SaveChanges();

            return employeeChanges;
        }
        public Employee Delete(int id)
        {
            Employee employee = _context.employees.Find(id);
            if(employee != null)
            {
                _context.employees.Remove(employee);
                _context.SaveChanges();
            }
            return employee;

        }

    }
}









