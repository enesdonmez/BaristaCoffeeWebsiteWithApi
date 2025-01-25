using BaristaCoffee.Dto.AboutDtos;
using BaristaCoffee.Dto.MenuDtos;
using BaristaCoffee.Web.ViewModel;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

public class IndexModel : PageModel
{
    private readonly IHttpClientFactory _httpClientFactory;

    public IndexViewModel ViewModel { get; set; } = new IndexViewModel(); 

    public IndexModel(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task OnGetAsync()
    {
        try
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessageAbout = await client.GetAsync("https://localhost:7066/api/About/GetAbout");

            if (responseMessageAbout.IsSuccessStatusCode)
            {
                var jsonDataAbout = await responseMessageAbout.Content.ReadAsStringAsync();
                ViewModel.About = JsonConvert.DeserializeObject<List<GetAboutDto>>(jsonDataAbout);
            }

            var responseMessageMenu = await client.GetAsync("https://localhost:7066/api/Menu/GetAllMenu");
            if (responseMessageMenu.IsSuccessStatusCode)
            {
                var jsonDataMenu = await responseMessageAbout.Content.ReadAsStringAsync();
                ViewModel.Menu = JsonConvert.DeserializeObject<List<GetAllMenuDto>>(jsonDataMenu);
            }
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, "Veri alýnamadý: " + ex.Message);
        }
    }
}