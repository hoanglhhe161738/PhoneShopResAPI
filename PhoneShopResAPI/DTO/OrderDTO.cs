namespace PhoneShopResAPI.DTO
{
    public class OrderDTO
    {
        public int OrderId { get; set; }

        public OrderDTO(int orderId)
        {
            OrderId = orderId;
        }

        public OrderDTO()
        {
        }
    }
}
