using System;

namespace GroceryCoConsole.Views
{
    public static class Output
    {
        public static void MainScreen()
        {
            var message = 
                "1. Checkout Items\n" +
                "2. View Price Catalogue\n" +
                "3. View Promotions\n" +
                "Please select an action: ";

            Console.WriteLine(message);

            int input;
            try
            {
                input = Int32.Parse(Console.ReadKey().ToString());
                Console.WriteLine(input.GetType());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }



            Console.ReadKey();
        }
    }
}