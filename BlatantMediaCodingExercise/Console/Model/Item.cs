namespace GroceryCoConsole.Model
{
    public class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal SalePrice { get; set; }
        public bool OnSale { get; set; }

        public override string ToString()
        {
            return $"Name: {Name} Price: {Price} SalePrice: {SalePrice} OnSale: {OnSale} ";
        }
    }
}