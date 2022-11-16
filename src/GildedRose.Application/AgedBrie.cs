using System;
using System.Configuration;

namespace GildedRose.Application
{
    public class AgedBrie : Product
    {
        public AgedBrie(string name, int sellIn, int quality) : base(name, sellIn, quality)
        {
        }

        public override void UpdateQuality()
        {
            if (Quality >= _minQuality && Quality < _topQuality && SellIn >= 0)
            {
                Quality++;
            }
            else if (Quality > _minQuality && Quality < _topQuality && SellIn < 0)
            {
                var increment = Quality + 2; // Si degrada el doble de rapido al vencerse con los otros productos pues aumenta el doble de rapido cuando es AgedBrie :p
                if (increment > _topQuality)
                    throw new Exception("The quality can't be greater than 50");
                Quality = increment;
            }
            SellIn--;
            Price = Math.Round(Quality * 1.9M, 2);
        }
    }
}
