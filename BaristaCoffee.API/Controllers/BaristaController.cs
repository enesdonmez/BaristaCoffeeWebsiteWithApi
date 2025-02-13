using BaristaCoffee.API.Repositories.BaristaRepositories;
using BaristaCoffee.Dto.BaristaDtos;
using Microsoft.AspNetCore.Mvc;

namespace BaristaCoffee.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaristaController : ControllerBase
    {
        private readonly IBaristaRepository _baristaRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public BaristaController(IBaristaRepository baristaRepository, IWebHostEnvironment webHostEnvironment)
        {
            _baristaRepository = baristaRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("GetAllBarista")]
        public async Task<IActionResult> GetAllBarista()
        {
            var barista = await _baristaRepository.GetAllBaristaAsync();
            return Ok(barista);
        }

        [HttpPost("CreateBarista")]
        public async Task<IActionResult> CreateBarista([FromForm] CreateBaristaDto createBaristaDto, [FromForm] IFormFile image)
        {
            try
            {
                if (image != null && image.Length > 0)
                {
                    // wwwroot klasörü altındaki images klasörünün tam yolunu elde ediyoruz
                    var imagesFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");

                    // Klasör yoksa oluştur
                    if (!Directory.Exists(imagesFolder))
                    {
                        Directory.CreateDirectory(imagesFolder);
                    }

                    var fileName = Path.GetFileName(image.FileName);

                    var filePath = Path.Combine(imagesFolder, fileName);

                    // Dosyayı kaydet
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }

                    // İsteğe bağlı: Kaydedilen dosya adını veya yolunu DTO üzerinden veritabanına ekleyebilirsiniz.
                }

                await _baristaRepository.CreateBaristaAsync(createBaristaDto);

                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "Barista oluşturulurken hata oluştu.", Details = ex.Message });
            }
        }

        [HttpDelete("DeleteBarista/{id}")]
        public async Task<IActionResult> DeleteBarista(int id)
        {
            await _baristaRepository.DeleteBaristaAsync(id);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPut("UpdateBarista")]
        public async Task<IActionResult> UpdateBarista(UpdateBaristaDto updateBaristaDto)
        {
            await _baristaRepository.UpdateBaristaAsync(updateBaristaDto);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpGet("GetByIdBarista/{id}")]
        public async Task<IActionResult> GetByIdBarista(int id)
        {
            var barista = await _baristaRepository.GetBaristaByIdAsync(id);
            return Ok(barista);
        }
    }
}
