using Microsoft.AspNetCore.Mvc;

namespace EMS.WEB.Pages;

public class IndexModel : BaseEMSModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IHttpClientFactory _httpClientFactory;

  [BindProperty(SupportsGet = true)]
public string SearchTerm { get; set; }

    public IndexModel(IHttpClientFactory httpClientFactory,IConfiguration configuration ,ILogger<IndexModel> logger): base(httpClientFactory,configuration)
    {
        _logger = logger;
        _httpClientFactory = httpClientFactory;
    }

    public List<EmployeeVM>? Employees { get; set; }
    public int TotalItems;
    public async Task OnGetAsync()
{
    try
    {
        var url =  "/GetAll";
        if (!string.IsNullOrWhiteSpace(SearchTerm))
        {
            url = $"/Search/{SearchTerm}";
        }
            var getAllEmployees = await GetAsync<APIResult>(url);
            Employees = getAllEmployees.Employees ?? new List<EmployeeVM>();
        TotalItems = Employees.Count; // Set the total count for paging
    }
    catch (Exception ex)
    {
        // Handle error
    }
}

}
