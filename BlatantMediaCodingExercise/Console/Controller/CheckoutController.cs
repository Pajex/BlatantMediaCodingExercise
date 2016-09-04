using System;
using GroceryCoConsole.Infrastructure;
using GroceryCoConsole.Model;
using GroceryCoConsole.Service;

namespace GroceryCoConsole.Controller
{
    public  class CheckoutController
    {
        private CheckoutService _checkoutService = new CheckoutService();
        private const string PriceCatalogueRelativePath = "../../Resources/price-catalogue.json";
        private const string PromotionsRelativePath = "../../Resources/promotions.json";

        public string Checkout()
        {
            //// Load price catalogue and promotional resources
            // Parse from JSON to respective Model (PriceCatalogue, PromotionCatalogue)
           

            //// Read items from cart.json
            // Determine if item is already in receipt
            // If item already exists - Update quantity
            // Else
            // Determine price of item (price catalogue)
            // Determine if item is on sale (promotions)
            // If on sale - Set sale price
            // Set regular price
            // Add item to Receipt (IList)
            // Repeat for all items

            return "";
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