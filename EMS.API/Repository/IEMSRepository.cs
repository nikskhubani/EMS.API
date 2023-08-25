namespace EMS.API.Repository
{
    public interface IEMSRepository
    {
        public Task<APIResult> GetEmployeesAsync();
        public Task<APIResult> AddEmployeeAsync(Employee employee);
        public Task<APIResult> UpdateEmployeeAsync(Employee employee);
        public Task<APIResult> DeleteEmployeeAsync(int employeeId);
        public Task<APIResult> GetEmployeeAsync(int employeeId);
        public APIResult SearchEmployeeAsync(string searchTerm);

    }
}
