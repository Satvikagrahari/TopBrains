using EmployeeManagmentApiServices.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace EmployeeManagmentApiServices.Controllers
{

    //[Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;


        public EmployeeController(IEmployeeRepository
    _employeeRepository)
        {
            this._employeeRepository = _employeeRepository;
        }

        [HttpGet]
        [Route("api/Employees/Get")]//Most Important
        public async Task<IEnumerable<Employee>> Get()
        {
            return await _employeeRepository.GetAllEmployees();
        }




        [HttpGet]
        [Route("api/Employees/Details/{id}")]
        public async Task<Employee> Details(int? id)
        {
            var result = await _employeeRepository.GetEmployeeById(id);
            return result;
        }

        [HttpPost]
        [Route("api/Employees/Create")]
        public async Task CreateAsync([FromBody] Employee employee)
        {
            if (ModelState.IsValid)
            {
                await _employeeRepository.Add(employee);
            }
        }


        [HttpPut]
        [Route("api/Employees/Edit/{id}")]
        public async Task EditeAsync(int id, Employee employee)
        {
            if (ModelState.IsValid)
            {
                await _employeeRepository.Update(id, employee);

            }
        }

        // DELETE: api/employee/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _employeeRepository.Delete(id);

            return Ok();
        }



    }
}

