using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console.Model
{
    public class ValuableItem : Item
    {
        private const int maxQuality = 50;
        public override void CalculateQuality()
        {
            if (this.Quality == maxQuality) return;

            if (this.SellIn < 0 && this.Quality < (maxQuality -1))
            {
                this.Quality = this.Quality + 2;
            }
            else
            {
                this.Quality = this.Quality + 1;
            }
        }
    }
}
