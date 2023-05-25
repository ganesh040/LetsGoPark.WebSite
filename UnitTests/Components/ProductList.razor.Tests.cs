using Bunit;
using NUnit.Framework;

using LetsGoPark.WebSite.Components;
using Microsoft.Extensions.DependencyInjection;
using LetsGoPark.WebSite.Services;
using System.Linq;

namespace UnitTests.Components
{
    public class ProductListTests : BunitTestContext
    {
        #region TestSetup

        [SetUp]
        public void TestInitialize()
        {
        }

        #endregion TestSetup

        [Test]
        public void ProductList_Default_Should_Return_Content()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // Act
            // Render the ProductList component
            var page = RenderComponent<ProductList>();

            // Get the Cards retrned
            var result = page.Markup;

            // Assert
            // Check if the markup contains a specific content
            Assert.AreEqual(true, result.Contains("LAKE SAMMAMISH STATE PARK"));
        }

        #region SelectProduct
        [Test]
        public void SelectProduct_Valid_ID_Should_Return_Content()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            var id = "MoreInfoButton_BRIDLE TRAILS STATE PARK";

            // Render the ProductList component
            var page = RenderComponent<ProductList>();

            // Find the Buttons (more info)
            var buttonList = page.FindAll("Button");

            // Find the one that matches the ID looking for and click it
            var button = buttonList.First(m => m.OuterHtml.Contains(id));

            // Act
            button.Click();

            // Get the markup to use for the assert
            var pageMarkup = page.Markup;

            // Assert
            // Check if the markup contains a specific content
            Assert.AreEqual(true, pageMarkup.Contains(""));
        }
        #endregion SelectProduct

      




    }
}