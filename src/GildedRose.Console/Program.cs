using GildedRose.Application;
using System;
using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Program
    {
        public IList<Product> Products;
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
            {
                Products = new List<Product>
                {
                    new AgedBrie( "Aged Brie" , 2,  0 ),
                    new DexterityVest("+5 Dexterity Vest" , 10, 20 ),
                    new ElixirMongoose("Elixir of the Mongoose" , 5 , 7)
                }
            };

            foreach (var item in app.Products)
            {
                item.UpdateQuality();
                System.Console.WriteLine("Name: " + item.Name + "; Quality: " + item.Quality + "; SellIn: " + item.SellIn + "; Price: " + item.Price);
            }
           
            System.Console.ReadKey();

        }
    }
}
