using System.Collections.Generic;

namespace GroceryCoConsole.Model
{
    public class PromotionCatalogue : Catalogue
    {
        public PromotionCatalogue(IList<Item> promotionalItems)
        {
            Items = promotionalItems;
        }

        public PromotionCatalogue() {}

        public override string ToString()
        {
            var output = "-----------------------------\n";
            output += $"{"Promotion Catalogue",24}\n";
            output += "-----------------------------\n";
            output += $"{"Item",8} {"Discounted Price",18}\n";

            foreach (var item in Items)
            {
                output += $"{item.Name,8} {item.SalePrice,18:C2}\n";
            }

            return output;
        }
    }
}