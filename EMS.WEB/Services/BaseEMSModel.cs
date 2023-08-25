using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EMS.WEB.Pages;

public class BaseEMSModel : PageModel
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;
    public BaseEMSModel(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
    }
    protected async Task<T> GetAsync<T>(string url)
    {
        var httpClient = _httpClientFactory.CreateClient("EMS");
        var response = await httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<T>();
    }

    protected async Task<TResponse> PostAsync<TRequest, TResponse>(string url, TRequest data)
    {
        var httpClient = _httpClientFactory.CreateClient("EMS");
        var response = await httpClient.PostAsJsonAsync(url, data);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<TResponse>();
    }

    protected async Task DeleteAsync(string url)
    {
        var httpClient = _httpClientFactory.CreateClient("EMS");
        var response = await httpClient.DeleteAsync(url);
        response.EnsureSuccessStatusCode();
    }
}