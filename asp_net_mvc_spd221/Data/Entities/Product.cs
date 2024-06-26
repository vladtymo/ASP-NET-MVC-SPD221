﻿namespace asp_net_mvc_spd221.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public int Discount { get; set; }
        public bool InStock { get; set; }
        public string ImageUrl { get; set; }
        public int Quantity { get; set; }

        public int CategoryId { get; set; }

        // ------- navigation property
        public Category? Category { get; set; }
    }
}
