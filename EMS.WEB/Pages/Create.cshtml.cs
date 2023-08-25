using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace EMS.WEB.Pages;

public class CreateEmployeeModel : BaseEMSModel
{
    private readonly ILogger<IndexModel> _logger;
   public CreateEmployeeModel(IHttpClientFactory httpClientFactory,IConfiguration configuration ,ILogger<IndexModel> logger): base(httpClientFactory,configuration)
    {
        _logger = logger;
    }

    [BindProperty]
    public EmployeeVM Employee { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        try
        {
            var createEmployee = await PostAsync<EmployeeVM,APIResult>("/Add", Employee);
            return RedirectToPage("Index");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);
            return Page();
        }
    }
}
