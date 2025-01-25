namespace BaristaCoffee.Dto.ContactDtos
{
    public class CreateContactDto
    {

        public string Name { get; set; } = default!;

        public string Email { get; set; } = default!;

        public string Message { get; set; } = default!;
    }
}
