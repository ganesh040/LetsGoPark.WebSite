using NUnit.Framework;
using LetsGoPark.WebSite.Models;

namespace UnitTests.Models
{
    /// <summary>
    /// Unit tests for ProductTypeEnum
    /// </summary>
    class ParkTypeEnumTests
    {
        #region DisplayName

        /// <summary>
        /// Tests that DisplayName returns  a valid string
        /// </summary>
        [Test]
        public void DisplayName_Should_Return_Valid_String()
        {
            // Arrange

            // Act
            string Statepark = ParkTypeEnum.Statepark.DisplayName();
            string Nationalpark = ParkTypeEnum.Nationalpark.DisplayName();
            string Localpark = ParkTypeEnum.Localpark.DisplayName();
            string others = ParkTypeEnum.others.DisplayName();

            // Assert
            Assert.AreEqual("Statepark", Statepark);
            Assert.AreEqual("Nationalpark", Nationalpark);
            Assert.AreEqual("Localpark", Localpark);
            Assert.AreEqual("others", others);
        }

        #endregion DisplayName

        [Test]
        public void DisplayName_Enum_Out_Of_Range_Return_Default()
        {
            // Arrange

            // Act
            var result = ParkTypeEnumExtensions.DisplayName((ParkTypeEnum)8);

            // Assert
            Assert.AreEqual("", result);
        }
    }
}
