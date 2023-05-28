using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Linq;
using LetsGoPark.WebSite.Pages;

namespace UnitTests.Pages
{
    /// <summary>
    /// Ths test is for the main page index
    /// </summary>
    public class IndexTests
    {

        #region TestSetup
        public static IndexModel pageModel;

        /// <summary>
        /// Initialize the page model
        /// <summary>
        [SetUp]
        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<IndexModel>>();

            pageModel = new IndexModel(MockLoggerDirect, TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup



        #region OnGet
        [Test]
        public void OnGet_Valid_Should_Return_Locations()
        {
            // Arrange

            // Act
            pageModel.OnGet();

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, pageModel.Products.ToList().Any());
        }
        #endregion OnGet
    }
}
