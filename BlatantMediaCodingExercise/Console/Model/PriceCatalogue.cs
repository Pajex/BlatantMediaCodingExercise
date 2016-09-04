﻿using System.Collections.Generic;

namespace GroceryCoConsole.Model
{
    public class PriceCatalogue : Catalogue
    {
        public PriceCatalogue(IList<Item> cataloguedItems)
        {
            Items = cataloguedItems;
        }

        public override string ToString()
        {
            var output = "=== Price Catalogue\n";

            foreach (var item in Items)
            {
                output += $"=== {item.Name} ${item.Price}\n";
            }

            return output;
        }
    }
}