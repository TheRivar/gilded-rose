using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console.Model
{
    public class NormalItem : Item
    {
        public override void CalculateQuality()
        {
            if (this.SellIn < 0)
            {
                this.Quality = this.Quality - 2;
            }
            else
            {
                this.Quality = this.Quality - 1;
            }
        }
    }
}
