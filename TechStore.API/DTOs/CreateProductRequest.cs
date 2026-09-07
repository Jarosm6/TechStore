
using System.ComponentModel.DataAnnotations;

namespace TechStore.API.DTOs
{
    public class CreateProductRequest : IValidatableObject
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a non-negative value.")]
        public decimal Price { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "SalePrice must be a non-negative value.")]
        public decimal? SalePrice { get; set; }
        public string ImageUrl { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Stock quantity must be a non-negative value.")]
        public int StockQuantity { get; set; }
        public string Category { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(SalePrice.HasValue && SalePrice.Value > Price)
            {
                yield return new ValidationResult("Sale price cannot be greater than the regular price.",new[] { nameof(SalePrice) });
            }
        }
    }
}
