using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GildedRose.Application.Test
{
    [TestClass]
    public class DexterityVestTest
    {
        [TestMethod]
        public void DexterityVest_WhenQualityIslessThanZero_ShouldArgumentOutOfRangeException()
        {
            // Arrange
            var valueLessZero = -10;

            // Act and assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => new DexterityVest("Test", 10, valueLessZero));
        }

        [TestMethod]
        public void DexterityVest_WhenQualityIsGreaterThanFifty_ShouldArgumentOutOfRangeException()
        {
            // Arrange
            var valueGreaterFifty = 60;

            // Act and assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => new DexterityVest("Test", 10, valueGreaterFifty));
        }

        [TestMethod]
        public void DexterityVest_WhenDecrementDoubleIsLessThanZeroUpdateQuality_ShouldThrowException()
        {
            // Arrange            
            var dexterityVest = new DexterityVest("Test", -1, 1);

            // Act and assert
            Assert.ThrowsException<Exception>(() => dexterityVest.UpdateQuality());
        }

        [TestMethod]
        public void DexterityVest_WhenSellInIsNearDecrementQuality_Should_DecrementOne()
        {
            // Arrange            
            var quality = 2;
            var dexterityVest = new DexterityVest("Test", 5, quality);
            var qualityExpected = 1;
            //Act

            dexterityVest.UpdateQuality();

            // Act and assert
            Assert.AreEqual(qualityExpected, dexterityVest.Quality);
        }

        [TestMethod]
        public void DexterityVest_WhenSellInExpiresDecrementDoubleQuality_Should_DecrementDouble()
        {
            // Arrange            
            var quality = 4;
            var dexterityVest = new DexterityVest("Test", -1, quality);
            var qualityExpected = 2;
            //Act

            dexterityVest.UpdateQuality();

            // Act and assert
            Assert.AreEqual(qualityExpected, dexterityVest.Quality);
        }
    }
}
