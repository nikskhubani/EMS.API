using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace EMS.WEB.Pages;

public class EditEmployeeModel : BaseEMSModel
{
    private readonly ILogger<EditEmployeeModel> _logger;

    public EditEmployeeModel(IHttpClientFactory httpClientFactory, IConfiguration configuration, ILogger<EditEmployeeModel> logger)
        : base(httpClientFactory, configuration)
    {
        _logger = logger;
    }

    [BindProperty]
    public EmployeeVM Employee { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        try
        {
            var response = await GetAsync<APIResult>($"/Get/{id}");
            Employee = response.Employee;
            return Page();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading employee for editing");
            return NotFound();
        }
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        try
        {
            var updateEmployee = await PostAsync<EmployeeVM, APIResult>("/Update", Employee);
            return RedirectToPage("Index");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);
            return Page();
        }
    }
}
