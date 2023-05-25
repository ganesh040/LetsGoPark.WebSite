using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace LetsGoPark.WebSite.Models
{
    /// <summary>
    /// Model class representing a product.
    /// </summary>
    public class ProductModel
    {
        // Gets or sets the ID of the product.
       
        public string Id { get; set; }


        // Gets or sets the maker of the Park.
        public string Maker { get; set; }

        // Gets or sets the image URL of the Park.
        [JsonPropertyName("img")]
        public string Image { get; set; }

        // Enum product type
        public string ProductType { get; set; }

        // Gets or sets the URL of the Park.
        public string Url { get; set; }

        // Gets or sets the title of the Park.
        [StringLength(maximumLength: 33, MinimumLength = 1, ErrorMessage = "The Title should have a length of more than {2} and less than {1}")]
        public string Title { get; set; }

        // Gets or sets the description of the Park.
        public string Description { get; set; }

        public string Activities { get; set; } // Activities associated with the park

        // Gets or sets the ratings of the park
        public int[] Ratings { get; set; }

        // Gets or sets the quantity of the park
        public string Quantity { get; set; }

        // Store the Comments entered by the users on this Park
        public List<CommentModel> CommentList { get; set; } = new List<CommentModel>();

        // Returns a JSON string representation of the ProductModel object.
        public override string ToString() => JsonSerializer.Serialize<ProductModel>(this);


    }
}