using System;
using System.Configuration;

namespace GildedRose.Application
{
    public abstract class Product
    {
        protected readonly int _topQuality = Convert.ToInt32(ConfigurationManager.AppSettings["TopQuality"]);
        protected readonly int _minQuality = Convert.ToInt32(ConfigurationManager.AppSettings["MinQuality"]);
        protected Product(string name, int sellIn, int quality)
        {
            if (quality < _minQuality)
                throw new ArgumentOutOfRangeException("The quality can't be less than 0");
            if (quality > _topQuality)
                throw new ArgumentOutOfRangeException("The quality can't be greater than 50");

            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }

        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }
        public decimal Price { get; set; }

        public abstract void UpdateQuality();
    }
}
