using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneShopResAPI.DTO;
using PhoneShopResAPI.Models;
using System.ComponentModel;
using System.Linq;

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

        public static List<OrderDetailsDTO> OrderDetails(List<Order> orders)
        {
            List<OrderDetail> list = new List<OrderDetail>();
            List<OrderDetailsDTO> list1 = new List<OrderDetailsDTO>();
            try
            {
                
               
                list = _phoneStoreContext.OrderDetails.ToList();
                foreach (var order in orders)
                {
                    foreach (var item in list)
                    {
                        if(item.OrderId == order.OrderId)
                        {
                            OrderDetailsDTO orderDetailsDTO = new OrderDetailsDTO();
                            orderDetailsDTO.OrderId = item.OrderId;
                            orderDetailsDTO.PhoneId = item.PhoneId;
                            orderDetailsDTO.Quantity = item.Quantity;
                            list1.Add(orderDetailsDTO);
                        }
                    }
                }
                return list1;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet(Name = "GetOrder")]
        public IEnumerable<OrderDetailsDTO> Get(String username)
        {
            List<Order> orders = _phoneStoreContext.Orders.Where(o => o.Username == username).ToList();
            List<OrderDetailsDTO> list = OrderDetails(orders);
            return list.AsEnumerable<OrderDetailsDTO>();
        }

    }
}
