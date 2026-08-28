using Microsoft.EntityFrameworkCore;

namespace TechStore.API.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public  string Description { get; set; }
        [Precision(10, 2)]
        public decimal Price { get; set; }
        [Precision(10, 2)]
        public decimal? SalePrice { get; set; }
        public string ImageUrl {  get; set; }
        public int StockQuantity { get; set; }
        public string Category { get; set; }
    }
}
