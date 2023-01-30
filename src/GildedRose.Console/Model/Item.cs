using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console.Model
{
    public class Item : IItem
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }
        public decimal Price => Math.Round(this.Quality * 1.9M, 2);

        public virtual void CalculateQuality() { }

        public void CalculateSellIn()
        {
            this.SellIn = this.SellIn -1;
        }
    }
}
