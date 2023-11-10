using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneShopResAPI.DTO;
using PhoneShopResAPI.Models;
using PhoneShopResAPI.ModelsRow;
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
           // int id = orders[0].OrderId;
            List<OrderDetail> list = new List<OrderDetail>();
            List<OrderDetailsDTO> list1 = new List<OrderDetailsDTO>();
            List<Phone> phones = new List<Phone>();
            try
            {
                list = _phoneStoreContext.OrderDetails.ToList();
                phones = _phoneStoreContext.Phones.ToList();
                foreach (var order in orders)
                {
                    foreach (var item in list)
                    {
                        if(item.OrderId == order.OrderId)
                        {
                            OrderDetailsDTO orderDetailsDTO = new OrderDetailsDTO();
                            orderDetailsDTO.OrderDetailId = item.OrderDetailId;
                            orderDetailsDTO.OrderId = item.OrderId;
                            orderDetailsDTO.PhoneId = item.PhoneId;
                            orderDetailsDTO.Quantity = item.Quantity;
                            list1.Add(orderDetailsDTO);
                        }
                    }
                }

                foreach (var item in list1)
                {
                    Phone? phone = _phoneStoreContext.Phones.Where(p => p.PhoneId == item.PhoneId).FirstOrDefault();
                    item.modelName = phone.ModelName;
                    item.imageUrl = phone.ImageUrl;
                    item.description = phone.Description != null ? phone.Description : "Chưa có mô tả thêm về sản phẩm" ;
                    item.price = phone.Price;
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
            List<Order> orders = _phoneStoreContext.Orders.Include(o => o.OrderDetails).Where(o => o.Username == username).ToList();
            List<OrderDetailsDTO> list = OrderDetails(orders);
            return list.AsEnumerable<OrderDetailsDTO>();
        }


        [HttpDelete("DeleteCart")]
        public async Task<IActionResult> deleteCart(int id)
        {
            var order = await _phoneStoreContext.OrderDetails.Where(o => o.OrderDetailId == id).FirstAsync();

            if(order != null){
                OrderDetail orderDetail = order;
                _phoneStoreContext.OrderDetails.Remove(orderDetail);
                _phoneStoreContext.SaveChanges();
                return CreatedAtAction(nameof(deleteCart), new { id = orderDetail.OrderId.ToString() }, orderDetail);
            }
            return NoContent();
        }


    }
}
