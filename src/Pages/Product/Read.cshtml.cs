using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using LetsGoPark.WebSite.Models;
using LetsGoPark.WebSite.Services;

namespace LetsGoPark.WebSite.Pages.Product
{
    /// <summary>
    /// The read model. This is the model for the read page. 
    /// It is responsible for getting the data from the JSON file and displaying it on the page. 
    /// </summary>
    public class ReadModel : PageModel
    {
        // The product service. This is used to get the data from the JSON file.
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// Used to initialize the product service.
        /// <summary>
        public ReadModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        public ProductModel Product;

        /// <summary>
        /// Define a method that will be called when the page is loaded with an id parameter
        /// <summary>
        public IActionResult OnGet(string id)
        {

            Product = ProductService.GetAllData().FirstOrDefault(m => m.Id.Equals(id));
            if (Product == null)
            {
                return RedirectToPage("./Index");
            }

            return Page();
        }

        /// <summary>
        /// This method is used to get the average rating of the product. 
        /// <summary>
        public object GetAverageRating(string productId)
        {

            var products = ProductService.GetAllData();
            var ratings = products.First(x => x.Id == productId).Ratings;
            double average = 0;
            if (ratings != null)
            {
                average = ratings.Average();
            }
            return average;
        }
    }
}