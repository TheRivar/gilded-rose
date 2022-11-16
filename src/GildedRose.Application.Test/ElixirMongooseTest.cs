using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GildedRose.Application.Test
{
    [TestClass]
    public class ElixirMongooseTest
    {
        [TestMethod]
        public void ElixirMongoose_WhenQualityIslessThanZero_ShouldArgumentOutOfRangeException()
        {
            // Arrange
            var valueLessZero = -10;

            // Act and assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => new ElixirMongoose("Test", 10, valueLessZero));
        }

        [TestMethod]
        public void ElixirMongoose_WhenQualityIsGreaterThanFifty_ShouldArgumentOutOfRangeException()
        {
            // Arrange
            var valueGreaterFifty = 60;

            // Act and assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => new ElixirMongoose("Test", 10, valueGreaterFifty));
        }

        [TestMethod]
        public void ElixirMongoose_WhenDecrementDoubleIsLessThanZeroUpdateQuality_ShouldThrowException()
        {
            // Arrange            
            var elixirMongoose = new ElixirMongoose("Test", -1, 1);

            // Act and assert
            Assert.ThrowsException<Exception>(() => elixirMongoose.UpdateQuality());
        }

        [TestMethod]
        public void ElixirMongoose_WhenSellInIsNearDecrementQuality_Should_DecrementOne()
        {
            // Arrange            
            var quality = 2;
            var elixirMongoose = new ElixirMongoose("Test", 5, quality);
            var qualityExpected = 1;
            //Act

            elixirMongoose.UpdateQuality();

            // Act and assert
            Assert.AreEqual(qualityExpected, elixirMongoose.Quality);
        }

        [TestMethod]
        public void ElixirMongoose_WhenSellInExpiresDecrementDoubleQuality_Should_DecrementDouble()
        {
            // Arrange            
            var quality = 4;
            var dexterityVest = new ElixirMongoose("Test", -1, quality);
            var qualityExpected = 2;
            //Act

            dexterityVest.UpdateQuality();

            // Act and assert
            Assert.AreEqual(qualityExpected, dexterityVest.Quality);
        }
    }
}
