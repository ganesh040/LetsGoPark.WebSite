using LetsGoPark.WebSite.Models;
using LetsGoPark.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LetsGoPark.WebSite.Pages.Product
{
    public class ReadModel : PageModel
    {
        /// <summary>
        /// Data middletier
        /// </summary>
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// Constructor for the ReadModel class.
        /// </summary>
        /// <param name="productService">An instance of the JsonFileProductService.</param>
        public ReadModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }
        public ProductModel Product;

        /// <summary>
        /// Handler for the HTTP GET request.
        /// Retrieves the specified product and assigns it to the Product property.
        /// </summary>
        /// <param name="id">The ID of the product to be retrieved.</param>
        public void OnGet(string id)
        {
            // Retrieve the product with the specified ID from the ProductService.
            // Assign it to the Product property.
            Product = ProductService.GetAllData().FirstOrDefault(m => m.Id.Equals(id));
        }
    }
}