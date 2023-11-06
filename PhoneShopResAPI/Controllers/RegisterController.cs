using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneShopResAPI.Models;

namespace PhoneShopResAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {

        private static PhoneStoreContext _phoneStoreContext = new PhoneStoreContext();

        private readonly ILogger<RegisterController> _logger;

        public RegisterController(ILogger<RegisterController> logger)
        {
            _logger = logger;
        }

       
        

        [HttpPost]
        public async Task<IActionResult> Create(Account account)
        {
            
            _phoneStoreContext.Accounts.Add(account);
            await _phoneStoreContext.SaveChangesAsync();
            return CreatedAtAction("CreateAccount", new { id = account.Username }, account);

        }
    }
}
