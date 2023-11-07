namespace PhoneShopResAPI.DTO
{
    public class AccountCreateDto
    {

        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Email { get; set; }
        public string? full_name { get; set; }
    }
}
