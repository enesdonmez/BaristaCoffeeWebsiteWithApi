using BaristaCoffee.Dto.AboutDtos;
using BaristaCoffee.Dto.ContactDtos;
using BaristaCoffee.Dto.MenuDtos;
using BaristaCoffee.Web.Services.Interfaces;
using BaristaCoffee.Web.ViewModel;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

public class IndexModel : PageModel
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IAboutService _aboutService;
    private readonly IMenuService _menuService;
    private readonly IBaristaService _baristaService;
    private readonly ITestimonialService _testimonialService;
    private readonly IContactService _contactService;

    public IndexViewModel ViewModel = new IndexViewModel();

    public IndexModel(IHttpClientFactory httpClientFactory, IAboutService aboutService, IMenuService menuService, IBaristaService baristaService, ITestimonialService testimonialService, IContactService contactService)
    {
        _httpClientFactory = httpClientFactory;
        _aboutService = aboutService;
        _menuService = menuService;
        _baristaService = baristaService;
        _testimonialService = testimonialService;
        _contactService = contactService;
    }

    public async Task OnGetAsync()
    {
        try
        {
            var aboutTask =  _aboutService.GetAboutListAsync();
            var menuTask =  _menuService.GetAllMenuAsync();
            var baristaTask =  _baristaService.GetAllBaristaAsync();
            var testimonialTask =  _testimonialService.GetAllTestimonialsAsync();

            await Task.WhenAll(aboutTask, menuTask, baristaTask, testimonialTask);

            ViewModel.About = aboutTask.Result;
            ViewModel.Menu = menuTask.Result;
            ViewModel.Barista = baristaTask.Result;
            ViewModel.Testimonial = testimonialTask.Result;

        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, "Veri alýnamadý: " + ex.Message);
        }
    }

    public async Task OnPostAsync(CreateContactDto createContactDto)
    {
        await _contactService.CreateContact(createContactDto);
        if (ModelState.IsValid)
        {
            ModelState.AddModelError(string.Empty, "Mesajýnýz baþarýyla gönderildi.");
        }
    }

}