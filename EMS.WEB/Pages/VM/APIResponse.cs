 public class APIResult
    {
        public EmployeeVM? Employee { get; set; }
        public List<EmployeeVM>? Employees { get; set; }
        public string? Status { get; set; } 
        public string? ErrorMessage { get; set; }
    }
