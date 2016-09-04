using System.Linq;
using GroceryCoConsole.Model;
using GroceryCoConsole.Service;

namespace GroceryCoConsole.Controller
{
    public  class CheckoutController
    {
        private readonly CheckoutService _checkoutService = new CheckoutService();
        private const string PriceCatalogueRelativePath = "../../Resources/price-catalogue.json";
        private const string PromotionsRelativePath = "../../Resources/promotions.json";
        private const string ShoppingCartRelativePath = "../../Resources/shopping-cart.txt";

        public string Checkout()
        {
            //// Load price catalogue and promotional resources
            // Parse from JSON to respective Model (PriceCatalogue, PromotionCatalogue)
            var priceCatalogue = _checkoutService.GetPriceCatalogue(PriceCatalogueRelativePath);
            var promotionCatalogue = _checkoutService.GetPromotionalCatalogue(PromotionsRelativePath);
            
            // Read items from cart.json
            var shoppingCart = _checkoutService.GetShoppingCart(ShoppingCartRelativePath);
            var receipt = new Receipt();

            
            foreach (var item in shoppingCart)
            {
                // Determine if item is already in receipt
                if (receipt.CheckedOutItems.Any(x => x.Name == item))
                {
                    // If item already exists - Update quantity
                    receipt.CheckedOutItems.FirstOrDefault(x => x.Name == item).Quantity++;
                }
                else
                {
                    // Determine price of item (price catalogue)
                    var itemFromPriceCatalogue = priceCatalogue.Items.FirstOrDefault(x => x.Name == item);
                    if (itemFromPriceCatalogue != null)
                    {
                        var checkedOutItem = new CheckedOutItem
                        {
                            Name = item.ToLower(),
                            Price = itemFromPriceCatalogue.Price,
                            Quantity = 1
                        };

                        // Determine if item is on sale (promotions)
                        var itemFromPromotionCatalogue = promotionCatalogue.Items.FirstOrDefault(x => x.Name == item);
                        if (itemFromPromotionCatalogue != null)
                        {
                            // If on sale - Set sale price
                            checkedOutItem.OnSale = true;
                            checkedOutItem.SalePrice = itemFromPromotionCatalogue.SalePrice;
                        }

                        // Add item to Receipt
                        receipt.CheckedOutItems.Add(checkedOutItem);
                    }
                }
            }
            
            return receipt.ToString();
        }

        public string ShowPriceCatalogue()
        {
            // Call service layer to retrieve Price Catalogue
            var priceCatalogue = _checkoutService.GetPriceCatalogue(PriceCatalogueRelativePath);

            // Return "view" of price catalogue
            return priceCatalogue.ToString();
        }

        public string ShowPromotionCatalogue()
        {
            // Call service layer to retrieve Promotions Catalogue
            var promotionCatalogue = _checkoutService.GetPromotionalCatalogue(PromotionsRelativePath);

            // Return "view" of promotion catalogue
            return promotionCatalogue.ToString();
        }
    }
}