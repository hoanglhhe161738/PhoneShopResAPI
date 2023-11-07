namespace PhoneShopResAPI.ModelsRow
{
    public class Account
    {
        public Account(string username, string password, string? email, string? full_name)
        {
            Username = username;
            Password = password;
            Email = email;
            this.full_name = full_name;
        }

        public Account()
        {
        }

        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Email { get; set; }
        public string? full_name { get; set; }
    }
}
