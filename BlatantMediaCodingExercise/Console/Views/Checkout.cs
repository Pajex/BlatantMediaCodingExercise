using System;
using GroceryCoConsole.Controller;

namespace GroceryCoConsole.Views
{
    /// <summary>
    ///  class...
    /// </summary>
    public static class Checkout
    {
        private static readonly CheckoutController _checkoutController = new CheckoutController();
        /// <summary>
        /// Method which represents rendering a view.
        /// Calls are made to the CheckoutConstructor based on user input.
        /// </summary>
        public static void Display()
        {
            const string checkoutTemplate = "1. Checkout Items\n" +
                                          "2. View Price Catalogue\n" +
                                          "3. View Promotion Catalogue\n" +
                                          "4. Sign Out\n" +
                                          "Please select an action: ";
            var input = ' ';
            while (input != '4')
            {
                // Show main screen
                Console.Write(checkoutTemplate);

                input = Console.ReadKey().KeyChar;
                Console.WriteLine();
                var output = "";
                switch (input)
                {
                    // Start Checkout
                    case '1':
                        output += _checkoutController.Checkout();
                        break;
                    // View Price Catalogue
                    case '2':
                        output += _checkoutController.ShowPriceCatalogue();
                        break;
                    // View PromotionCatalogue
                    case '3':
                        output += _checkoutController.ShowPromotionCatalogue();
                        break;
                    // Close the program    
                    case '4':
                        output += "Signing out...";
                        break;
                    // No match; try again
                    default:
                        output += $"Invalid Selection: Expected [1-4] - Recieved [{input}]";
                        break;
                }

                Console.WriteLine(output);
            }
        }
    }
}