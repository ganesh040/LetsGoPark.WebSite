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






        [JsonPropertyName("img")]
        [Required(ErrorMessage = "The Image field is required.")]
        [RegularExpression(@"^.*\.(jpg|jpeg|png)$", ErrorMessage = "The Image field must be a valid URL ending with .jpg, .jpeg, or .png.")]
        public string Image { get; set; }



        // Enum product type
        public string ParkType { get; set; }








        // Gets or sets the URL of the Park.
        [RegularExpression(@"^(http:\/\/|https:\/\/).*$", ErrorMessage = "The Url must be a valid HTTP or HTTPS URL.")]



        public string Url { get; set; }



        // Gets or sets the title of the Park.
        [StringLength(maximumLength: 33, MinimumLength = 1, ErrorMessage = "The Title should have a length of more than {2} and less than {1}")]
        public string Title { get; set; }



        // Gets or sets the description of the Park.
        public string Description { get; set; }



        // Activities associated with the park
        public string Activities { get; set; }



        // Gets or sets the ratings of the park
        public int[] Ratings { get; set; }






        // Returns a JSON string representation of the ProductModel object.
        public List<CommentModel> CommentList { get; set; } = new List<CommentModel>();



        // Returns a JSON string representation of the ProductModel object.
        public override string ToString() => JsonSerializer.Serialize<ProductModel>(this);




    }
}