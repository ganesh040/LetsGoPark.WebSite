using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using LetsGoPark.WebSite.Models;
using LetsGoPark.WebSite.Services;

namespace LetsGoPark.WebSite.Pages.Product
{
    /// <summary>
    /// Index Page will return all the data to show the user
    /// </summary>
    public class IndexModel : PageModel
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="productService"></param>
        public IndexModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        /// <summary>
        /// Data Service
        /// </summary>
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// Collection of the Data
        /// </summary>
        public IEnumerable<ProductModel> Products { get; private set; }

        /// <summary>
        /// REST OnGet
        /// Return all the data
        /// </summary>
        public void OnGet()
        {
            Products = ProductService.GetAllData();
        }
    }
}