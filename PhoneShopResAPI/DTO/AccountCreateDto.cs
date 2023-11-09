namespace PhoneShopResAPI.DTO
{
    public class AccountCreateDto
    {

        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Email { get; set; }
        public string? full_name { get; set; }

        public AccountCreateDto(string username, string password, string? email, string? full_name)
        {
            Username = username;
            Password = password;
            Email = email;
            this.full_name = full_name;
        }

        public AccountCreateDto() { }
    }
}
