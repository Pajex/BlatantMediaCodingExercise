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

            /*
             Receipt Number                     Date
             Teller Name
             ---------------------------------------
             Quantity 
             Name    
             if(Quantity > 1) (@0.00/ea)         
             Price
             if(OnSale) SalePrice
             ---------------------------------------
             Regular Price
             Total Saved
             Total Paid
             */

            foreach (var item in CheckedOutItems)
            {
                
            }

            return output;
        }
    }
}