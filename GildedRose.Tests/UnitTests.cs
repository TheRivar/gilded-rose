using GildedRose.Console;
using GildedRose.Console.Model;
using NUnit.Framework;
using System.Collections.Generic;

namespace GildedRose.Tests
{
    public class UnitTests
    {
        private Program _program;
        [SetUp]
        public void Setup()
        {
            _program = new Program();
        }

        [Test]
        public void ReduceQualityAndSellInNotAgedBrie()
        {
            int initialSellin = 30;
            string initialName = "Not Aged Brie";
            int quality = 30;
            decimal initialPrice = 0;

            _program.Items = new List<IItem>
            {
                new NormalItem
                {
                    SellIn = initialSellin,
                    Name = initialName,
                    Quality = quality
                }
            };

            _program.UpdateQuality();

            IItem itemNotAgedBrie = _program.Items[0];

            Assert.AreEqual(initialSellin -1, itemNotAgedBrie.SellIn);
            Assert.AreEqual(quality -1, itemNotAgedBrie.Quality);

            initialSellin = _program.Items[0].SellIn;
            quality = _program.Items[0].Quality;
            initialPrice = _program.Items[0].Price;

            _program.UpdateQuality();

            Assert.AreEqual(initialSellin -1, itemNotAgedBrie.SellIn);
            Assert.AreEqual(quality -1, itemNotAgedBrie.Quality);
            Assert.Less(itemNotAgedBrie.Price, initialPrice);
        }

        [Test]
        public void ReduceQualityAndSellInAgedBrie()
        {
            int initialSellin = 40;
            string initialName = "Aged Brie";
            int quality = 40;
            decimal initialPrice = 0;

            _program.Items = new List<IItem>
            {
                new ValuableItem
                {
                    SellIn = initialSellin,
                    Name = initialName,
                    Quality = quality
                }
            };

            _program.UpdateQuality();

            IItem itemNotAgedBrie = _program.Items[0];

            Assert.AreEqual(initialSellin -1, itemNotAgedBrie.SellIn);
            Assert.AreEqual(quality +1, itemNotAgedBrie.Quality);

            initialSellin = _program.Items[0].SellIn;
            quality = _program.Items[0].Quality;
            initialPrice = _program.Items[0].Price;

            _program.UpdateQuality();

            Assert.AreEqual(initialSellin -1, itemNotAgedBrie.SellIn);
            Assert.AreEqual(quality +1, itemNotAgedBrie.Quality);
            Assert.Greater(itemNotAgedBrie.Price, initialPrice);
        }

        [Test]
        public void LimitMaxQualityAgedBrie()
        {
            const int maxQuality = 50;
            int initialSellin = 30;
            string initialName = "Aged Brie";
            int quality = 49;
            decimal initialPrice = 0;

            _program.Items = new List<IItem>
            {
                new ValuableItem
                {
                    SellIn = initialSellin,
                    Name = initialName,
                    Quality = quality
                }
            };

            _program.UpdateQuality();

            IItem itemNotAgedBrie = _program.Items[0];

            Assert.AreEqual(initialSellin -1, itemNotAgedBrie.SellIn);
            Assert.AreEqual(maxQuality, itemNotAgedBrie.Quality);

            initialSellin = _program.Items[0].SellIn;
            quality = _program.Items[0].Quality;
            initialPrice = _program.Items[0].Price;

            _program.UpdateQuality();

            Assert.AreEqual(initialSellin -1, itemNotAgedBrie.SellIn);
            Assert.AreEqual(maxQuality, itemNotAgedBrie.Quality);
            Assert.AreEqual(initialPrice, itemNotAgedBrie.Price);
        }

        [Test]
        public void QualityDegradedDouble()
        {
            int initialSellin = 0;
            string initialName = "Not Aged Brie";
            int quality = 30;

            _program.Items = new List<IItem>
            {
                new NormalItem
                {
                    SellIn = initialSellin,
                    Name = initialName,
                    Quality = quality
                }
            };

            _program.UpdateQuality();

            IItem itemNotAgedBrie = _program.Items[0];

            Assert.AreEqual(itemNotAgedBrie.SellIn, initialSellin -1);
            Assert.AreEqual(quality-2, itemNotAgedBrie.Quality);
        }


        [Test]
        public void QualityIncreaseDouble()
        {
            int initialSellin = 0;
            string initialName = "Aged Brie";
            int quality = 30;

            _program.Items = new List<IItem>
            {
                new ValuableItem
                {
                    SellIn = initialSellin,
                    Name = initialName,
                    Quality = quality
                }
            };

            _program.UpdateQuality();

            IItem itemNotAgedBrie = _program.Items[0];

            Assert.AreEqual(itemNotAgedBrie.SellIn, initialSellin -1);
            Assert.AreEqual(quality+2, itemNotAgedBrie.Quality);
        }
        
        [Test]
        public void TestRealCasesWith3Days()
        {
            _program.Items = new List<IItem>
            {
                new NormalItem {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new ValuableItem {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new NormalItem {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7}
            };

            _program.UpdateQuality();

            IItem item1 = _program.Items[0];
            IItem item2 = _program.Items[1];
            IItem item3 = _program.Items[2];

            Assert.AreEqual(item1.SellIn, 9);
            Assert.AreEqual(19, item1.Quality);
            Assert.Greater(item1.Price, 0);

            Assert.AreEqual(item2.SellIn, 1);
            Assert.AreEqual(1, item2.Quality);
            Assert.Greater(item2.Price, 0);

            Assert.AreEqual(item3.SellIn, 4);
            Assert.AreEqual(6, item3.Quality);
            Assert.Greater(item3.Price, 0);

            _program.UpdateQuality();

            Assert.AreEqual(item1.SellIn, 8);
            Assert.AreEqual(18, item1.Quality);

            Assert.AreEqual(item2.SellIn, 0);
            Assert.AreEqual(2, item2.Quality);

            Assert.AreEqual(item3.SellIn, 3);
            Assert.AreEqual(5, item3.Quality);

            _program.UpdateQuality();

            Assert.AreEqual(item1.SellIn, 7);
            Assert.AreEqual(17, item1.Quality);

            Assert.AreEqual(item2.SellIn, -1);
            Assert.AreEqual(4, item2.Quality);

            Assert.AreEqual(item3.SellIn, 2);
            Assert.AreEqual(4, item3.Quality);

        }


    }
}