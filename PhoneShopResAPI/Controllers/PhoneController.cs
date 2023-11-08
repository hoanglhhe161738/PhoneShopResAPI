using Microsoft.AspNetCore.Mvc;
using PhoneShopResAPI.Models;

namespace PhoneShopResAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneController : Controller
    {

        private static PhoneStoreContext _phoneStoreContext = new PhoneStoreContext();

        private readonly ILogger<PhoneController> _logger;

        public PhoneController(ILogger<PhoneController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetPhone")]
        public List<Phone> GetPhones()
        {
            List<Phone> result = new List<Phone>();
            result = _phoneStoreContext.Phones.ToList();
            return result;
        }
    }
}
