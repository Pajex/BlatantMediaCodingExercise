using System.Collections.Generic;

namespace GroceryCoConsole.Model
{
    public class PromotionCatalogue : Catalogue
    {
        public PromotionCatalogue(IList<Item> promotionalItems)
        {
            Items = promotionalItems;
        }

        public override string ToString()
        {
            var output = "=== Promotion Catalogue\n";

            foreach (var item in Items)
            {
                output += $"=== {item.Name} ${item.SalePrice}\n";
            }

            return output;
        }
    }
}