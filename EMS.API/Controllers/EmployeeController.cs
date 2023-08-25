using EMS.API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers
{
    public class EmployeeController : ControllerBase
    {
        readonly IEMSRepository _emsRepository;
        public EmployeeController(IEMSRepository emsRepository)
        {
            this._emsRepository = emsRepository;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<APIResult>> GetAllAsync()
        {
            try
            {
                var allEmployees = await _emsRepository.GetEmployeesAsync();
                return Ok(allEmployees);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Get/{employeeId}")]
        public async Task<ActionResult<APIResult>> GetAsync(int employeeId)
        {
            try
            {
                var employee = await _emsRepository.GetEmployeeAsync(employeeId);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("Delete/{employeeId}")]
        public async Task<ActionResult<APIResult>> DeleteAsync(int employeeId)
        {
            try
            {
                var result = await _emsRepository.DeleteEmployeeAsync(employeeId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult<APIResult>> AddAsync([FromBody] Employee employee)
        {
            try
            {
                var result = await _emsRepository.AddEmployeeAsync(employee);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Update")]
        public async Task<ActionResult<APIResult>> UpdateAsync([FromBody] Employee employee)
        {
            try
            {
                var result = await _emsRepository.UpdateEmployeeAsync(employee);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Search/{searchTerm}")]
        public ActionResult<APIResult> Search(string searchTerm)
        {
            try
            {
                var result = _emsRepository.SearchEmployeeAsync(searchTerm);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
