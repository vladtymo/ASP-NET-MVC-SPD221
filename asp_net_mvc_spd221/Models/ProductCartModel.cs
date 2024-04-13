namespace asp_net_mvc_spd221.Models
{
    public class ProductCartModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public bool InStock { get; set; }
        public string ImageUrl { get; set; }
        public string CategoryName { get; set; }
        public int Quantity { get; set; }
        public int CountToBuy { get; set; }
    }
}
