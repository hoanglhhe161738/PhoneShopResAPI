using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneShopResAPI.Models;

namespace PhoneShopResAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private static PhoneStoreContext _phoneStoreContext = new PhoneStoreContext();

        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        public static List<Account> GetAccount()
        {
            try
            {
                List<Account> list = new List<Account>();
                list = _phoneStoreContext.Accounts.ToList();
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet(Name = "GetAccount")]
        public IEnumerable<Account> Get()
        {
            List<Account> list = GetAccount();
            return list.AsEnumerable<Account>();
        }
    }
}
