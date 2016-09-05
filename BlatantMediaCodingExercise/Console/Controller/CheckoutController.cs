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

        /// <summary>
        /// Method which processes the checkout order of a user.
        /// Loads both the price and promotion catalogues when called.
        /// </summary>
        /// <returns>A string which represents the receipt of the customers order.</returns>
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
                // Item is already in receipt.
                if (receipt.CheckedOutItems.Any(x => x.Name == item))
                {
                    // Update quantity.
                    receipt.CheckedOutItems.FirstOrDefault(x => x.Name == item).Quantity++;
                }
                // New Item to add to receipt.
                else
                {
                    // Search for item in price catalogue.
                    var itemFromPriceCatalogue = priceCatalogue.Items.FirstOrDefault(x => x.Name == item);
                    // Matching item was found in price catalogue.
                    if (itemFromPriceCatalogue != null)
                    {
                        // Create new checked out item to be placed in receipt.
                        var checkedOutItem = new CheckedOutItem
                        {
                            Name = item.ToLower(),
                            Price = itemFromPriceCatalogue.Price,
                            Quantity = 1
                        };

                        // Search for item in promotion catalogue.
                        var itemFromPromotionCatalogue = promotionCatalogue.Items.FirstOrDefault(x => x.Name == item);
                        // Matching item was found in promotion catalogue.
                        if (itemFromPromotionCatalogue != null)
                        {
                            // Add Sale Price to CheckedOutItem.
                            checkedOutItem.SalePrice = itemFromPromotionCatalogue.SalePrice;
                        }

                        // Add item to Receipt
                        receipt.CheckedOutItems.Add(checkedOutItem);
                    }
                }
            }
            
            return receipt.ToString();
        }

        /// <summary>
        /// Method which calls the checkout service layer to retrieve the 
        /// current price catalogue from storage.
        /// </summary>
        /// <returns>A string which lists all items stored within the price catalogue.</returns>
        public string ShowPriceCatalogue()
        {
            // Call service layer to retrieve Price Catalogue
            var priceCatalogue = _checkoutService.GetPriceCatalogue(PriceCatalogueRelativePath);

            // Return "view" of price catalogue
            return priceCatalogue.ToString();
        }

        /// <summary>
        /// Method which calls the checkout service layer to retrieve the
        /// current promotion catalogue.
        /// </summary>
        /// <returns></returns>
        public string ShowPromotionCatalogue()
        {
            // Call service layer to retrieve Promotions Catalogue
            var promotionCatalogue = _checkoutService.GetPromotionalCatalogue(PromotionsRelativePath);

            // Return "view" of promotion catalogue
            return promotionCatalogue.ToString();
        }
    }
}