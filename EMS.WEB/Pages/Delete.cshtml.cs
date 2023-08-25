using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace EMS.WEB.Pages;

public class DeleteEmployeeModel : BaseEMSModel
{
    private readonly ILogger<IndexModel> _logger;
   public DeleteEmployeeModel(IHttpClientFactory httpClientFactory,IConfiguration configuration ,ILogger<IndexModel> logger): base(httpClientFactory,configuration)
    {
        _logger = logger;
    }

   [BindProperty]
    public EmployeeVM Employee { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        try
        {
            var result = await GetAsync<APIResult>($"/Get/{id}");
            Employee = result.Employee;
            return Page();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading employee for deletion");
            return NotFound();
        }
    }

    public async Task<IActionResult> OnPostAsync()
    {
        try
        {
            await DeleteAsync($"/Delete/{Employee.Id}");
            return RedirectToPage("Index");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting employee");
            return Page();
        }
    }
}
