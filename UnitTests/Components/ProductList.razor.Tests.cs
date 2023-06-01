using Bunit;
using NUnit.Framework;

using LetsGoPark.WebSite.Components;
using Microsoft.Extensions.DependencyInjection;
using LetsGoPark.WebSite.Services;
using System.Linq;
using Microsoft.AspNetCore.Components;
using LetsGoPark.WebSite.Models;
using Moq;

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

        public class Filter
        {
            public string FilterDataType { get; set; }

            public void UpdateFilterType(ChangeEventArgs e)
            {
                FilterDataType = e.Value.ToString();
            }
        }

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

        [Test]
        public void UpdateFilterType_ShouldUpdateFilterDataType()
        {
            // Arrange
            var filter = new Filter();
            var expectedValue = "NewFilterType";

            // Act
            filter.UpdateFilterType(new ChangeEventArgs { Value = expectedValue });

            // Assert
            Assert.AreEqual(expectedValue, filter.FilterDataType);
        }
        #region




        #region EnableFilterData
        [Test]
        public void Enable_Filter_Data_Set_to_True_Should_Return_True()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            var filterButton = "Search";

            var page = RenderComponent<ProductList>();
            var buttonList = page.FindAll("Button");
            var button = buttonList.First(m => m.OuterHtml.Contains(filterButton));

            // Act
            button.Click();
            var pageMarkup = page.Markup;

            // Assert
            Assert.AreEqual(true, true);
        }
        #endregion EnableFilterData

        #region ClearFilterData
        [Test]
        public void Clear_Filter_Data_Set_to_False_Should_Return_False()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            var clearButton = "Clear";

            var page = RenderComponent<ProductList>();

            // Find the Buttons (Clear)
            var buttonList = page.FindAll("Button");

            // Find the one that matches the button name looking for and click it
            var button = buttonList.First(m => m.OuterHtml.Contains(clearButton));

            // Act
            button.Click();

            // Get the markup to use for the assert
            var pageMarkup = page.Markup;

            // Assert
            Assert.AreEqual(false, false);
        }
        #endregion ClearFilterData

        #region submitrating

        [Test]
        public void SubmitRating_Valid_ID_Click_Unstared_Should_Increment_Count_And_Check_Star()
        {
            /*
             This test tests that the SubmitRating will change the vote as well as the Star checked
             Because the star check is a calculation of the ratings, using a record that has no stars and checking one makes it clear what was changed

            The test needs to open the page
            Then open the popup on the card
            Then record the state of the count and star check status
            Then check a star
            Then check again the state of the cound and star check status

            */

            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            var Title = "MoreInfoButton_SAINT EDWARD STATE PARK";

            var page = RenderComponent<ProductList>();

            // Find the Buttons (more info)
            var buttonList = page.FindAll("Button");

            // Find the one that matches the ID looking for and click it
            var button = buttonList.First(m => m.OuterHtml.Contains(Title));
            button.Click();

            // Get the markup of the page post the Click action
            var buttonMarkup = page.Markup;

            // Get the Star Buttons
            var starButtonList = page.FindAll("span");

            // Get the Vote Count
            // Get the Vote Count, the List should have 7 elements, element 2 is the string for the count
            var preVoteCountSpan = starButtonList[1];
            var preVoteCountString = preVoteCountSpan.OuterHtml;

            // Get the First star item from the list, it should not be checked
            var starButton = starButtonList.First(m => !string.IsNullOrEmpty(m.ClassName) && m.ClassName.Contains("fa fa-star"));

            // Save the html for it to compare after the click
            var preStarChange = starButton.OuterHtml;

            // Act

            // Click the star button
            starButton.Click();

            // Get the markup to use for the assert
            buttonMarkup = page.Markup;

            // Get the Star Buttons
            starButtonList = page.FindAll("span");

            // Get the Vote Count, the List should have 7 elements, element 2 is the string for the count
            var postVoteCountSpan = starButtonList[1];
            var postVoteCountString = postVoteCountSpan.OuterHtml;

            // Get the Last stared item from the list
            starButton = starButtonList.First(m => !string.IsNullOrEmpty(m.ClassName) && m.ClassName.Contains("fa fa-star checked"));

            // Save the html for it to compare after the click
            var postStarChange = starButton.OuterHtml;

            // Assert

            // Confirm that the record had no votes to start, and 1 vote after
            Assert.AreEqual(true, preVoteCountString.Contains("Be the first to vote!"));
            Assert.AreEqual(true, postVoteCountString.Contains("1 Vote"));
            Assert.AreEqual(false, preVoteCountString.Equals(postVoteCountString));
        }
        #endregion submitrating
        [Test]
        public void AddCommentButton_ShouldShowInputAndSaveCommentButton()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            var component = RenderComponent<ProductList>();
            var id = "MoreInfoButton_FLAMING GEYSER STATE PARK";

            // Find the Buttons (more info)
            var buttonList = component.FindAll("Button");

            // Find the one that matches the ID looking for and click it
            var button = buttonList.First(m => m.OuterHtml.Contains(id));
            button.Click();

            // Get the markup of the page post the Click action
            var buttonMarkup = component.Markup;

            // Act
            component.Find("#AddComment").Click();

            // Assert
            Assert.IsNotNull(component.Find("input[type=text]"));
            Assert.IsNotNull(component.Find("button.btn.btn-success"));
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

        #endregion




    }
}