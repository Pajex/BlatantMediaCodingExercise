using System;
using System.Collections.Generic;

namespace GroceryCoConsole.Model
{
    public class PriceCatalogue : Catalogue
    {
        public PriceCatalogue(IList<Item> cataloguedItems)
        {
            Items = cataloguedItems;
        }

        public PriceCatalogue() {}

        public override string ToString()
        {
            var output = "--------------------------\n";
            output += $"{"Price Catalogue",20}\n";
            output += "--------------------------\n";
            output += $"{"Item",8} {"Price",12}\n";

            foreach (var item in Items)
            {
                output += $"{item.Name,8} {item.Price,12:C2}\n";
            }

            return output;
        }
    }
}