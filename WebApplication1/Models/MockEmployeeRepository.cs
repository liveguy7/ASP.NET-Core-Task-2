
namespace WebApplication1.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee() { Id= 1, Name = "Pan", Department= Dept.HR, Email="pan@na.com"},
                new Employee() { Id= 2, Name = "Mam", Department= Dept.HR, Email="mam@na.com"},
                new Employee() { Id= 3, Name = "Tyu", Department= Dept.Payroll, Email="tyu@na.com"},
                new Employee() { Id= 4, Name = "Opi", Department= Dept.HR, Email="opi@na.com"},

            };
        }

        public Employee GetEmployee(int id)
        {
            return _employeeList.FirstOrDefault(e =>
                e.Id == id);
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }

        public Employee Add(Employee employee)
        {
            employee.Id = _employeeList.Max(e =>
                e.Id) + 1;
            _employeeList.Add(employee);

            return employee;

        }
        
        public Employee Delete(int id)
        {
            Employee employee = _employeeList.FirstOrDefault(e =>
                e.Id == id);
            if(employee != null)
            {
                _employeeList.Remove(employee);
            }
            return employee;
        }

        public Employee Update(Employee employeeChanges)
        {
            Employee employee = _employeeList.FirstOrDefault(e =>
                 e.Id == employeeChanges.Id);
            if(employee == null)
            {
                employee.Name = employeeChanges.Name;
                employee.Email = employeeChanges.Email;
                employee.Department = employeeChanges.Department;
            }
            return employee;
        }

    }
}











