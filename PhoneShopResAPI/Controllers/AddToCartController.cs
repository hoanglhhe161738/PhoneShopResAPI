using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneShopResAPI.DTO;
using PhoneShopResAPI.Models;
using PhoneShopResAPI.ModelsRow;

namespace PhoneShopResAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddToCartController : ControllerBase
    {
        private static PhoneStoreContext _phoneStoreContext = new PhoneStoreContext();

        private readonly ILogger<AddToCartController> _logger;

        public AddToCartController(ILogger<AddToCartController> logger)
        {
            _logger = logger;
        }   

        public static bool addOrder(string username)
        {
            try
            {
                Order order = new Order();
                order.Username = username;
                order.OrderDate = DateTime.Now;
                _phoneStoreContext.Orders.Add(order);
                return true;
            }catch (Exception ex)
            {
                return false;
            }
            
        }

        [HttpPost(Name = "Addtocart")]
        public Task<bool> addtocart(string username, int phoneid, int quantity)
        {
            Phone p = new Phone();
            Order order = new Order();
            bool add_order = addOrder(username); 
            if (add_order)
            {
                order = _phoneStoreContext.Orders.OrderByDescending(o => o.OrderId).First();
            }

            OrderDetail orderDetail = new OrderDetail();
            orderDetail.OrderId = order.OrderId;
            orderDetail.PhoneId = phoneid;
            orderDetail.Quantity = quantity;

            _phoneStoreContext.OrderDetails.Add(orderDetail);
            _phoneStoreContext.SaveChanges();

            return Task.FromResult(true);
        }
    }
}
