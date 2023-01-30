using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console.Model
{
    public interface IItem
    {
        void CalculateSellIn();
        void CalculateQuality();
        decimal Price { get; }
        string Name { get; }
        int SellIn { get; }
        int Quality { get; }
    }
}
