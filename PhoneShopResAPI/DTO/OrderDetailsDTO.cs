namespace PhoneShopResAPI.DTO
{
    public class OrderDetailsDTO
    {
        public int OrderDetailId { get; set; }
        public int? OrderId { get; set; }
        public int? PhoneId { get; set; }
        public int? Quantity { get; set; }

        public OrderDetailsDTO( int? orderId, int? phoneId, int? quantity)
        {
            OrderId = orderId;
            PhoneId = phoneId;
            Quantity = quantity;
        }

        public OrderDetailsDTO()
        {
        }
    }
}
