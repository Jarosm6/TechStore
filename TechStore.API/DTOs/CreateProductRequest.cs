using Microsoft.EntityFrameworkCore;

namespace TechStore.API.DTOs
{
    public class CreateProductRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal? SalePrice { get; set; }
        public string ImageUrl { get; set; }
        public int StockQuantity { get; set; }
        public string Category { get; set; }
    }
}
