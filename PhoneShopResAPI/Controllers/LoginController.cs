using Microsoft.AspNetCore.Mvc;
using PhoneShopResAPI.Models;

namespace PhoneShopResAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private static PhoneStoreContext _phoneStoreContext = new PhoneStoreContext();

        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "Login")]
        public Account? login(Account account)
        {
            Account? acc = _phoneStoreContext.Accounts
                .Where(a => a == account)
                .FirstOrDefault();

            return acc;
        }
    }
}
