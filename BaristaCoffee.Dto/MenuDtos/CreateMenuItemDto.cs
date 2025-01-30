namespace BaristaCoffee.Dto.MenuDtos
{
    public class CreateMenuItemDto
    {
        public string ProductName { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }
    }
}
