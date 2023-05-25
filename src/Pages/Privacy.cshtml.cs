using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace LetsGoPark.WebSite.Pages
{
    /// <summary>
    /// PageModel class for the privacy page.
    /// </summary>
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        /// <summary>
        /// Constructor for the PrivacyModel class.
        /// </summary>
        /// <param name="logger">The logger instance to use.</param>
        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Constructor for the PrivacyModel class.
        /// </summary>
        /// <param name="logger">The logger instance to use.</param>
        public void OnGet()
        {
        }
    }
}
