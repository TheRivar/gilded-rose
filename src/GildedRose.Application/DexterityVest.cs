using System;
using System.Configuration;

namespace GildedRose.Application
{
    public class DexterityVest : Product
    {
        public DexterityVest(string name, int sellIn, int quality) : base(name, sellIn, quality)
        {
        }

        public override void UpdateQuality()
        {
            if (Quality > _minQuality && Quality < _topQuality && SellIn >= 0)
            {
                Quality--;
            }
            else if (Quality > _minQuality && Quality < _topQuality && SellIn < 0)
            {
                var decrement = Quality - 2; // Se degrada el doble de rapido al vencerse 
                if (decrement < _minQuality)
                    throw new Exception("The quality can't be less than 0");
                Quality = decrement;
            }
            SellIn--;
            Price = Math.Round(Quality * 1.9M, 2);
        }
    }
}
