using System.Linq;
using NUnit.Framework;

using LetsGoPark.WebSite.Pages.Product;

namespace UnitTests.Pages.Product.Read
{
    /// <summary>
    /// Unit tests for the ReadModel class.
    /// </summary>
    public class ReadTests
    {
        #region TestSetup
        public static ReadModel pageModel;

        [SetUp]
        public void TestInitialize()
        {
            // Initialize the page model with ProductService
            pageModel = new ReadModel(TestHelper.ProductService)
            {
                // Additional initialization parameters can be added here if necessary
            };
        }

        #endregion TestSetup

        #region OnGet
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange (preparing the necessary objects or data for the test)

            // Act (performing the actual operation being tested)
            pageModel.OnGet("LAKE SAMMAMISH STATE PARK");

            // Assert (verifying the expected outcome)
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("LAKE SAMMAMISH STATE PARK", pageModel.Product.Title);
        }
        #endregion OnGet

        #region ongetnull
        /// <summary>
        /// The Unit test case to check if the location is null then  then in
        /// should return to the index page
        /// </summary>
        [Test]
        public void OnGet_With_Null_Location_Should_Redirect_To_Index()
        {
            // Arrange
            var id = "letsgopark";

            // Act
            var result = pageModel.OnGet(id);

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(null, pageModel.Product);
        }

        #endregion ongetnull



        #region GetAverageRating

        /// <summary>
        /// The Unit test case to check if average rating computation is correct
        /// </summary> 
        [Test]
        public void GetAverageRating_Ratings_Is_Null_Should_Return_Zero()
        {
            // Arrange
            var product = TestHelper.ProductService.GetAllData().First();

            // Act
            var result = pageModel.GetAverageRating(product.Id);

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void GetAverageRating_Ratings_Not_Null_Should_Return_The_Avg_Rating_Of_Product_Matching_Product_Id()
        {
            // Arrange
            var product = TestHelper.ProductService.GetAllData().First();

            int numRatings = 5;

            for (int i = 0; i < numRatings; i++)
            {
                TestHelper.ProductService.AddRating(product.Id, i + 1);
            }

            var average = TestHelper.ProductService.GetAllData().First().Ratings.Average();

            // Act
            var result = pageModel.GetAverageRating(product.Id);

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(average, result);
        }
        #endregion GetAverageRating
    }
}