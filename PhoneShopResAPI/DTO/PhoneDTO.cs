namespace PhoneShopResAPI.DTO
{
    public class PhoneDTO
    {
        public int PhoneId { get; set; }
        public string ModelName { get; set; } = null!;
        public string? Manufacturer { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }
        public bool? InStock { get; set; }
        public string? ImageUrl { get; set; }
    }
}
