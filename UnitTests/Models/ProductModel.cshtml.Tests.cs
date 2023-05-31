using NUnit.Framework;
using System.Collections.Generic;
using LetsGoPark.WebSite.Models;

namespace LetsGoPark.WebSite.Models.Tests
{
    [TestFixture]
    public class ProductModelTests
    {

        private const string MockId = "BLAKE ISLAND MARINE STATE PARK";

        private const string MockTitle = "BLAKE ISLAND MARINE STATE PARK";

        private const string MockType = "Statepark";

        private const string MockDescription = "Blake Island Marine State Park is a 472-acre, marine camping park with 5 miles of saltwater beach shoreline and approximately 655 acres of saltwater bedland. The park is reachable only by tour boat or private boat.";

        private const string MockUrl = "https://www.parks.wa.gov/476/Blake-Island";

        private const string MockImage = "https://www.parks.wa.gov/ImageRepository/Document?documentID=9894";

        private const string MockActivities = "Activities: Mountain Biking, Hiking, Fishing, Boating, Diving,crabbing, Bird Watching";


        [Test]
        public void ToString_ReturnsJson()
        {
            // Arrange
            var product = new ProductModel
            {
                Id = MockId,
                Title = MockTitle,
                ParkType = MockType,
                Url = MockUrl,
                Image = MockImage,
                Activities = MockActivities
            };

            // Act
            var jsonString = product.ToString();

            // Assert
            Assert.IsNotEmpty(jsonString);
            Assert.IsTrue(jsonString.Contains(product.Id));
            Assert.IsTrue(jsonString.Contains(product.Title));
            Assert.IsTrue(jsonString.Contains(product.ParkType));
            Assert.IsTrue(jsonString.Contains(product.Url));
            Assert.IsTrue(jsonString.Contains(product.Image));
            Assert.IsTrue(jsonString.Contains(product.Activities));

        }

        [Test]
        public void CommentList_DefaultValueIsNotNull()
        {
            // Arrange
            var product = new ProductModel();

            // Assert
            Assert.IsNotNull(product.CommentList);
        }
    }
}