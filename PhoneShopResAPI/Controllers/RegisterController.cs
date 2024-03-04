using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneShopResAPI.DTO;
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
        public async Task<IActionResult> Create(AccountCreateDto accountDto)
        {
            var account = new Account
            {
                Username = accountDto.Username,
                Password = accountDto.Password,
                Email = accountDto.Email,
                full_name = accountDto.full_name
            };
            _phoneStoreContext.Accounts.Add(account);
            await _phoneStoreContext.SaveChangesAsync();
            return CreatedAtAction(nameof(Create), new { id = account.Username }, account);
        }
    }
}
