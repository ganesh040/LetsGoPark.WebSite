using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using LetsGoPark.WebSite.Models;
using LetsGoPark.WebSite.Services;

namespace LetsGoPark.WebSite.Controllers
{
    /// <summary>
     /// API controller for managing products.
     /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        /// <summary>
        /// Constructor for the ProductsController class.
        /// </summary>
        /// <param name="productService">An instance of the JsonFileProductService.</param>
        
        public ProductsController(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        /// <summary>
        /// Property that holds the JsonFileProductService instance.
        /// </summary>
        
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// HTTP GET method for retrieving a collection of ProductModel objects.
        /// </summary>
        /// <returns>A collection of ProductModel objects.</returns>
        [HttpGet]
        public IEnumerable<ProductModel> Get()
        {
            return ProductService.GetAllData();
        }

        
        /// <summary>
        /// HTTP PATCH method for updating the rating of a product.
        /// </summary>
        /// <param name="request">The rating request containing the product ID and new rating.</param>
        /// <returns>An HTTP action result indicating the success of the operation.</returns>
        [HttpPatch]
        public ActionResult Patch([FromBody] RatingRequest request)
        {
            ProductService.AddRating(request.ProductId, request.Rating);
            
            return Ok();
        }

        // Class representing the request model for updating the rating of a product.
        public class RatingRequest
        {
            // Property for storing the product ID.
            public string ProductId { get; set; }

            // Property for storing the new rating value.
            public int Rating { get; set; }
        }
    }
}