using GildedRose.Console.Model;
using System;
using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Program
    {
        public IList<IItem> Items;
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
            {
                Items = new List<IItem>
                {
                    new NormalItem {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                    new ValuableItem {Name = "Aged Brie", SellIn = 2, Quality = 0},
                    new NormalItem {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7}
                }
            };

            app.UpdateQuality();

            System.Console.ReadKey();

        }

        public void UpdateQuality()
        {
            foreach (IItem item in Items)
            {
                item.CalculateSellIn();
                item.CalculateQuality();
            }
        }
    }
}
