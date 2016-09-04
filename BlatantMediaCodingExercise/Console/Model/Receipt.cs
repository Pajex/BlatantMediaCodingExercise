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
            var output = "----------------------------------\n";
            output += $"Receipt #1 \t\t{DateTime.Now,10:yy-MM-dd}\n";
            output += "Teller Name: Mike\n";
            output += "----------------------------------\n";

            foreach (var item in CheckedOutItems)
            {
                output += $"{item.Quantity,1} {item.Name,5}";

                if (item.OnSale)
                {
                    if (item.Quantity > 1)
                    {
                        output += $"\t{"(@"+item.SalePrice+"/ea)",8:C2}{item.SalePrice * item.Quantity,16:C2}\n"; 
                    }
                    else
                    {
                        output += $"{item.SalePrice,27:C2}\n";
                    }
                }
                else if (item.Quantity > 1)
                {
                    output += $"(@{item.Price,8:C2}/ea)\t{item.Price * item.Quantity,5:C2}\n";
                }
                else
                {
                    output += $"\t{item.Price,18:C2}\n";
                }
            }

            output += "----------------------------------\n";
            output += $"Regular Price: {RegularPrice,19:C2}\n";
            output += $"Total Saved: {TotalSaved,21:C2}\n";
            output += $"TOTAL: {TotalPrice,27:C2}\n\n";
            output += "----------------------------------\n";
            output += $"Balance Due: {TotalPrice,21:C2}\n\n";

            

            return output;
        }
    }
}