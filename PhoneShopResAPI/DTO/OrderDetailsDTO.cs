namespace PhoneShopResAPI.DTO
{
    public class OrderDetailsDTO
    {
        public int? OrderDetailId { get; set; }
        public int? OrderId { get; set; }
        public int? PhoneId { get; set; }
        public string? modelName { get; set; }
        public decimal? price { get;set; }
        public int? Quantity { get; set; }
        public string? imageUrl { get;set; }
        public string? description { get;set; }

        public OrderDetailsDTO(int? orderDetailId, int? orderId, int? phoneId, string? modelName, decimal? price, int? quantity, string? imageUrl, string? description)
        {
            OrderDetailId = orderDetailId;
            OrderId = orderId;
            PhoneId = phoneId;
            this.modelName = modelName;
            this.price = price;
            Quantity = quantity;
            this.imageUrl = imageUrl;
            this.description = description;
        }

        public OrderDetailsDTO()
        {
        }
    }
}
