using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Security.Principal;

namespace GildedRose.Application.Test
{
    [TestClass]
    public class AgedBrieTest
    {
        [TestMethod]
        public void AgedBrie_WhenQualityIslessThanZero_ShouldArgumentOutOfRangeException()
        {
            // Arrange
            var valueLessZero = -10;            

            // Act and assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => new AgedBrie("Test", 10, valueLessZero));
        }

        [TestMethod]
        public void AgedBrie_WhenQualityIsGreaterThanFifty_ShouldArgumentOutOfRangeException()
        {
            // Arrange
            var valueGreaterFifty = 60;            

            // Act and assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => new AgedBrie("Test", 10, valueGreaterFifty));
        }

        [TestMethod]
        public void AgedBrie_WhenIncrementDoubleIsGreaterThanFiftyUpdateQuality_ShouldThrowException()
        {
            // Arrange            
            var agedBrie = new AgedBrie("Test", -1, 49);

            // Act and assert
            Assert.ThrowsException<Exception>(() =>  agedBrie.UpdateQuality());
        }

        [TestMethod]
        public void AgedBrie_WhenSellInIsNearIncrementQuality_Should_IncrementOne()
        {
            // Arrange            
            var quality = 2;
            var agedBrie = new AgedBrie("Test", 5, quality);
            var qualityExpected = 3;
            //Act

            agedBrie.UpdateQuality();

            // Act and assert
            Assert.AreEqual(qualityExpected, agedBrie.Quality);
        }

        [TestMethod]
        public void AgedBrie_WhenSellInExpiresIncrementDoubleQuality_Should_IncrementDouble()
        {
            // Arrange            
            var quality = 4;
            var agedBrie = new AgedBrie("Test", -1, quality);
            var qualityExpected = 6;
            //Act

            agedBrie.UpdateQuality();

            // Act and assert
            Assert.AreEqual(qualityExpected, agedBrie.Quality);
        }
    }
}
