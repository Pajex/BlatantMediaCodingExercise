using System;
using System.Collections.Generic;
using System.Linq;

namespace GroceryCoConsole.Model
{
    public class Receipt
    {
        public double RegularPrice
        {
            get { return CheckedOutItems.Sum(x => x.Price); }
        }

        public double TotalSaved => RegularPrice - TotalPrice;
        
        public double TotalPrice 
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
                        output += $"  {"(@$"+item.SalePrice+"/ea)",-12:C2}{item.SalePrice * item.Quantity,12:C2}\n"; 
                    }
                    else
                    {
                        output += $"{item.SalePrice,-24:C2}\n";
                    }
                    
                }
                else if (item.Quantity > 1)
                {
                    output += $" {"(@$"+item.Price+"/ea)",-12:C2}{item.Price * item.Quantity,12:C2}\n";
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