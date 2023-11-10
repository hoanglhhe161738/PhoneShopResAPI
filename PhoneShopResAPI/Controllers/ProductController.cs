using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneShopResAPI.DTO;
using PhoneShopResAPI.Models;

namespace PhoneShopResAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static PhoneStoreContext _phoneStoreContext = new PhoneStoreContext();

        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        public static List<Phone> GetProductt()
        {
            try
            {
                List<Phone> list = new List<Phone>();
                list = _phoneStoreContext.Phones.ToList();
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet(Name = "GetProduct")]
        public IEnumerable<Phone> Get()
        {
            List<Phone> list = GetProductt();
            return list.AsEnumerable<Phone>();
        }

        [HttpGet("getPhone")]
        public Phone? GetPhone(int phoneId)
        {
            Phone? phone = _phoneStoreContext.Phones.Where(p => p.PhoneId == phoneId).FirstOrDefault();
            return phone;
        }
    }
}
