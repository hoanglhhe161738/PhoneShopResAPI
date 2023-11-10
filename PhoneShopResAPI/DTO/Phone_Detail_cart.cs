namespace PhoneShopResAPI.DTO
{
    public class Phone_Detail_cart
    {
        public string? imageUrl { get;set; }
        public string? modelName { get; set; }
        public long? price { get; set; }
        public string? description { get;set; }
        public int ? quantity { get; set; }

        public Phone_Detail_cart()
        {
        }

        public Phone_Detail_cart(string? imageUrl, string? modelName, long? price, string? description, int? quantity)
        {
            this.imageUrl = imageUrl;
            this.modelName = modelName;
            this.price = price;
            this.description = description;
            this.quantity = quantity;
        }
    }
}
