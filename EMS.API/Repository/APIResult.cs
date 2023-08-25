namespace EMS.API.Repository
{
    public class APIResult
    {
        public APIResult() { }

        public APIResult(Employee? employee, List<Employee>? employees, APIResultType status, string errorMessage)
        {
            this.Employee = employee;
            this.Employees = employees;
            this.Status = status.ToString();
            this.ErrorMessage = ErrorMessage;
        }
        public Employee? Employee { get; set; }
        public List<Employee>? Employees { get; set; }
        public string Status { get; set; } = string.Empty;
        public string ErrorMessage { get; set; } = string.Empty;
    }

    public enum APIResultType
    {
        OK,
        NotFound,
        InternalServerError
    }
}
