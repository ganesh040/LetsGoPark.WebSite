using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace LetsGoPark.WebSite.Pages
{
    /// <summary>
    /// PageModel class for handling error pages.
    /// </summary>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class ErrorModel : PageModel
    {
       
        // The ID of the current request.
        
        public string RequestId { get; set; }

        /// <summary>
        /// Gets a value indicating whether to show the request ID.
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        private readonly ILogger<ErrorModel> _logger;

        /// <summary>
        /// Constructor for the ErrorModel class.
        /// </summary>
        /// <param name="logger">The logger instance to use.</param>
        public ErrorModel(ILogger<ErrorModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Handler for the HTTP GET request.
        /// Assigns the current request ID to the RequestId property.
        /// </summary>
        public void OnGet()
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        }
    }
}