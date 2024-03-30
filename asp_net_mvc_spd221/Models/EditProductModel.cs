using System.ComponentModel.DataAnnotations;

namespace asp_net_mvc_spd221.Models
{
    public class EditProductModel
    {
        public int Id { get; set; }
        [MinLength(2)]
        public string Name { get; set; }

        [Range(0, int.MaxValue)]
        public decimal Price { get; set; }

        [StringLength(4000, MinimumLength = 10)]
        public string? Description { get; set; }

        [Range(0, 100)]
        public int Discount { get; set; }
        public bool InStock { get; set; }

        [Url]
        public string ImageUrl { get; set; }

        [Range(1, int.MaxValue)]
        public int CategoryId { get; set; }
    }
}
