using System.Collections.Generic;

namespace GroceryCoConsole.Model
{
    public class Receipt
    {
        public decimal RegularPrice { get; set; }
        public decimal TotalSaved { get; set; }
        public decimal TotalPrice { get; set; }
        public IList<Item> CheckedOutItems { get; set; }

        public Receipt(IList<Item> items)
        {
            CheckedOutItems = items;
        }

        private void CalculatePrice()
        {
            foreach (var checkedOutItem in CheckedOutItems)
            {

                if (checkedOutItem.OnSale)
                {
                    
                }
            }
        }

        public void Print()
        {
            
        }
    }
}