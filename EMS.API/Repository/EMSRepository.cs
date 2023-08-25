using EMS.API.Data;
using EMS.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Repository
{
    public class EMSRepository : IEMSRepository
    {
        /// <summary>
        /// Add employee to database.
        /// </summary>
        /// <param name="employee">Employee object to add.</param>
        /// <returns></returns>
        public async Task<APIResult> AddEmployeeAsync(Employee employee)
        {
            try
            {
                using (DataContext context = new DataContext())
                {
                    var employeeResult = context.Employees.Add(employee);
                    await context.SaveChangesAsync();
                    return new APIResult(employeeResult.Entity, null, APIResultType.OK, string.Empty);

                }
            }
            catch (Exception ex)
            {
                return new APIResult(null, null, APIResultType.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Delete an employee from database who's ID is given.
        /// </summary>
        /// <param name="employeeId">ID of employee to be deleted.</param>
        /// <returns></returns>
        public async Task<APIResult> DeleteEmployeeAsync(int employeeId)
        {
            try
            {
                using (DataContext context = new DataContext())
                {
                    var employeeResult = context.Employees.Where((e) => e.Id == employeeId).FirstOrDefault();
                    if (employeeResult != null)
                    {
                        context.Employees.Remove(employeeResult);
                        await context.SaveChangesAsync();
                        return new APIResult(null, null, APIResultType.OK, string.Empty);
                    }
                    else
                    {
                        return new APIResult(null, null, APIResultType.NotFound, string.Empty);
                    }

                }
            }
            catch (Exception ex)
            {
                return new APIResult(null, null, APIResultType.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// gets an employee from database who's ID is given.
        /// </summary>
        /// <param name="employeeId">ID of employee to be returned.</param>
        /// <returns></returns>
        public async Task<APIResult> GetEmployeeAsync(int employeeId)
        {
            try
            {
                using (DataContext context = new DataContext())
                {
                    var employeeResult = context.Employees.Where((e) => e.Id == employeeId).FirstOrDefault();
                    if (employeeResult != null)
                    {
                        return new APIResult(employeeResult, null, APIResultType.OK, string.Empty);
                    }
                    else
                    {
                        return new APIResult(null, null, APIResultType.NotFound, string.Empty);
                    }

                }
            }
            catch (Exception ex)
            {
                return new APIResult(null, null, APIResultType.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// gets all employees.
        /// </summary>
        /// <returns></returns>
        public async Task<APIResult> GetEmployeesAsync()
        {
            try
            {
                using (DataContext context = new DataContext())
                {
                    var employeeResult = await context.Employees.ToListAsync();
                    if (employeeResult.Count > 0)
                    {
                        return new APIResult(null, employeeResult, APIResultType.OK, string.Empty);
                    }
                    else
                    {
                        return new APIResult(null, null, APIResultType.NotFound, string.Empty);
                    }

                }
            }
            catch (Exception ex)
            {
                return new APIResult(null, null, APIResultType.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Search an employee with given term.
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <returns></returns>
        public APIResult SearchEmployeeAsync(string searchTerm)
        {
            try
            {
                using (DataContext context = new DataContext())
                {
                    var searchLower = searchTerm.ToLower();

                    var employeeResult = context.Employees.Where(e =>
                        e.FirstName.ToLower().Contains(searchLower) ||
                        e.MiddleName.ToLower().Contains(searchLower) ||
                        e.LastName.ToLower().Contains(searchLower) ||
                        e.Address.ToLower().Contains(searchLower) ||
                        e.Phone.ToLower().Contains(searchLower) ||
                        e.Department.ToLower().Contains(searchLower)
                        ).ToList();

                    if (employeeResult.Count > 0)
                    {
                        return new APIResult(null, employeeResult, APIResultType.OK, string.Empty);
                    }
                    else
                    {
                        return new APIResult(null, null, APIResultType.NotFound, string.Empty);
                    }

                }
            }
            catch (Exception ex)
            {
                return new APIResult(null, null, APIResultType.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Update an employee whose ID is matched.
        /// </summary>
        /// <param name="employee">Employee object to be updated.</param>
        /// <returns></returns>
        public async Task<APIResult> UpdateEmployeeAsync(Employee employee)
        {
            try
            {
                using (DataContext context = new DataContext())
                {
                    var employeeResult = context.Employees.Where((e) => e.Id == employee.Id).FirstOrDefault();
                    if (employeeResult != null)
                    {
                        employeeResult.FirstName = employee.FirstName;
                        employeeResult.MiddleName = employee.MiddleName;
                        employeeResult.LastName = employee.LastName;
                        employeeResult.Department = employee.Department;
                        employeeResult.Address = employee.Address;
                        employeeResult.Phone = employee.Phone;
                        employeeResult.Email = employee.Email;
                        await context.SaveChangesAsync();

                        return new APIResult(employeeResult, null, APIResultType.OK, string.Empty);
                    }
                    else
                    {
                        return new APIResult(null, null, APIResultType.NotFound, string.Empty);
                    }

                }
            }
            catch (Exception ex)
            {
                return new APIResult(null, null, APIResultType.InternalServerError, ex.Message);
            }
        }
    }
}
