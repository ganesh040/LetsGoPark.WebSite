using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

using LetsGoPark.WebSite.Models;
using LetsGoPark.WebSite.Services;

namespace LetsGoPark.WebSite.Pages
{
    /// <summary>
    /// PageModel class for the index page.
    /// </summary>
    public class IndexModel : PageModel
    {

        private readonly ILogger<IndexModel> _logger;

        /// <summary>
        /// Constructor for the IndexModel class.
        /// </summary>
        /// <param name="logger">The logger instance to use.</param>
        /// <param name="productService">The JsonFileProductService instance to use.</param>
        public IndexModel(ILogger<IndexModel> logger,
            JsonFileProductService productService)
        {
            _logger = logger;
            ProductService = productService;
        }

        // The JsonFileProductService instance for handling product-related operations.
        public JsonFileProductService ProductService { get; }
        // The collection of products to be displayed on the index page
        public IEnumerable<ProductModel> Products { get; private set; }

        /// <summary>
        /// Handler for the HTTP GET request.
        /// Retrieves all products and assigns them to the Products property.
        /// </summary>
        public void OnGet()
        {
            Products = ProductService.GetAllData();
        }
    }
}