using System;
using System.Collections.Generic;
using System.Linq;

namespace GroceryCoConsole.Model
{
    public class Receipt
    {
        public decimal RegularPrice
        {
            get { return CheckedOutItems.Sum(x => x.Price); }
        }

        public decimal TotalSaved => RegularPrice - TotalPrice;
        
        public decimal TotalPrice 
        {
            get
            {
                var onSaleItems = CheckedOutItems.Where(x => x.OnSale).Sum(x => x.SalePrice);
                var regularItems = CheckedOutItems.Where(x => x.OnSale == false).Sum(x => x.Price);
                return onSaleItems + regularItems;
            }
        }
        public IList<CheckedOutItem> CheckedOutItems { get; set; }

        public Receipt()
        {
            CheckedOutItems = new List<CheckedOutItem>();
        }

        public override string ToString()
        {
            var output = "";

            foreach (var item in CheckedOutItems)
            {
                
            }

            return output;
        }
    }
}