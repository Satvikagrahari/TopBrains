


using Microsoft.EntityFrameworkCore;

namespace EmployeeManagmentApiServices.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext? _employeeDbContext;

        public EmployeeRepository()
        {

        }
        public EmployeeRepository(EmployeeDbContext _employeeDbContext)
        {
            this._employeeDbContext = _employeeDbContext;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            try
            {
                var employee = await _employeeDbContext.Employees.ToListAsync();
                return employee;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Employee> GetEmployeeById(int? id)
        {
            try
            {
                Employee employee = await _employeeDbContext.Employees.FindAsync(id);
                if(employee == null)
                {
                    return null;
                }
                return employee;
            }
            catch
            {
                throw;
            }
        }

        public async Task Add(Employee employee)
        {
            _employeeDbContext.Employees.Add(employee);
            try
            {
              _employeeDbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public async Task Update(int id, Employee employee)
        {
            try
            {
                var Emp = _employeeDbContext.Employees.Find(id);
                if(Emp!=null)
                {
                    Emp.Name = employee.Name;
                    Emp.Address = employee.Address;
                    Emp.Gender = employee.Gender;
                    Emp.Company = employee.Company;
                    Emp.Designation = employee.Designation;
                    _employeeDbContext.SaveChanges();
                }
            }
            catch
            {
                throw;
            }
        }

        public  async Task Delete(int id)
        {
            try{
                Employee employee= await _employeeDbContext.Employees.FindAsync(id);
                _employeeDbContext.Employees.Remove(employee);
                _employeeDbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        
    }
}
