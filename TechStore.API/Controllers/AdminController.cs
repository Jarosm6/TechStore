using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechStore.API.Data;
using TechStore.API.DTOs;
using TechStore.API.Models;

namespace TechStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {

        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("AddProduct")]
        public async Task<ActionResult> AddProduct(CreateProductRequest request)
        {
            var newproduct = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                SalePrice = request.SalePrice,
                ImageUrl = request.ImageUrl,
                StockQuantity = request.StockQuantity,
                Category = request.Category
            };

            _context.Products.Add(newproduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(ProductsController.GetProduct),"Products", new { id = newproduct.Id }, newproduct);
        }

    }

}
