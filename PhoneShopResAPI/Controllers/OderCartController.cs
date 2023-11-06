using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneShopResAPI.Models;
using System.ComponentModel;

namespace PhoneShopResAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OderCartController : ControllerBase
    {
        private static PhoneStoreContext _phoneStoreContext = new PhoneStoreContext();

        private readonly ILogger<OderCartController> _logger;

        public OderCartController(ILogger<OderCartController> logger)
        {
            _logger = logger;
        }

        public static List<OrderDetail> OrderDetails()
        {
            try
            {
                List<OrderDetail> list = new List<OrderDetail>();
                list = _phoneStoreContext.OrderDetails.ToList();
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet(Name = "GetOrderDetail")]
        public IEnumerable<OrderDetail> Get()
        {
            List<OrderDetail> list = OrderDetails();
            return list.AsEnumerable<OrderDetail>();
        }
    }
}
